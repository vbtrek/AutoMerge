# AutoMerge Extension Debugging Helper Script
# Run this script to reset and prepare for debugging

param(
    [switch]$ResetExperimental,
    [switch]$ClearCache,
    [switch]$CheckDeployment,
    [switch]$ViewLogs,
    [switch]$All
)

$vsPath = "D:\Program Files\Microsoft Visual Studio\2026\Enterprise\Common7\IDE\devenv.exe"
$expPath = "$env:LOCALAPPDATA\Microsoft\VisualStudio\18.0*Exp"

Write-Host "=== AutoMerge Extension Debug Helper ===" -ForegroundColor Cyan
Write-Host ""

if ($All) {
    $ResetExperimental = $true
    $ClearCache = $true
    $CheckDeployment = $true
}

# Close all VS instances
Write-Host "Checking for running Visual Studio instances..." -ForegroundColor Yellow
$vsProcesses = Get-Process devenv -ErrorAction SilentlyContinue
if ($vsProcesses) {
    Write-Host "WARNING: Visual Studio is running. Please close all instances before continuing." -ForegroundColor Red
    Write-Host "Found processes:" -ForegroundColor Red
    $vsProcesses | ForEach-Object { Write-Host "  PID: $($_.Id) - $($_.MainWindowTitle)" }
    $response = Read-Host "Do you want to force close them? (y/n)"
    if ($response -eq 'y') {
        $vsProcesses | Stop-Process -Force
        Start-Sleep -Seconds 2
        Write-Host "Processes terminated." -ForegroundColor Green
    } else {
        Write-Host "Please close Visual Studio and run this script again." -ForegroundColor Yellow
        exit
    }
}

if ($ClearCache) {
    Write-Host "`nClearing MEF and Component Model Cache..." -ForegroundColor Yellow
    $cachePaths = Get-Item "$expPath\ComponentModelCache" -ErrorAction SilentlyContinue
    if ($cachePaths) {
        $cachePaths | ForEach-Object {
            Write-Host "  Removing: $($_.FullName)" -ForegroundColor Gray
            Remove-Item $_.FullName -Recurse -Force
        }
        Write-Host "Cache cleared successfully!" -ForegroundColor Green
    } else {
        Write-Host "No cache found (this is normal for first run)." -ForegroundColor Gray
    }
}

if ($ResetExperimental) {
    Write-Host "`nResetting Experimental Instance..." -ForegroundColor Yellow
    $expInstances = Get-Item $expPath -ErrorAction SilentlyContinue
    if ($expInstances) {
        $expInstances | ForEach-Object {
            Write-Host "  Removing: $($_.FullName)" -ForegroundColor Gray
            Remove-Item $_.FullName -Recurse -Force -ErrorAction SilentlyContinue
        }
        Write-Host "Experimental instance reset!" -ForegroundColor Green
    } else {
        Write-Host "No experimental instance found (will be created on first debug)." -ForegroundColor Gray
    }
}

if ($CheckDeployment) {
    Write-Host "`nChecking Extension Deployment..." -ForegroundColor Yellow
    $extensionPaths = Get-Item "$expPath\Extensions\*\*\IntactAutoMerge.dll" -ErrorAction SilentlyContinue
    if ($extensionPaths) {
        Write-Host "Extension DLL found at:" -ForegroundColor Green
        $extensionPaths | ForEach-Object {
            Write-Host "  $($_.FullName)" -ForegroundColor Gray
            $version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($_.FullName)
            Write-Host "    Version: $($version.FileVersion)" -ForegroundColor Gray
            Write-Host "    Modified: $($_.LastWriteTime)" -ForegroundColor Gray
        }
    } else {
        Write-Host "Extension not deployed yet. This is normal before first debug run." -ForegroundColor Gray
    }

    # Check for VSIX file in bin
    $vsixPath = ".\AutoMerge\bin\Debug\*.vsix"
    $vsixFiles = Get-Item $vsixPath -ErrorAction SilentlyContinue
    if ($vsixFiles) {
        Write-Host "`nVSIX package found:" -ForegroundColor Green
        $vsixFiles | ForEach-Object {
            Write-Host "  $($_.FullName)" -ForegroundColor Gray
            Write-Host "    Size: $([math]::Round($_.Length / 1MB, 2)) MB" -ForegroundColor Gray
            Write-Host "    Modified: $($_.LastWriteTime)" -ForegroundColor Gray
        }
    }
}

if ($ViewLogs) {
    Write-Host "`nChecking Activity Logs..." -ForegroundColor Yellow
    $logPaths = Get-Item "$env:APPDATA\Microsoft\VisualStudio\18.0*Exp\ActivityLog.xml" -ErrorAction SilentlyContinue
    if ($logPaths) {
        $logPaths | ForEach-Object {
            Write-Host "`nActivity Log: $($_.FullName)" -ForegroundColor Cyan
            Write-Host "Last errors related to AutoMerge:" -ForegroundColor Yellow
            $content = Get-Content $_.FullName -Raw
            if ($content -match "AutoMerge|IntactAutoMerge") {
                $content | Select-String -Pattern "<entry>.*?(AutoMerge|IntactAutoMerge).*?</entry>" -AllMatches | 
                    Select-Object -Last 5 | ForEach-Object {
                        Write-Host $_.Matches.Value -ForegroundColor Red
                    }
            } else {
                Write-Host "No AutoMerge entries found in log." -ForegroundColor Gray
            }
        }
    } else {
        Write-Host "No activity logs found." -ForegroundColor Gray
    }
}

Write-Host "`n=== Summary ===" -ForegroundColor Cyan
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "1. Open your solution in Visual Studio" -ForegroundColor White
Write-Host "2. Build the solution (Ctrl+Shift+B)" -ForegroundColor White
Write-Host "3. Press F5 to start debugging" -ForegroundColor White
Write-Host "4. In the Experimental Instance, go to Tools > Show Auto Merge" -ForegroundColor White
Write-Host ""
Write-Host "If you encounter issues, run this script with -ViewLogs to check errors" -ForegroundColor Gray
Write-Host ""

# Show usage if no parameters
if (-not ($ResetExperimental -or $ClearCache -or $CheckDeployment -or $ViewLogs)) {
    Write-Host "Usage:" -ForegroundColor Cyan
    Write-Host "  .\Reset-ExpInstance.ps1 -All                  # Do everything" -ForegroundColor White
    Write-Host "  .\Reset-ExpInstance.ps1 -ResetExperimental    # Reset experimental instance" -ForegroundColor White
    Write-Host "  .\Reset-ExpInstance.ps1 -ClearCache           # Clear MEF cache" -ForegroundColor White
    Write-Host "  .\Reset-ExpInstance.ps1 -CheckDeployment      # Check if extension is deployed" -ForegroundColor White
    Write-Host "  .\Reset-ExpInstance.ps1 -ViewLogs             # View activity logs" -ForegroundColor White
}
