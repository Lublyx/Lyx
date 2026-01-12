using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerLyxCommon;
using ManagerLyxLibs;
using ProjectManagerCommon;


namespace ProjectManagerLibs
{
    public class CreateProjectHelper
    {
        private ProjectTypes _projecttypes = new ProjectTypes();
        private PythonHelper _pythonHelper = new PythonHelper();
        private HtmlHelper _htmlHelper = new HtmlHelper();
        private string _currentDirectory = Directory.GetCurrentDirectory();

        public void InitProject<T>(ProjectInfo<T> project) where T : IProjectBase
        {
            _currentDirectory = Path.Combine(_currentDirectory, project.ProjectInfos.Name);
            
            if (Directory.Exists(_currentDirectory))
            {
                Console.WriteLine($"Le dossier {project.ProjectInfos.Name} existe déjà");
                return;
            }

            Directory.CreateDirectory(_currentDirectory);
            if (project.IsPython()) _pythonHelper.InitPython(project.ProjectInfos as PythonInfo, _currentDirectory);
            else if (project.IsHtml()) _htmlHelper.InitHtml(project.ProjectInfos as HtmlInfo, _currentDirectory);
            else if (project.IsPhp()) InitPhp(_currentDirectory);

        }

       

        


        private void InitPhp(string ProjectFullPath)
        {
            StringBuilder bodyphtml = new StringBuilder();
            StringBuilder bodyphp = new StringBuilder();
            StreamWriter fsphtml = new StreamWriter(File.Create(Path.Combine(ProjectFullPath, "index" + ".phtml")));
            StreamWriter fsphp = new StreamWriter(File.Create(Path.Combine(ProjectFullPath, "index" + ".php")));
            StreamWriter fscss = new StreamWriter(File.Create(Path.Combine(ProjectFullPath, "style" + ".css")));
            fscss.Close();
            bodyphtml.Append($@"
<!DOCTYPE html>
<html lang='fr'>

<head>
	<meta charset='utf-8'>
	<title>PHP</title>
	<link rel='stylesheet' href='style.css'>
</head>

<body>


</body>
");
            bodyphp.Append($@"
<?php

include 'index.phtml';



?>
");
            fsphtml.Write(bodyphtml);
            fsphtml.Close();
            fsphp.Write(bodyphp);
            fsphp.Close();

        }

    }
}
