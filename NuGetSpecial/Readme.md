a spike of a nuget package that generates x86 and x64 binaries that are loaded dynamically at runtime depending on what architecture we are running under.

# Projects
* PlatformSpecific
  * No dependencies
  * Builds in x86 and x64
* Package
  * Depends on PlatformSpecific (project reference)
  * Contains the nuget package specification
* Intermediary
  * Depends on the Package (via nuget)  
* ConsoleApplication
  * Depends on Intermediar (project reference)
  * Runs in either x86 or x64 mode (depends on build settings)
  * Dynamically loads PlatformSpecific dlls from x86 or x64 subfolders

to build the nuget package (update the version number each time):
```
nuget pack Package.nuspec  -outputdirectory C:\Code\nugetpackages -version 1.0.0.14
```
