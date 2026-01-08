namespace ProjectManagerCommon
{
    public class IProjectInfo
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Option {get; set;}
        private IProjectTypes _projectTypes = new IProjectTypes();
        
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
