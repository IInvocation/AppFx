#addin "Cake.FileHelpers"

//////////////////////////////////////////////////////////////////////
// CONSTANTS
//////////////////////////////////////////////////////////////////////

var versionXPath = "/Project/PropertyGroup/Version";
var packageXPath = "/Project/ItemGroup/PackageReference";

//////////////////////////////////////////////////////////////////////
// CLASSES
//////////////////////////////////////////////////////////////////////

class ProjectInfo
{
	public ProjectInfo(ConvertableDirectoryPath _dir, ConvertableFilePath _file) : this(_dir, _file, true)
	{
	}
	
	public ProjectInfo(ConvertableDirectoryPath _dir, ConvertableFilePath _file, bool _increaseVersion, params string[] packages)
	{
		ProjectDirectory = _dir;
		ProjectFile = _file;
		IncreaseVersion = _increaseVersion;	
		Packages = packages.ToList();
	}
	
	public ConvertableDirectoryPath ProjectDirectory {get; set;}
	
	public ConvertableFilePath ProjectFile {get; set;}
	
	public bool IncreaseVersion {get; set;}
	
	public List<string> Packages {get; set;}
}

//////////////////////////////////////////////////////////////////////
// FUNCTIONS
//////////////////////////////////////////////////////////////////////

void IncreaseVersionNumber(ConvertableFilePath project)
{
	var version = XmlPeek(project, versionXPath);
	var split = version.Split('.');
	var major = split[0];
	var minor = split[1];
	var build = int.Parse(split[2]) + 1;
	XmlPoke(project, versionXPath, major + "." + minor + "." + build);
	Information("Updated version of project '" + project + "' to " + version); 
}

void BuildProject(ConvertableFilePath project)
{
	if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild(project, settings => settings.SetConfiguration(configuration).SetVerbosity(Verbosity.Minimal));
    }
    else
    {
      // Use XBuild
      XBuild(project, settings => settings.SetConfiguration(configuration));
    }
}

void UpdateNugetPackages(ProjectInfo project, string prefix)
{
	Information("Adding packages for " + project.ProjectFile);
	foreach(var line in FileReadLines(project.ProjectFile))
	{
		var trimmed = line.Trim();
		if (!string.IsNullOrWhiteSpace(trimmed) && trimmed.StartsWith("<PackageReference"))
		{
			var startIndex = trimmed.IndexOf("Include=") + 9;
			var length = trimmed.IndexOf("Version=")-2-startIndex;
			var id = trimmed.Substring(startIndex, length);
			if (id.StartsWith(prefix))
			{
				DotNetCoreTool(project.ProjectFile, "add package " + id);
			}
		}
	}
	foreach(var package in project.Packages)
	{
		DotNetCoreTool(project.ProjectFile, "add package " + package);
	}
}

void CreateNugetPackage(ProjectInfo project, string configuration)
{
	var settings = new DotNetCorePackSettings
	{
		Configuration = configuration,
		NoBuild = true
	};
	
	DotNetCorePack(project.ProjectFile, settings);
}

void PublishNugetPackageLocal(ProjectInfo project, string configuration, string target)
{
	var directory = project.ProjectDirectory;
	Information(directory);
	var fileName = project.ProjectFile.ToString();
	var file = fileName.Substring(fileName.LastIndexOf("/")+1); // strip directory
	var version = XmlPeek(project.ProjectFile, versionXPath);
	file = file.Replace(".csproj", "." + version + ".nupkg");
	var completePath = directory + File(file);
	NuGetAdd(MakeAbsolute(completePath).ToString(), target);
	
	Information("Added package:");
	Information(MakeAbsolute(completePath).ToString());
}