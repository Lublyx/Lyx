using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ManagerLyxCommon;
using Microsoft.VisualBasic;
using ProjectManagerCommon;

namespace ProjectManagerLibs
{
    public class LibsGlobal
    {
        private CreateProjectHelper _createproject = new CreateProjectHelper();
        private DotnetHelper _dotnetHelper = new DotnetHelper();

   
        public void InitProject<T>(ProjectInfo<T> ProjectToCreate) where T : IProjectBase
        {
            _createproject.InitProject<T>(ProjectToCreate);
        }

        // public ISOdotnet LoadDotnetInfo()
        // {
        //     return _dotnethelper.LoadDotnetInfo();
        // }

    }
}
