Param(
# Nuget APIKey
    [string] $apikey
)

if ($apikey -eq $null -or $apikey -eq "")
{
    Write-Error "require apiKey";
    return;
}

rm -r ./build/nupkgs
dotnet build -c Release
$files = Get-ChildItem -Path ./build/nupkgs/ -Filter *.nupkg
foreach ($file in $files)
{
    dotnet nuget push $file.fullName --skip-duplicate --api-key $apikey --source https://api.nuget.org/v3/index.json
    nuget add $file.fullName -source d:\nuget-pkg
}
$files = Get-ChildItem -Path ./build/nupkgs/ -Filter *.snupkg
foreach ($file in $files)
{
    dotnet nuget push $file.fullName --skip-duplicate --api-key $apikey --source https://api.nuget.org/v3/index.json
    nuget add $file.fullName -source d:\nuget-pkg
}