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
	$outputPath = "repositories\" + $p + "Repository"  # The filename extension will be added based on the template's <#@ Output Extension="..." #> directive
	$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value	

	IF($nameSpace.Length -gt 0) 
	{
		$defaultNamespace = $nameSpace
	}

	Add-ProjectItemViaTemplate $outputPath -Template RepositoriesTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added Repositories output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

	$outputPath = "repositories\interfaces\I" + $p + "QueryParams"
	Add-ProjectItemViaTemplate $outputPath -Template IQueryParamsTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added IQueryParamsTemplate output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

	$outputPath = "repositories\queryparams\" + $p + "QueryParams"
	Add-ProjectItemViaTemplate $outputPath -Template QueryParamsTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added QueryParamsTemplate output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

} 
