using ManagerLyxCommon;

namespace ProjectManagerCommon
{
    public class ProjectInfo<T> where T : IProjectBase
    {
        public required T ProjectInfos {get; set;} //can be of type : (IPythonInfo, IHtmlInfo, IPhpInfo, IDotnetInfo)
        public required string Type { get; set; }
        private ProjectTypes _projectTypes = new ProjectTypes();
        
        public bool IsPython()
        {
            return Type == _projectTypes.Python;
        }
    
        public bool IsHtml()
        {
            return Type == _projectTypes.Html;
        }
        
        public bool IsPhp()
        {
            return Type == _projectTypes.Php;
        }

        public bool IsCs()
        {
            return Type == _projectTypes.CS;
        }

        public bool IsC()
        {
            return Type == _projectTypes.C;
        }

        public bool IsBatch()
        {
            return Type == _projectTypes.Batch;
        }
    }
}
