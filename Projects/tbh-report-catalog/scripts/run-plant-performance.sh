#!/bin/bash
# Build and run Plant Performance demo
# Usage: ./run-plant-performance.sh

set -e

cd "$(dirname "$0")/.."

echo "TBH Report Catalog - Building and Running"
echo "=========================================="
echo ""

# Build
echo "Building solution..."
dotnet build

# Run
echo ""
echo "Running Plant Performance demo..."
echo ""
dotnet run --project src/Tbh.ReportCatalog/Tbh.ReportCatalog.csproj

echo ""
echo "Done! Check the output Excel file in the project directory."
