using System.Runtime.CompilerServices;
using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Python;

public class Python : IProjectInfo
{
    public required string ProjectName { get; set; }
    public string ProjectPath { get; set; } = string.Empty;
    private string _projectDirectory = string.Empty;
    private IProcessRunner? _process;

    public virtual bool Init(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        _process = process;

        _projectDirectory = projectDirectory.CreateDirectory(ProjectName, ProjectPath);
        if (string.IsNullOrEmpty(_projectDirectory)) return false;
        
        CreateTemplateFile(ProjectsTemplates.Python.Native);

        return true;
    }

    protected void SetUpVenv(string pythonLibrary)
    {
        if (EnvironmentInfo.IsLinux() || EnvironmentInfo.IsOsx())
            _process?.Start($"python3 -m venv .venv && source .venv/bin/activate && pip install --upgrade pip && pip install {pythonLibrary}", _projectDirectory);
        else if (EnvironmentInfo.IsWindows())
            _process?.Start($@"python3 -m venv .venv && .venv\Scripts\activate && pip install --upgrade pip && pip install {pythonLibrary}", _projectDirectory);
    }

    protected void CreateTemplateFile(string template)
    {
        File.WriteAllText(Path.Combine(_projectDirectory, "Main.py"), template);
    }
}