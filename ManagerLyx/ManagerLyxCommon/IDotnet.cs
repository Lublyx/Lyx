using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerCommon
{
    public class IDotnet
    {

        public required List<string> Version { get; set; }
        public required Dictionary<string, string> ProjectNameKeyList { get; set; }

    }
}
