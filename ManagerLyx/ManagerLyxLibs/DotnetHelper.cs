using System.Text.RegularExpressions;
using ManagerLyxLibs;

namespace ProjectManagerLibs
{
    public class DotnetHelper
    {

        private ProcessHelper _processHelper = new ProcessHelper();
        private string _currentDirectory = Directory.GetCurrentDirectory();


        #region Methode


        public Dictionary<string, string> GetDotnetOptions()
        {
            Dictionary<string, string> projectNameKeyList = new Dictionary<string, string>();
            string commandargs = "dotnet new list --type Project";
            string StrProj = _processHelper.CommandExecute(commandargs, _currentDirectory);
            Regex regex = new Regex(@"^(.*?)\s{2,}(.*?)\s{2,}");
            foreach (string line in StrProj.Split('\n'))
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string key = match.Groups[2].Value;

                    if (name != "" && key != "")
                    {
                        projectNameKeyList.Add(key, name);
                    }
                }
            }
            projectNameKeyList.Remove("----------------------------------");
            projectNameKeyList.Remove("Nom court");

            return projectNameKeyList;
        }


        public List<string> GetDotnetVersion()
        {
            List<string> dotnetVersion = new List<string>();
            string commandargs = "dotnet --list-runtimes";
            string StrVers = _processHelper.CommandExecute(commandargs, _currentDirectory);
            Regex regex = new Regex(@"((\d{1}.\d{1}).\d{1,})");
            foreach (string line in StrVers.Split('\n'))
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    if (!dotnetVersion.Contains(match.Groups[2].Value)) dotnetVersion.Add(match.Groups[2].Value);
                }
            }
            return dotnetVersion;
        }


        #endregion Methode


    }
}

// "^(.*?)\s{2,}(.*?)\s{2,}"
// dotnet --list-runtimes
// dotnet new list --type Project
// dotnet sln MyProjTest.sln add -s proj proj\proj.csproj
// dotnet new console -n test -f net8.0