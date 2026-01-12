using System;
using System.Text;
using ManagerLyxCommon;
using ProjectManagerCommon;

namespace ManagerLyxLibs;

public class HtmlHelper
{

    public void InitHtml(HtmlInfo? project, string currentDirectory)
    {
        if (project == null)
        {
            return;
        }

        StringBuilder htmlbody = new StringBuilder();
        FileStream fs = new FileStream(Path.Combine(currentDirectory, "index.html"), FileMode.Create);
        File.Create(Path.Combine(currentDirectory, "style.css"));

        string import = "";
        if (project.IsJavaScript())
        {
            File.Create(Path.Combine(currentDirectory, "main.js"));
            import = "<script src='main.js'></script>";
        }
        else if (project.IsTypeScript())
        {
            try
            {
                FileStream fsConfig = new FileStream(Path.Combine(currentDirectory, "tsconfig.json"), FileMode.Create);   //(File.Create(Path.Combine(currentDirectory, "index" + ".html")));
                string tsConfig = @"
                {
	""compilerOptions"": {
		""target"": ""es6"",
		""module"": ""es6"",
		""strict"": true, // Active toutes les vérifications strictes
		""noImplicitAny"": true, // Empêche l'utilisation implicite de 'any'
		""strictNullChecks"": true, // Vérifie les null/undefined
		""strictFunctionTypes"": true, // Vérifie la compatibilité des fonctions
		""strictBindCallApply"": true, // Vérifie l’utilisation correcte de bind/call/apply
		""noImplicitThis"": true, // Interdit les 'this' implicites
		""alwaysStrict"": true, // Génère du code JS avec 'use strict'
		""esModuleInterop"": true,
		""forceConsistentCasingInFileNames"": true,
		""outDir"": ""./dist"",
		""rootDir"": ""./src"",
		""sourceMap"": true
	},
	""include"": [""src/**/*""],
	""exclude"": [""node_modules""]
}
                ";
                fsConfig.Write(Encoding.ASCII.GetBytes(tsConfig));
                fsConfig.Close();

                import = "<script src='dist/main.js' type='module'></script>";
                Directory.CreateDirectory(Path.Combine(currentDirectory, "dist"));
                string srcDirectory = Path.Combine(currentDirectory, "src");
                Directory.CreateDirectory(srcDirectory);
                File.Create(Path.Combine(srcDirectory, "main.ts"));
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur lors de la création du projet, TypeScript n'est pas installer");
            }
        }


        htmlbody.Append(
$@"
<!DOCTYPE html>
<html lang='fr'>
<head>
    <meta charset='utf-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <title>Page Title</title>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <link rel='stylesheet' type='text/css' media='screen' href='style.css'>
</head>
<body>
    

    {import}
</body>
</html>
            
");

        fs.Write(Encoding.ASCII.GetBytes(htmlbody.ToString()));
        fs.Close();
    }
}
