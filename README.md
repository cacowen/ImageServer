https://github.com/aws/aws-extensions-for-dotnet-cli/discussions/364

How can i deploy my .Net 8 AOT AWS Lambda project when the project has a dependency?

Repo: https://github.com/cacowen/ImageServer

To test out the build I was running the sam/build-dotnet8 docker container:
(sha256:c525fda10761fbda5a2c2fc8c7179df01eda0ef1324e32f0fe938f93e3e9b4f2)

Fresh clone from GitHub - never opened in Visual Studio - works as expected:

```
╰─ docker run -v "C:\GitHub\ImageServer:/workspace" -w /workspace/ImageServer public.ecr.aws/sam/build-dotnet8:latest-x86_64 dotnet publish -c Release -o /workspace/ImageServer/bin/Release/net8.0/publish                                                                                                                                                                                                    ─╯
  Determining projects to restore...
  Restored /workspace/LambdaHelpers/LambdaHelpers.csproj (in 2.29 sec).
  Restored /workspace/ImageServer/ImageServer.csproj (in 7.6 sec).
  LambdaHelpers -> /workspace/LambdaHelpers/bin/Release/net8.0/LambdaHelpers.dll
  ImageServer -> /workspace/ImageServer/bin/Release/net8.0/linux-x64/ImageServer.dll
  Generating native code
  ImageServer -> /workspace/ImageServer/bin/Release/net8.0/publish/
  ```

After opening in VisualStudio, before building within vs or after, no difference:

```
╰─ docker run -v "C:\GitHub\ImageServer:/workspace" -w /workspace/ImageServer public.ecr.aws/sam/build-dotnet8:latest-x86_64 dotnet publish -c Release -o /workspace/ImageServer/bin/Release/net8.0/publish                                                                                                                                                                                                    ─╯
  Determining projects to restore...
  Restored /workspace/LambdaHelpers/LambdaHelpers.csproj (in 2.53 sec).
  Restored /workspace/ImageServer/ImageServer.csproj (in 9.02 sec).
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018: The "ResolvePackageAssets" task failed unexpectedly. [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018: NuGet.Packaging.Core.PackagingException: Unable to find fallback package folder 'C:\Program Files (x86)\Microsoft Visual Studio\Shared\NuGetPackages'. [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at NuGet.Packaging.FallbackPackagePathResolver..ctor(String userPackageFolder, IEnumerable`1 fallbackPackageFolders) [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.NET.Build.Tasks.NuGetPackageResolver.CreateResolver(IEnumerable`1 packageFolders) [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.NET.Build.Tasks.ResolvePackageAssets.CacheWriter..ctor(ResolvePackageAssets task) [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.NET.Build.Tasks.ResolvePackageAssets.CacheReader.CreateReaderFromDisk(ResolvePackageAssets task, Byte[] settingsHash) [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.NET.Build.Tasks.ResolvePackageAssets.CacheReader..ctor(ResolvePackageAssets task) [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.NET.Build.Tasks.ResolvePackageAssets.ReadItemGroups() [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.NET.Build.Tasks.ResolvePackageAssets.ExecuteCore() [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.NET.Build.Tasks.TaskBase.Execute() [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.Build.BackEnd.TaskExecutionHost.Execute() [/workspace/LambdaHelpers/LambdaHelpers.csproj]
/var/lang/bin/sdk/8.0.406/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(266,5): error MSB4018:    at Microsoft.Build.BackEnd.TaskBuilder.ExecuteInstantiatedTask(TaskExecutionHost taskExecutionHost, TaskLoggingContext taskLoggingContext, TaskHost taskHost, ItemBucket bucket, TaskExecutionMode howToExecuteTask) [/workspace/LambdaHelpers/LambdaHelpers.csproj]
```

While VisualStudio is still open, removing the OBJ and BIN folders from both projects and trying again results in the same MSB4018 errors as above, but VisualStudio shows the error:

```
A NuGet restore loop has been detected in project 'C:\GitHub\ImageServer\LambdaHelpers\LambdaHelpers.csproj'. Further restores have been aborted. The project might be in a bad state.
```

Running "Publish to AWS Lambda" by right clicking on the ImageServer project and selecting the option provides the same MSB4018 errors.

If I remove the LambdaHelpers dependency (and adjust the code accordingly) I get no errors and things work as expected. I imagine I probably have some configuration setting messing things up, but I do not know what to change. Other threads and searches suggested adding the .dockerignore file, deleting the OBJ and BIN folders, and ensuring the fallback package folder exists, and clearing cache. I did all of these with the same results. I created the repo and steps to reproduce the issue. Tested this on 2 machines with the same results.
