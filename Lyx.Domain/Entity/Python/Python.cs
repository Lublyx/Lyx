using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Python;

public class Python : IProjectInfo
{
    public required string ProjectName { get; set; }
    public string ProjectPath { get; set; } = string.Empty;
    private IProcessRunner? _process;

    public virtual bool Init(IProcessRunner process)
    {
        _process = process;
        if (string.IsNullOrEmpty(ProjectPath))
            Directory.CreateDirectory(Path.Combine(EnvironmentInfo.GetCurrentDirectory(), ProjectName));
        else
            Directory.CreateDirectory(Path.Combine(EnvironmentInfo.GetCurrentDirectory(), ProjectName));

        return true;
    }

    protected void SetUpVenv(string pythonLibrary)
    {
        string workingDirectory = Path.Combine(EnvironmentInfo.GetCurrentDirectory(), ProjectName);

        if (EnvironmentInfo.IsLinux() || EnvironmentInfo.IsOsx())
            _process?.Start($"python3 -m venv .venv && source .venv/bin/activate && pip install --upgrade pip && pip install {pythonLibrary}", workingDirectory);
        else if (EnvironmentInfo.IsWindows())
            _process?.Start($@"python3 -m venv .venv && .venv\Scripts\activate && pip install --upgrade pip && pip install {pythonLibrary}", workingDirectory);
    }
}