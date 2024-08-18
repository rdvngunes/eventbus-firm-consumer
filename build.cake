#tool "nuget:?package=GitVersion.CommandLine"
#tool "nuget:?package=NUnit.ConsoleRunner"
#addin "nuget:?package=Cake.FileHelpers"
 


///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var testFailed = false;
var solutionDir = System.IO.Directory.GetCurrentDirectory();
var artifactDir = Argument("artifactDir", "./artifacts");
var appDir = Argument("appDir", "./app");
string versionInfo = null; 
string apiKey = "000ed3ac-b281-4481-b2d2-4ad9c1267ae3"; 
string source = "https://www.myget.org/F/hemlak/api/v2/package";
var coverageBackendThreshold = 0;

 
///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task ("Version")
    .Does (() =>  {
if(BuildSystem.IsLocalBuild)
     {
        var gitVersion2 = GitVersion(new GitVersionSettings()
        {

            OutputType = GitVersionOutput.Json,
            NoFetch = true

        });
        versionInfo = gitVersion2.NuGetVersionV2;
     }
   if(BuildSystem.IsRunningOnJenkins)
    {
       if(IsRunningOnUnix()) {
           StartProcess ("bash","git-version /output buildserver ");
       }
       else{
           GitVersion(new GitVersionSettings(){
               OutputType = GitVersionOutput.BuildServer

           });
       }
           var lines = FileReadLines("gitversion.properties");
           var line = lines.Single(w=> w.StartsWith("GitVersion_NuGetVersionV2"));
           var nugetVersion = line.Replace("GitVersion_NuGetVersionV2=","").Trim();
           versionInfo = nugetVersion;
    }
    Information($"Version  {versionInfo}"); 
 
    }); 


Task("Clean")
	.Does(() =>
	{
		var settings = new DeleteDirectorySettings {
    		Recursive = true,
    		Force = true
		};
		if(DirectoryExists(artifactDir))
		{
			CleanDirectory(artifactDir);
			DeleteDirectory(artifactDir, settings);
		}

		var binDirs = GetDirectories("./**/bin");
		var objDirs = GetDirectories("./**/obj");
		
		CleanDirectories(binDirs);
		CleanDirectories(objDirs);
		
		DeleteDirectories(binDirs, settings);
		DeleteDirectories(objDirs, settings);
      DotNetCoreClean(solutionDir);
	});

Task("Restore")
	.Does(() =>
	{
		DotNetCoreRestore();	  
	});

   Task("Build")
   .IsDependentOn("Clean")
   .IsDependentOn("Restore")
   .Does(()=>
   {
      var solution = GetFiles("./*.sln").ElementAt(0);
		Information("Build solution: {0}", solution);
		var settings = new DotNetCoreBuildSettings
		{
			Configuration = configuration
		};

		DotNetCoreBuild(solution.FullPath, settings);

   });

Task ("Run Unit Tests")
    .Does (() => {
        var projects = GetFiles ("./test/**/*.Unit.Test.csproj");
        DotNetCoreTestSettings testSetting = new DotNetCoreTestSettings () {
            ArgumentCustomization = args => args.Append ("/p:CollectCoverage=true")
            .Append ("/p:CoverletOutputFormat=opencover")
            .Append ("/p:ThresholdType=line")
            .Append ("/p:CoverletOutput=../../Artifacts/")
            .Append ("/p:Exclude=[NUnit3.*]*")
            .Append ($"/p:Threshold={coverageBackendThreshold}")
        };

        foreach (var project in projects) {

            DotNetCoreTest (project.FullPath, testSetting);
        }
    });

Task ("Run Integration Tests")
    .Does (() => {
        var projects = GetFiles ("./test/**/*.Integration.Test.csproj");
        DotNetCoreTestSettings testSetting = new DotNetCoreTestSettings () {
            Verbosity =  DotNetCoreVerbosity.Normal
        };
        foreach (var project in projects) {
            DotNetCoreTest (project.FullPath, testSetting);
        }
    });


Task("Default")
.IsDependentOn("Build")
.Does(() => {
   
});

RunTarget(target);