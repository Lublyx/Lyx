using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ProjectManagerCommon;
using ProjectManagerSQL;

namespace ProjectManagerLibs
{
    public class LibsGeneral
    {
        private COdatabase _codatabase = new COdatabase();
        private CreateProjectHelper _createproject = new CreateProjectHelper();
        private DeleteProjectHelper _deleteproject = new DeleteProjectHelper();
        private LiveServerHelper _liveserver = new LiveServerHelper();
        private DotnetHelper _dotnethelper = new DotnetHelper();

        public IList<ISOproject> LoadProject()
        {
            return _codatabase.LoadProject();
        }

        public ISOsettings LoadSettings()
        {
            return _codatabase.LoadSettings();
        }

        public void SaveSettings(ISOsettings settings)
        {
            _codatabase.SaveSettings(settings);
        }

        public void SaveProject(ISOproject project)
        {
            _codatabase.SaveProject(project);
        }

        public void InitProject(ISOproject ProjectToCreate, dynamic projectattribute)
        {
            _createproject.InitProject(ProjectToCreate, projectattribute);
        }

        public bool delProject(IList<object> ProjectToDelete)
        {
            return _deleteproject.DelProject(ProjectToDelete);
        }

        public void StartServer(string projectPath)
        {
            _liveserver.StartServer(projectPath);
        }

        public ISOdotnet LoadDotnetInfo()
        {
            return _dotnethelper.LoadDotnetInfo();
        }

    }
}
