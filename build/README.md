# README #

## AppFx ##

### Building AppFx ###

### Prerequisites ###
* Install Nuget-CLI (see https://docs.microsoft.com/en-us/nuget/guides/install-nuget)
* Add a share called "nuget", accessible by "\\localhost\nuget"
  (if you don't want that - you'll need to adjust the file "build.take" (see variable "localNugetTarget")
  
### Build Options ###
You can build either in Debug and Release-Mode using the commands
```code
.\build.ps1 -Configuration Debug
```
or
```code
.\build.ps1 -Configuration Release
```

### Debug Build ###
A debug build results in the following actions for every project enlisted in projects.cake:
* Cleanup of bin/{Configuration}
* Update of local Nuget-Packages (defined using a prefix in build.cake)
* Restore of Nuget-Packages
* Build project (in Debug-Mode)

### Release Build ###
A release build results in the following actions for every project enlisted in projects.cake:
* Cleanup of bin/{Configuration}
* Update of local Nuget-Packages (defined using a prefix in build.cake)
* Restore of Nuget-Packages
* Update the projects version-number
* Build project (in Debug-Mode)
* Create Nuget-Package of the built project
* Add Nuget-Package to the local NugetFeed
