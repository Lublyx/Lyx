using System.Runtime.CompilerServices;
using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Python;

public class Python : IProjectInfo
{
    public required string ProjectName { get; set; }
    public string ProjectPath { get; set; } = string.Empty;
    private string projectDirectory = string.Empty;
    private IProcessRunner? _process;

    public virtual bool Init(IProcessRunner process)
    {
        _process = process;
        if (string.IsNullOrEmpty(ProjectPath))
        {
            projectDirectory = Path.Combine(EnvironmentInfo.GetCurrentDirectory(), ProjectName);
            Directory.CreateDirectory(projectDirectory);
        }
        else
        {
            projectDirectory = Path.Combine(ProjectPath, ProjectName);
            Directory.CreateDirectory(projectDirectory);
        }
        
        CreateTemplateFile();

        return true;
    }

    protected void SetUpVenv(string pythonLibrary)
    {
        if (EnvironmentInfo.IsLinux() || EnvironmentInfo.IsOsx())
            _process?.Start($"python3 -m venv .venv && source .venv/bin/activate && pip install --upgrade pip && pip install {pythonLibrary}", projectDirectory);
        else if (EnvironmentInfo.IsWindows())
            _process?.Start($@"python3 -m venv .venv && .venv\Scripts\activate && pip install --upgrade pip && pip install {pythonLibrary}", projectDirectory);
    }

    private void CreateTemplateFile()
    {
        CreateTemplateFile(ProjectsTemplates.Python.Native);
    }

    protected void CreateTemplateFile(string template)
    {
        File.WriteAllText(Path.Combine(projectDirectory, "Main.py"), template);
    }
}