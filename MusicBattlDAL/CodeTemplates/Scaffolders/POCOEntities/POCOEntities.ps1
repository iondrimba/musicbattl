[T4Scaffolding.Scaffolder(Description = "Enter a description of POCOEntities here")][CmdletBinding()]
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
	$outputPath = "models\" + $p   # The filename extension will be added based on the template's <#@ Output Extension="..." #> directive
	$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value
	$connection = "Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456"


	IF($nameSpace.Length -gt 0) 
	{
		$defaultNamespace = $nameSpace
	}

	Add-ProjectItemViaTemplate $outputPath -Template POCOEntitiesTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection=$connection;} `
		-SuccessMessage "Added POCOEntities output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

	$outputPath = "models\interfaces\I" + $p
	$defaultNamespace = $defaultNamespace+".models"
	Add-ProjectItemViaTemplate $outputPath -Template POCOEntitiesTemplateInterface `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection=$connection;} `
		-SuccessMessage "Added POCOEntities Interfaces output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force
} 
