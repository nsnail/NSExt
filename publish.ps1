Remove-Item ./dist -Recurse -Force -Confirm:$false
dotnet build -c Release
$apikey = Read-Host -Prompt "nuget apikey"
foreach ($file in Get-ChildItem -Path ./dist/NSExt/bin/Release | Where-Object { $_.Name -match "nupkg" }) {
    dotnet nuget push $file --skip-duplicate --api-key $apikey --source https://api.nuget.org/v3/index.json
}