# Undo/Redo System Design for Griddle

## Overview
A robust undo/redo system that allows users to reverse and re-apply changes to the dataset, schema, and UI state. This improves user confidence and reduces the risk of accidental data loss.

## Goals
- **Confidence**: Users can experiment freely knowing they can undo mistakes
- **Completeness**: All user-initiated state changes should be undoable
- **Performance**: Undo/redo operations should feel instant (< 100ms)
- **Intuitive**: Standard keyboard shortcuts (Ctrl+Z, Ctrl+Y / Cmd+Z, Cmd+Shift+Z)
- **Recoverable**: Undo history persists for the session (optional: persist across reloads)

## Architecture: Command Pattern

### Core Types

```typescript
// Base command interface
interface Command {
  readonly type: string;
  readonly timestamp: number;
  readonly description: string; // User-facing description (e.g., "Add field 'Revenue'")
  
  execute(): void;
  undo(): void;
  redo(): void; // Usually same as execute, but allows for optimization
}

// Command with snapshot (for complex state changes)
interface SnapshotCommand<T> extends Command {
  readonly before: T;
  readonly after: T;
}

// History state
interface UndoHistory {
  commands: Command[];
  currentIndex: number; // -1 = nothing to undo, 0 = at first command
  maxSize: number; // default: 100 commands
}

// Hook return type
interface UseUndoRedoResult {
  canUndo: boolean;
  canRedo: boolean;
  undo: () => void;
  redo: () => void;
  execute: (command: Command) => void;
  clearHistory: () => void;
  history: Command[]; // For debugging/UI display
  currentIndex: number;
}
```

### Command Categories

#### 1. Dataset Commands (High Priority)
- `AddRecordCommand` - Add new record to dataset
- `UpdateRecordCommand` - Modify record fields
- `DeleteRecordCommand` - Remove record(s)
- `BulkUpdateRecordsCommand` - Update multiple records (e.g., from pivot cell entry)

#### 2. Schema Commands (High Priority)
- `AddFieldCommand` - Add new field to schema
- `UpdateFieldCommand` - Modify field definition
- `DeleteFieldCommand` - Remove field (with migration)
- `ReorderFieldsCommand` - Change field order

#### 3. Pivot Config Commands (Medium Priority)
- `SetPivotDimensionsCommand` - Change row/col dimensions
- `SetPivotMeasureCommand` - Change active measure
- `UpdateFilterSetCommand` - Apply/modify filters

#### 4. View Commands (Low Priority)
- `CreateViewCommand` - Save new view
- `UpdateViewCommand` - Modify existing view
- `DeleteViewCommand` - Remove view

### Implementation: useUndoRedo Hook

```typescript
// src/hooks/useUndoRedo.ts
export function useUndoRedo(maxSize = 100): UseUndoRedoResult {
  const [history, setHistory] = useState<Command[]>([]);
  const [currentIndex, setCurrentIndex] = useState(-1);
  
  const canUndo = currentIndex >= 0;
  const canRedo = currentIndex < history.length - 1;
  
  const execute = useCallback((command: Command) => {
    // Execute the command
    command.execute();
    
    // Truncate any redo history if we're in the middle
    const newHistory = history.slice(0, currentIndex + 1);
    newHistory.push(command);
    
    // Enforce max size (remove oldest)
    if (newHistory.length > maxSize) {
      newHistory.shift();
    }
    
    setHistory(newHistory);
    setCurrentIndex(newHistory.length - 1);
  }, [history, currentIndex, maxSize]);
  
  const undo = useCallback(() => {
    if (!canUndo) return;
    const command = history[currentIndex];
    command.undo();
    setCurrentIndex(currentIndex - 1);
  }, [history, currentIndex, canUndo]);
  
  const redo = useCallback(() => {
    if (!canRedo) return;
    const command = history[currentIndex + 1];
    command.redo();
    setCurrentIndex(currentIndex + 1);
  }, [history, currentIndex, canRedo]);
  
  const clearHistory = useCallback(() => {
    setHistory([]);
    setCurrentIndex(-1);
  }, []);
  
  return {
    canUndo,
    canRedo,
    undo,
    redo,
    execute,
    clearHistory,
    history,
    currentIndex
  };
}
```

### Integration with App State

```typescript
// src/state/AppState.ts
interface AppState {
  dataset: DatasetFileV1;
  pivotConfig: PivotConfig;
  activeFilterSet: FilterSet;
  views: View[];
  
  // Undo/redo integration
  undoRedo: {
    canUndo: boolean;
    canRedo: boolean;
    undo: () => void;
    redo: () => void;
  };
}

// The hook wraps state setters with command creation
function useAppStateWithUndo() {
  const { execute, undo, redo, canUndo, canRedo } = useUndoRedo();
  const [dataset, setDataset] = useState<DatasetFileV1>(...);
  
  // Wrapper that creates commands automatically
  const updateDataset = useCallback((updater: (d: DatasetFileV1) => DatasetFileV1, description: string) => {
    const before = dataset;
    const after = updater(before);
    
    execute({
      type: 'UPDATE_DATASET',
      timestamp: Date.now(),
      description,
      execute: () => setDataset(after),
      undo: () => setDataset(before),
      redo: () => setDataset(after)
    });
  }, [dataset, execute]);
  
  return {
    dataset,
    updateDataset,
    undo,
    redo,
    canUndo,
    canRedo
  };
}
```

## Specific Command Implementations

### UpdateRecordCommand

```typescript
interface UpdateRecordCommand extends Command {
  type: 'UPDATE_RECORD';
  recordId: string;
  fieldKey: string;
  oldValue: unknown;
  newValue: unknown;
}

function createUpdateRecordCommand(
  recordId: string,
  fieldKey: string,
  newValue: unknown,
  dataset: DatasetFileV1,
  setDataset: (d: DatasetFileV1) => void
): UpdateRecordCommand {
  const record = dataset.records.find(r => r.id === recordId);
  const oldValue = record?.data[fieldKey];
  
  return {
    type: 'UPDATE_RECORD',
    timestamp: Date.now(),
    description: `Update ${fieldKey} for record ${recordId}`,
    recordId,
    fieldKey,
    oldValue,
    newValue,
    
    execute: () => {
      setDataset(produce(dataset, draft => {
        const r = draft.records.find(r => r.id === recordId);
        if (r) r.data[fieldKey] = newValue;
      }));
    },
    
    undo: () => {
      setDataset(produce(dataset, draft => {
        const r = draft.records.find(r => r.id === recordId);
        if (r) r.data[fieldKey] = oldValue;
      }));
    },
    
    redo: function() { this.execute(); }
  };
}
```

### BulkUpdateCommand (for pivot cell entry)

```typescript
interface BulkUpdateCommand extends Command {
  type: 'BULK_UPDATE';
  updates: Array<{
    recordId: string;
    fieldKey: string;
    oldValue: unknown;
    newValue: unknown;
  }>;
}

// This handles the case where user enters a value for a pivot cell
// that affects multiple records
```

## UI/UX Considerations

### Keyboard Shortcuts
- **Undo**: Ctrl+Z (Windows/Linux) / Cmd+Z (Mac)
- **Redo**: Ctrl+Y or Ctrl+Shift+Z (Windows/Linux) / Cmd+Shift+Z (Mac)
- Handle keydown at document level with preventDefault

### Visual Feedback
1. **Toast/Notification**: Brief "Undo: [description]" message when undoing
2. **History Panel** (optional): Sidebar showing recent actions with click-to-undo
3. **Disabled States**: Undo/Redo buttons disabled when not available
4. **Brief Highlight**: Flash the affected cells/rows when undoing/redoing

### Menu Items
```
Edit
├── Undo [Ctrl+Z]      (disabled when no history)
├── Redo [Ctrl+Y]      (disabled when no redo)
├── ─────────────────
├── Cut  [Ctrl+X]
├── Copy [Ctrl+C]
└── Paste [Ctrl+V]
```

## Edge Cases & Considerations

### 1. Import/Export
- **Decision**: Clear history on import (user is effectively starting fresh)
- **Rationale**: Old history wouldn't make sense with new dataset

### 2. Large Bulk Operations
- **Optimization**: For bulk operations (>100 records), use snapshot-based commands
- **Memory**: Store only changed fields, not entire dataset copy

### 3. Schema Changes with Data Migration
- **Challenge**: Deleting a field removes data from all records
- **Solution**: Store the removed data in the command for restoration

### 4. Concurrent Modifications
- **Assumption**: Single-user local app (no concurrent edits)
- **Future**: If multiplayer, would need Operational Transform or CRDT

### 5. Memory Limits
- **Limit**: Default 100 commands (configurable)
- **Eviction**: Oldest commands removed when limit exceeded
- **Large Commands**: Snapshot commands count as 1 regardless of size

## Implementation Phases

### Phase 1: Core Infrastructure (MVP)
- [ ] Create `useUndoRedo` hook
- [ ] Implement 3 basic command types (UpdateRecord, AddRecord, DeleteRecord)
- [ ] Add keyboard shortcuts (Ctrl+Z, Ctrl+Y)
- [ ] Wire into Entry panel (fast entry)
- [ ] Basic UI: Edit menu with Undo/Redo

**Acceptance**: Can undo/redo record edits in the entry panel

### Phase 2: Schema Commands
- [ ] AddFieldCommand
- [ ] UpdateFieldCommand
- [ ] DeleteFieldCommand (with data migration)
- [ ] Visual feedback (toast notifications)

**Acceptance**: Can undo field additions, edits, and deletions

### Phase 3: Pivot & Filter Commands
- [ ] SetPivotDimensionsCommand
- [ ] UpdateFilterSetCommand
- [ ] CreateViewCommand
- [ ] History panel UI (optional but nice)

**Acceptance**: Can undo pivot configuration changes and view creation

### Phase 4: Polish
- [ ] Persistence across reload (optional)
- [ ] Performance optimization for large datasets
- [ ] Visual highlights on undo/redo

## Open Questions

1. **Should filter/pivot changes be undoable?**
   - Pro: Complete undo coverage
   - Con: May be confusing (users might expect only data changes)
   - **Recommendation**: Yes, but separate history or clear visual distinction

2. **Should undo history persist across reloads?**
   - Pro: Recovery from accidental refresh
   - Con: Added complexity, storage concerns
   - **Recommendation**: Phase 4, use localStorage with size limits

3. **How to handle "destructive" operations like schema field deletion?**
   - Store full record data in command (memory intensive)
   - Store only the affected field values (better)
   - **Recommendation**: Store only affected fields with their values

## Appendix: Alternative Approaches Considered

### A. State Snapshots
- Store full dataset snapshots after each operation
- Pros: Simple, reliable
- Cons: Memory intensive for large datasets
- **Verdict**: Use only for small datasets or infrequent operations

### B. Immutable History with Structural Sharing
- Use Immer/produce to create patches
- Store patches instead of full commands
- Pros: Memory efficient
- Cons: More complex, harder to debug
- **Verdict**: Good for Phase 4 optimization

### C. Event Sourcing
- Store event log, replay to get state
- Pros: Full audit trail, can branch timelines
- Cons: Overkill for this use case
- **Verdict**: Not recommended for Griddle

## References
- [Command Pattern - Refactoring Guru](https://refactoring.guru/design-patterns/command)
- [Undo/Redo in React](https://redux.js.org/usage/implementing-undo-history)
- [Immer Patches](https://immerjs.github.io/immer/patches/)
