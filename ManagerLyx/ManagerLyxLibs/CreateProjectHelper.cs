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
        private PythonHelper _pythonHelper = new PythonHelper();
        private HtmlHelper _htmlHelper = new HtmlHelper();
        private PhpHelper _phpHelper = new PhpHelper();
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
            else if (project.IsPhp()) _phpHelper.InitPhp(project.ProjectInfos as PhpInfo, _currentDirectory);

        }

    }
}
