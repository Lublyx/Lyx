using System;
using ManagerLyxCommon;

namespace ManagerLyxLibs;

public class PythonHelper
{
    private ProcessHelper _processHelper = new ProcessHelper();
    private SystemHelper _systemHelper = new SystemHelper();

    public void InitPython(PythonInfo? project, string currentDirectory)
    {
        if (project == null)
        {
            return;
        }

        if (project.IsFlask())
        {
            this.InitVenv("pip install Flask", currentDirectory);
        }
        else if (project.IsPygame())
        {
            this.InitVenv("pip install pygame", currentDirectory);

        }

        File.Create(Path.Combine(currentDirectory, "main.py"));
    }

    public void InitVenv(string modulName, string currentDirectory)
    {
       
    }
}
