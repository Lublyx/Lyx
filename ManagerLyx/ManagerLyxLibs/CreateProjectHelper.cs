using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerCommon;


namespace ProjectManagerLibs
{
    public class CreateProjectHelper
    {
        private IProjectTypes _projecttypes = new IProjectTypes();
        private string _currentDirectory = Directory.GetCurrentDirectory();

        public void InitProject(IProjectInfo project)
        {
            _currentDirectory = Path.Combine(_currentDirectory, project.Name);
            Directory.CreateDirectory(_currentDirectory);
          
            if (project.IsPython()) InitPython(project);
            else if (project.IsHtml()) InitHtml(project);
            else if (project.IsPhp()) InitPhp(_currentDirectory);

        }

        private void InitPython(IProjectInfo project)
        {
            File.Create(Path.Combine(_currentDirectory, "main.py"));
        }

        private void InitHtml(IProjectInfo project)
        {
            StringBuilder htmlbody = new StringBuilder();
            StreamWriter fs = new StreamWriter(File.Create(Path.Combine(_currentDirectory, "index" + ".html")));

            string css = "";
            string js = "";
            if (projectoptions[0])
            {
                StreamWriter fscss = new StreamWriter(File.Create(Path.Combine(_currentDirectory, "style" + ".css")));
                css = "<link rel='stylesheet' type='text/css' media='screen' href='style.css'>";
                fscss.Close();
            }
            if (projectoptions[1])
            {
                StreamWriter fsjs = new StreamWriter(File.Create(Path.Combine(_currentDirectory, "main" + ".js")));
                js = "<script src='main.js'></script>";
                fsjs.Close();
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
    {css}
    {js}
</head>
<body>
    
</body>
</html>
            
");

            fs.Write(htmlbody);
            fs.Close();

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
