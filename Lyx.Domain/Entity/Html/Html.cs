using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Html;

public class Html : IProjectInfo
{
    public required string ProjectName {get; set;}
    public required string ProjectPath {get; set;}
    protected IProcessRunner? _process;
    private string _projectDirectory = string.Empty;

    public virtual bool Init(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        _process = process;
        _projectDirectory = projectDirectory.CreateDirectory(ProjectName, ProjectPath);
        if (string.IsNullOrWhiteSpace(_projectDirectory)) return false;

        CreateTemplateFile("index.html", ProjectsTemplates.Html.NativeHtml());
        File.Create(Path.Combine(_projectDirectory, "style.css"));

        return true;
    }

    protected void CreateTemplateFile(string fileName, string template)
    {
        File.WriteAllText(Path.Combine(_projectDirectory, fileName), template);
    }
}