﻿Write-Host "Starting packaging of the extension"

$packageFolder = "$($env:OutputPath)Package\"
$assembliesFolder = "$($packageFolder)Assemblies\"

Remove-Item -Recurse $packageFolder -Force | Out-Null
New-Item -ItemType Directory $packageFolder -Force | Out-Null

Write-Host "Copying assemblies"
@(
    "$($assembliesFolder)svc\bin", 
    "$($assembliesFolder)bin", 
    "$($assembliesFolder)ServiceRepository\BinaryComponents"
) | ForEach-Object {
    New-Item -ItemType Directory $_ -Force | Out-Null
    Copy-Item "$($env:OutputPath)CentralAdministration.dll" $_
}

Write-Host "Building frontend"
#Todo: Frontend Build
$frontendFolder = "$($packageFolder)Files\WM\workspaces\CentralAdministration\"
New-Item -ItemType Directory $frontendFolder -Force | Out-Null
#Copy-Item "module.js" $frontendFolder

Write-Host "Copying schema files"
$installFolder = "$($packageFolder)Install"
New-Item -ItemType Directory $installFolder -Force | Out-Null
Copy-Item "$($env:ProjectDir)Config\*" $installFolder

Write-Host "Creating schema installation manifest"

$oldWorkingDirectory = Get-Location
Set-Location $packageFolder
& "$($env:ProjectDir)Tools/CreateSchemaFile.exe" @( "install", "Install.xml", "install" ) | Out-Null
Set-Location $oldWorkingDirectory

Write-Host "Creating extension manifest"
$version = (Get-Item "$($env:OutputPath)CentralAdministration.dll").VersionInfo.ProductVersion
@{
    "Id" = "00000000-1337-1337-1337-000000000000"
    "Version" = $version
    "LastUpdatedDate" =  $(Get-Date)
    "Description" =  "Central Management for partner extensions"
    "Prerequisites" =  @{
        "MinimalRequiredProductVersion" =  "12.0.3"
    }
    "Name" =  "Central Administration"
    "SetupDirectives" = @{
        "RecycleWebApplication" = $true
        "RestartM42WindowsServices" = $true
        "InstallationPSFiles" = $null
        "MaintenanceMode" = $false
    }
    "Vendor" =  "Matrix42 Community Extensions"
} | Out-File "$($packageFolder)package.json" -Encoding utf8

$packageZip = "$($env:OutputPath)CentralAdministration.zip"
Compress-Archive -Path "$packageFolder*" -DestinationPath $packageZip -Force | Out-Null

#Optional cleanup
#Remove-Item $packageFolder -Force -Recurse

Write-Host "Done creating package to $packageZip"