// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Text;
// using System.Text.RegularExpressions;
// using System.Threading.Tasks;
// using System.Xml;
// using Newtonsoft.Json;
// using ProjectManagerCommon;

// namespace ProjectManagerLibs
// {
//     public class DotnetHelper
//     {

//         private Dictionary<string, string> ProjectNameKeyList = new Dictionary<string, string>();

//         #region Methode

//         public ISOdotnet LoadDotnetInfo()
//         {
//             string commandargs = "dotnet new list --type Project";
//             string StrProj = CommandExecute(commandargs);
//             Regex regex = new Regex(@"^(.*?)\s{2,}(.*?)\s{2,}");
//             foreach (string line in StrProj.Split('\n'))
//             {
//                 Match match = regex.Match(line);
//                 if (match.Success)
//                 {
//                     string name = match.Groups[1].Value;
//                     string key = match.Groups[2].Value;

//                     if (name != "" && key != "")
//                     {
//                         ProjectNameKeyList.Add(key, name);
//                     }
//                 }
//             }
//             ProjectNameKeyList.Remove("----------------------------------");
//             ProjectNameKeyList.Remove("Nom court");

//             ISOdotnet _dotnetinfo = new ISOdotnet
//             {
//                 ProjectNameKeyList = ProjectNameKeyList,
//                 Version = GetDotnetVersion(),
//             };

//             return _dotnetinfo;
//         }


//         private List<string> GetDotnetVersion()
//         {
//             List<string> dotnetVersion = new List<string>();
//             string commandargs = "dotnet --list-runtimes";
//             string StrVers = CommandExecute(commandargs);
//             Regex regex = new Regex(@"((\d{1}.\d{1}).\d{1,})");
//             foreach (string line in StrVers.Split('\n'))
//             {
//                 Match match = regex.Match(line);
//                 if (match.Success)
//                 {
//                     if (!dotnetVersion.Contains(match.Groups[2].Value)) dotnetVersion.Add(match.Groups[2].Value);
//                 }
//             }
//             return dotnetVersion;
//         }




//         private string CommandExecute(string argument)
//         {

//             Process process = new Process()
//             {
//                 StartInfo = new ProcessStartInfo
//                 {
//                     FileName = "cmd.exe",
//                     Arguments = @$"/c {argument}",
//                     CreateNoWindow = true,
//                     RedirectStandardOutput = true,
//                     UseShellExecute = false,
//                 },
//             };


//             process.Start();

//             string output = process.StandardOutput.ReadToEnd();



//             return output;
//         }



//         #endregion Methode


//     }
// }

// // "^(.*?)\s{2,}(.*?)\s{2,}"
// // dotnet --list-runtimes
// // dotnet new list --type Project
// // dotnet sln MyProjTest.sln add -s proj proj\proj.csproj
// // dotnet new console -n test -f net8.0