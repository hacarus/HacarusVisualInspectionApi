ApiKey=$1

dotnet msbuild HacarusVisualInspectionApi /t:pack /p:Configuration=Release
dotnet nuget push HacarusVisualInspectionApi/bin/Release/*.nupkg -s https://api.nuget.org/v3/index.json -k $ApiKey