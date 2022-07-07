$UpdateInstaller = "https://catalog.s.download.windowsupdate.com/d/msdownload/update/software/secu/2020/07/windows6.1-kb4575903-x86_5905c774f806205b5d25b04523bb716e1966306d.msu"
$UpdatePackage = "Windows6.1-KB4575903-x86.cab"
$ConfigPath = "x86_microsoft-windows-s..omponent-pkeyconfig_31bf3856ad364e35_6.1.7601.24558_none_4d78bb7f5a12e4c1/pkeyconfig.xrm-ms"

try {
    $Expand = Get-Command expand.exe
}
catch {
    Write-Error "Microsoft (R) File Expansion Utility not found!"
    exit
}

if (-not (Test-Path _temp))
{
    New-Item _temp -ItemType Directory
}

if (-not (Test-Path _temp/patch.msu))
{
    Invoke-WebRequest $UpdateInstaller -OutFile _temp/patch.msu
}

& $Expand _temp/patch.msu -F:$UpdatePackage _temp

& $Expand _temp/$UpdatePackage -F:* _temp

Copy-Item (Join-Path _temp $ConfigPath) .
