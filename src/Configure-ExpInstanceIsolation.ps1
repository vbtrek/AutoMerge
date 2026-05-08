# Configure Experimental Instance to NOT Inherit Extensions
# This prevents extensions from main VS from appearing in Exp instance

Write-Host "=== Configure Experimental Instance Extension Isolation ===" -ForegroundColor Cyan
Write-Host ""

# Close experimental instance if running
$expProcesses = Get-Process devenv -ErrorAction SilentlyContinue | Where-Object { $_.CommandLine -like "*Exp*" }
if ($expProcesses) {
    Write-Host "Closing Experimental Instance..." -ForegroundColor Yellow
    $expProcesses | Stop-Process -Force
    Start-Sleep -Seconds 2
}

# Find experimental instance directories
$expDirs = Get-Item "$env:LOCALAPPDATA\Microsoft\VisualStudio\18.0*Exp" -ErrorAction SilentlyContinue

if (-not $expDirs) {
    Write-Host "No experimental instance found yet." -ForegroundColor Gray
    Write-Host "It will be created when you first press F5." -ForegroundColor Yellow
    Write-Host ""
    Write-Host "After creating it, run this script again." -ForegroundColor Yellow
    exit 0
}

foreach ($expDir in $expDirs) {
    Write-Host "Configuring: $($expDir.Name)" -ForegroundColor Cyan

    # Path to extensions.configurationchanged (this marks config as changed)
    $configFile = "$($expDir.FullName)\extensions.configurationchanged"

    # Create marker to disable extension inheritance
    # Note: This is a workaround - VS does not officially support disabling inheritance

    # Method 1: Clear and lock Extensions folder
    $extensionsFolder = "$($expDir.FullName)\Extensions"
    if (Test-Path $extensionsFolder) {
        Write-Host "Clearing Extensions folder..." -ForegroundColor Yellow

        # Keep only your AutoMerge extension
        Get-ChildItem $extensionsFolder -Directory | Where-Object { 
            $_.Name -notlike "*Kulikov Denis*" -and $_.Name -notlike "*F05BAC3E*" 
        } | ForEach-Object {
            Write-Host "  Removing: $($_.Name)" -ForegroundColor Gray
            Remove-Item $_.FullName -Recurse -Force -ErrorAction SilentlyContinue
        }

        Write-Host "  Cleared non-AutoMerge extensions" -ForegroundColor Green
    }

    # Method 2: Clear extension cache
    $extensionCache = "$($expDir.FullName)\Extensions\*.cache"
    Get-Item $extensionCache -ErrorAction SilentlyContinue | ForEach-Object {
        Write-Host "Removing extension cache: $($_.Name)" -ForegroundColor Yellow
        Remove-Item $_.FullName -Force -ErrorAction SilentlyContinue
    }

    # Method 3: Clear MEF cache (force rescan without inheritance)
    $mefCache = "$($expDir.FullName)\ComponentModelCache"
    if (Test-Path $mefCache) {
        Write-Host "Clearing MEF cache..." -ForegroundColor Yellow
        Remove-Item $mefCache -Recurse -Force -ErrorAction SilentlyContinue
        Write-Host "  MEF cache cleared" -ForegroundColor Green
    }

    # Create a marker file to track this configuration
    $markerFile = "$($expDir.FullName)\extensions-isolation-enabled.txt"
    "Extension isolation configured on $(Get-Date)" | Out-File $markerFile
    Write-Host "  Configuration marker created" -ForegroundColor Green
}

Write-Host "`n=== Configuration Complete ===" -ForegroundColor Cyan
Write-Host ""
Write-Host "Extension isolation configured for experimental instance." -ForegroundColor Green
Write-Host ""
Write-Host "Note: VS may still try to install extensions from the main instance." -ForegroundColor Yellow
Write-Host "If AWS extension reappears, you can:" -ForegroundColor Yellow
Write-Host "  1. Run Remove-AWSFromExp.ps1 to remove it" -ForegroundColor White
Write-Host "  2. Manually disable it in the Experimental Instance" -ForegroundColor White
Write-Host "  3. Uninstall AWS Toolkit from your main VS instance" -ForegroundColor White
Write-Host ""
