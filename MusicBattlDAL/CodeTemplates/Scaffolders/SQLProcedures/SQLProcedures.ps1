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
	$outputPath =  "Procedures\" + $p   # The filename extension will be added based on the template's <#@ Output Extension="..." #> directive
	$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value

	IF($nameSpace.Length -gt 0) 
	{
		$defaultNamespace = $nameSpace
	}

	$outputPath =  "Procedures\" + $p + "Add"
	Add-ProjectItemViaTemplate $outputPath -Template SQLProceduresAddTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added SQLProceduresAddTemplate output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Forcee

	$outputPath =  "Procedures\" + $p + "Find"
	Add-ProjectItemViaTemplate $outputPath -Template SQLProceduresFindTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added SQLProceduresFindTemplate output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Forcee

	$outputPath =  "Procedures\" + $p + "GetTop"
	Add-ProjectItemViaTemplate $outputPath -Template SQLProceduresGetTopTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added SQLProceduresGetTopTemplate output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Forcee

	$outputPath =  "Procedures\" + $p + "Update"
	Add-ProjectItemViaTemplate $outputPath -Template SQLProceduresUpdateTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added SQLProceduresUpdateTemplate output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Forcee

	$outputPath =  "Procedures\" + $p + "Remove"
	Add-ProjectItemViaTemplate $outputPath -Template SQLProceduresRemoveTemplate `
		-Model @{ Namespace = $defaultNamespace; Name=$p;DefaultConnection="Data Source=ION-WIN7;Initial Catalog=musicbattl-test;Persist Security Info=True;User ID=sa;Password=123456";} `
		-SuccessMessage "Added SQLProceduresRemoveTemplate output at {0}" `
		-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Forcee		
} 

