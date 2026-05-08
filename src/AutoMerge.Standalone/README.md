# AutoMerge - Setup Complete

## Summary of Changes

### 1. Fixed AutoMergeToolWindowControl
**Problem**: The tool window wasn't loading changesets or branch data.

**Solution**: Modified `AutoMergeToolWindowControl.xaml.cs` to properly initialize the ViewModels:
- Added calls to `Initialize()` with `SectionInitializeEventArgs`
- Added calls to `Refresh()` to trigger data loading
- Kept error handling to show detailed error messages if initialization fails

The ViewModels (`RecentChangesetsViewModel` and `BranchesViewModel`) inherit from `TeamExplorerSectionViewModelBase` which requires proper initialization before they will load data.

### 2. Created Standalone WinForms Application
**New Project**: `AutoMerge.Standalone`

A standalone Windows Forms application that can run the AutoMerge functionality outside of Visual Studio.

**Key Files Created**:
- `AutoMerge.Standalone.csproj` - Project file targeting .NET Framework 4.8
- `Program.cs` - Application entry point
- `MainForm.cs/Designer.cs` - Main form with TFS connection UI
- `StandaloneServiceProvider.cs` - Service provider for TFS connectivity
- `StandaloneLogger.cs` - Console/Debug logger implementation

**Features**:
- Connect to any TFS server by entering the URL
- Hosts the AutoMerge WPF control using ElementHost
- Shows connection status in status bar
- Reuses all the existing AutoMerge logic from the VSIX project

**How to Use**:
1. Build the solution
2. Run `AutoMerge.Standalone.exe`
3. Enter your TFS URL (e.g., `http://your-tfs-server:8080/tfs/DefaultCollection`)
4. Click "Connect"
5. The AutoMerge interface will load with Recent Changesets and Branches sections

### 3. Dependencies
Both projects now reference the correct VS 2026 TeamFoundation assemblies:
- Microsoft.TeamFoundation.Client (v20.256.x)
- Microsoft.TeamFoundation.Common (v20.256.x)
- Microsoft.TeamFoundation.Controls (v18.5.x)
- Microsoft.TeamFoundation.VersionControl.Client (v20.256.x)
- Microsoft.TeamFoundation.VersionControl.Common (v20.256.x)
- Microsoft.TeamFoundation.WorkItemTracking.Client (v20.256.x)
- Microsoft.VisualStudio.Services.Common
- Microsoft.VisualStudio.Services.WebApi
- Newtonsoft.Json

All assemblies are set to `Private=True` so they are packaged with the applications.

## Testing the VSIX

1. Press **F5** in Visual Studio
2. A new VS instance will launch (experimental)
3. Open a solution connected to TFS
4. Go to **View > Other Windows > AutoMerge Tool Window** OR
5. Use the Team Explorer button
6. The window should now show your recent changesets and branches

## Testing the Standalone App

1. Set `AutoMerge.Standalone` as the startup project
2. Press **F5** or **Ctrl+F5**
3. Enter your TFS server URL
4. Click Connect
5. The AutoMerge interface should load

## Notes

- The standalone app requires access to a TFS server
- You may need to adjust the `StandaloneServiceProvider` if additional services are needed
- The standalone app uses the same ViewModels and Views as the VSIX, ensuring consistent behavior
