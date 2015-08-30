[T4Scaffolding.Scaffolder(Description = "Enter a description of Repositories here")][CmdletBinding()]
param(        
    [string]$Project,	
	[string[]]$outputfolder = $filePath,		
	[string]$nameSpace = $NameSpace,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

foreach($p in $outputfolder) 
{ 
	$outputPath = "repositories\" + $p + "RepositoryBLL"  # The filename extension will be added based on the template's <#@ Output Extension="..." #> directive
	$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value	

	IF($nameSpace.Length -gt 0) 
	{
		$defaultNamespace = $nameSpace
	}

	Add-ProjectItemViaTemplate $outputPath -Template RepositoriesTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added RepositoriesBLL output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force
} 
