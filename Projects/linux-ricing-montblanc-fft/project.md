# Project: Linux ricing — Montblanc (FFT / FFTA vibe)

- **Created:** 2026-02-05
- **Status:** Active
- **Outcome (what done looks like):**
  - GNOME desktop feels cohesive and “Ivalice tactics” inspired (warm parchment + muted jewel tones)
  - Montblanc identity shows up via wallpaper/avatar + accent colors
  - Theme is comfortable for daily use (readable, not gimmicky)

## Next Actions
- [x] #nextaction #project/linux-ricing-montblanc-fft Choose a concrete palette + typography direction (FFTA whimsical, readable) (palette.md + Open Sans/JetBrains Mono)
- [x] #nextaction #project/linux-ricing-montblanc-fft Collect 3–5 reference images (FFT/FFTA UI, maps, parchment textures) to anchor the look (wallpaper gallery imported)
- [x] #nextaction #project/linux-ricing-montblanc-fft Decide the theming approach: Gradience/libadwaita + accents vs full GTK/Shell theme + extensions (WhiteSur + User Themes)

## Plan / Todo List
### Foundation
- [x] #project/linux-ricing-montblanc-fft Inventory current GNOME setup (Shell 49.3, themes, fonts, icons)
- [x] #project/linux-ricing-montblanc-fft Pick icon theme (Papirus / Tela / other) that fits parchment+jewel palette (set to Papirus)
- [x] #project/linux-ricing-montblanc-fft Pick cursor theme that doesn’t clash (set to Breeze)
- [x] #project/linux-ricing-montblanc-fft Decide fonts: UI font + terminal mono font (high readability) (set Open Sans + JetBrains Mono)

### Visual identity (Montblanc face)
- [ ] #nextaction #project/linux-ricing-montblanc-fft Set Montblanc avatar everywhere: local profile + OpenClaw/Discord (use Reference/avatars/montblanc-avatar-zoom-1024.png)
- [x] #project/linux-ricing-montblanc-fft Choose a wallpaper set (day/night variants) in the tactics-whimsy style (gallery imported; applied selected/day.png + selected/night.png; fill mode)
- [x] #project/linux-ricing-montblanc-fft Set GNOME accent colors to match the palette (set accent-color to teal)

### GNOME Shell theming (full send)
- [x] #nextaction #project/linux-ricing-montblanc-fft Decide extensions needed (keep it minimal):
  - User Themes (already installed)
  - Dash to Dock (enabled + configured)
  - Blur My Shell (skipped for now to preserve readability)
- [x] #project/linux-ricing-montblanc-fft Install required tooling (dnf/flatpak) for theming
  - dnf: gnome-tweaks, gnome-extensions-app, papirus-icon-theme, jetbrains-mono-fonts, fira-code-fonts
- [x] #project/linux-ricing-montblanc-fft Apply GTK theme + Shell theme + icons + fonts (WhiteSur + Papirus + Open Sans + JetBrains Mono)
- [x] #project/linux-ricing-montblanc-fft Make a "revert" doc (how to return to stock Adwaita) (see revert.md)

### Terminal + dev vibe
- [ ] #nextaction #project/linux-ricing-montblanc-fft Set Ptyxis colors to match palette (parchment bg + ink text + teal highlights)
- [x] #project/linux-ricing-montblanc-fft Set Ptyxis font (JetBrains Mono 11)
- [ ] #project/linux-ricing-montblanc-fft Optional: tmux theme to match

## Waiting On
- [x] #waitingon #project/linux-ricing-montblanc-fft Reference images/wallpapers received (gallery imported)

## Someday / Maybe
- [ ] #someday #project/linux-ricing-montblanc-fft Custom GRUB / Plymouth boot splash in the same style
- [ ] #someday #project/linux-ricing-montblanc-fft Matching terminal + tmux theme

## Notes / Context
- Constraints: avoid actual pixel-art UI; aim for “illustrated tactics UI” vibes.
- Fedora Workstation (GNOME). No SSH used. Keep battery sleep normal.
