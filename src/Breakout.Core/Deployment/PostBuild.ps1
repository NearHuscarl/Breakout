# Powershell 3+

# PostBuild event for Breakout.Core project.
# Move all json map files to $(TargetDir)maps\
#
# Visual Studio PostBuild Command:
# powershell -ExecutionPolicy RemoteSigned -NoLogo -NonInteractive -Command ".'$(ProjectDir)Deployment\PostBuild.ps1' -SolutionDir '$(SolutionDir)' -TargetDir '$(TargetDir)'"

# param(
#    [String] $SolutionDir,
#    [String] $TargetDir)

param(
   [String] $SolutionDir = "..\..\",
   [String] $TargetDir = "..\bin\Windows\x86\Debug\")

$ErrorActionPreference = "Stop"

# Write-Host $SolutionDir
# Write-Host $TargetDir
# Write-Host $pwd

$MapPath = "${SolutionDir}..\tool\maps"
$ScriptPath = "${SolutionDir}..\tool"
$OutputPath = "${TargetDir}maps"
$Prompt = "PostBuild>"

Write-Host "${Prompt} Running Post-Build Event..."

if (!(Test-Path -Path "$OutputPath"))
{
	Write-Host "${Prompt} ${OutputPath} not exists. Creating new one"
	New-Item -ItemType directory -Path $OutputPath
}

# you shall have python
if (Get-Command "python" -ErrorAction SilentlyContinue)
{
	Write-Host "${Prompt} Running python script to convert png images to json files"
	python "${ScriptPath}\pixel2char.py"
}
else
{
	Write-Host "${Prompt} Python not exist. Skip converting to json files"
}

Write-Host "${Prompt} Copy maps to ${OutputPath}"
Copy-Item -Path "$MapPath\*" -Include "*.json" -Destination $OutputPath
