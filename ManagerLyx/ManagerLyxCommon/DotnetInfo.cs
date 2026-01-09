using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerLyxCommon;

namespace ProjectManagerCommon
{
    public class DotnetInfo : IProjectBase
    {
        public required string Name {get; set;}
        public required List<string> Version { get; set; }
        public required Dictionary<string, string> ProjectNameKeyList { get; set; }

    }
}
