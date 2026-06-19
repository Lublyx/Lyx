using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Dotnet;

public class Dotnet : IProjectInfo
{
    public required string SolutionName {get; set;}
    public required string ProjectName {get; set;}
    public required string ProjectPath {get; set;}
    public required string ApplicationType {get; set;}
    private IProcessRunner? _process;
    private IProjectDirectory? _directory;
    private string? _workingDirectory;

    public bool Init(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        _process = process;
        _directory = projectDirectory;
        _workingDirectory = projectDirectory.CreateDirectory(SolutionName, ProjectPath);
        CreateSolution();
        if (!string.IsNullOrEmpty(ProjectName))
            CreateProject();

        return true;
    }

    private void CreateSolution()
    {
     _process?.Start("dotnet new sln", _workingDirectory!);   
    }

    private void CreateProject()
    {
        string projectDirectory = _directory!.CreateDirectory(ProjectName, _workingDirectory!);
        _process!.Start($"dotnet new {ApplicationType}", projectDirectory);
        string slnPath = Path.Combine(_workingDirectory!, SolutionName+".sln");
        _process!.Start($"dotnet sln {slnPath} add {projectDirectory}", _workingDirectory!);
    }
}