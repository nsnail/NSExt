var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var pkgOutPath = $"./build/NSExt/pkg/{configuration}";

////////////////////////////////////////////////////////////////
// Tasks

Task("Clean")
    .Does(context =>
{
    context.CleanDirectory(pkgOutPath);
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(context => 
{
    DotNetBuild("./NSExt.sln", new DotNetBuildSettings {
        Configuration = configuration,
        NoIncremental = context.HasArgument("rebuild"),
        MSBuildSettings = new DotNetMSBuildSettings()
            .TreatAllWarningsAs(MSBuildTreatAllWarningsAs.Error)
    });
});


Task("Test")
    .IsDependentOn("Build")
    .Does(context => 
{
    DotNetTest("./test/Spectre.Console.Tests/Spectre.Console.Tests.csproj", new DotNetTestSettings {
        Configuration = configuration,
        NoRestore = true,
        NoBuild = true,
    });

    DotNetTest("./test/Spectre.Console.Cli.Tests/Spectre.Console.Cli.Tests.csproj", new DotNetTestSettings {
        Configuration = configuration,
        NoRestore = true,
        NoBuild = true,
    });

    DotNetTest("./test/Spectre.Console.Analyzer.Tests/Spectre.Console.Analyzer.Tests.csproj", new DotNetTestSettings {
        Configuration = configuration,
        NoRestore = true,
        NoBuild = true,
    });
});

Task("Package")
    .IsDependentOn("Build")
    .Does(context => 
{
    context.DotNetPack("./NSExt.sln", new DotNetPackSettings {
        Configuration = configuration,
        NoRestore = true,
        NoBuild = true,
        OutputDirectory = pkgOutPath,
        MSBuildSettings = new DotNetMSBuildSettings()
            .TreatAllWarningsAs(MSBuildTreatAllWarningsAs.Error)
    });
});

Task("Publish-GitHub")
    .WithCriteria(ctx => BuildSystem.IsRunningOnGitHubActions, "Not running on GitHub Actions")
    .IsDependentOn("Package")
    .Does(context => 
{
    var apiKey = Argument<string>("github-key", null);
    if(string.IsNullOrWhiteSpace(apiKey)) {
        throw new CakeException("No GitHub API key was provided.");
    }

    // Publish to GitHub Packages
    var exitCode = 0;
    foreach(var file in context.GetFiles("./.artifacts/*.nupkg")) 
    {
        context.Information("Publishing {0}...", file.GetFilename().FullPath);
        exitCode += StartProcess("dotnet", 
            new ProcessSettings {
                Arguments = new ProcessArgumentBuilder()
                    .Append("gpr")
                    .Append("push")
                    .AppendQuoted(file.FullPath)
                    .AppendSwitchSecret("-k", " ", apiKey)
            }
        );
    }

    if(exitCode != 0) 
    {
        throw new CakeException("Could not push GitHub packages.");
    }
});

Task("Publish-NuGet")
    // .WithCriteria(ctx => BuildSystem.IsRunningOnGitHubActions, "Not running on GitHub Actions")
    .IsDependentOn("Package")
    .Does(context => 
{
    var apiKey = Argument<string>("nuget-key", null);
    if(string.IsNullOrWhiteSpace(apiKey)) {
        throw new CakeException("No NuGet API key was provided.");
    }

    // Publish to GitHub Packages
    foreach(var file in context.GetFiles($"{pkgOutPath}/*.*nupkg")) 
    {
        context.Information("Publishing {0}...", file.GetFilename().FullPath);
        DotNetNuGetPush(file.FullPath, new DotNetNuGetPushSettings
        {
            Source = "https://api.nuget.org/v3/index.json",
            ApiKey = apiKey,
            SkipDuplicate = true
        });
    }
});

////////////////////////////////////////////////////////////////
// Targets

Task("Publish")
    //.IsDependentOn("Publish-GitHub")
    .IsDependentOn("Publish-NuGet");

Task("Default")
    .IsDependentOn("Package");

////////////////////////////////////////////////////////////////
// Execution

RunTarget(target)