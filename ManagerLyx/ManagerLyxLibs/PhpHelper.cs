using System;
using System.Text;
using ManagerLyxCommon;

namespace ManagerLyxLibs;

public class PhpHelper
{
    public void InitPhp(PhpInfo? phpInfo, string currentDirectory)
    {
        if (phpInfo == null)
        {
            return;
        }

        if (phpInfo.IsLaravel())
        {
            this.CreateLaravel(currentDirectory);
        }
        else if (phpInfo.IsSymfony())
        {
            this.CreateSymfony(currentDirectory);
        }
        else
        {
            this.CreateVanilla(currentDirectory);
        }
    }
    
    private void CreateLaravel(string currentDirectory)
    {
        Console.WriteLine("laravel");
    }
    
    private void CreateSymfony(string currentDirectory)
    {
        Console.WriteLine("Symfony");
    }
    
    private void CreateVanilla(string currentDirectory)
    {

        StringBuilder bodyphtml = new StringBuilder();
        StringBuilder bodyphp = new StringBuilder();
        StreamWriter fsphtml = new StreamWriter(File.Create(Path.Combine(currentDirectory, "index" + ".phtml")));
        StreamWriter fsphp = new StreamWriter(File.Create(Path.Combine(currentDirectory, "index" + ".php")));
        StreamWriter fscss = new StreamWriter(File.Create(Path.Combine(currentDirectory, "style" + ".css")));
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
