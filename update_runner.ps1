$regex = 'PackageReference Include="([^"]*)" Version="([^"]*)"'
$packagesToUpdate = ('SpecRun.SpecFlow')
$projectsToIgnore = ('SpecFlowNewCSProjFormat.csproj')

ForEach ($file in get-childitem . -recurse | where {$_.extension -like "*proj"})
{
	If (!($projectsToIgnore.contains($file.Name)))
	{
		$packages = Get-Content $file.FullName |
			select-string -pattern $regex -AllMatches | 
			ForEach-Object {$_.Matches} | 
			ForEach-Object {$_.Groups[1].Value.ToString()}| 
			sort -Unique

		ForEach ($package in $packages)
		{
			If ($packagesToUpdate.contains($package))
			{
				write-host "Update $file package :$package"  -foreground 'magenta'
				$fullName = $file.FullName
			
				iex "dotnet add $fullName package $package"
			}
		}
	}
}