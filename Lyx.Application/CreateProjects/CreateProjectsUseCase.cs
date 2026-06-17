using Lyx.Domain.InputPort;
using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;

namespace Lyx.Application.CreateProjects;

public class CreateProjectsUseCase : ICreateProjectsUserCase
{
    private readonly IProcessRunner _process;
    private readonly IProjectDirectory _projectDirectory;

    public CreateProjectsUseCase(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        _process = process;
        _projectDirectory = projectDirectory;
    }

    public bool Create(IProjectInfo projectInfo)
    {
        return projectInfo.Init(_process, _projectDirectory);
    }
}