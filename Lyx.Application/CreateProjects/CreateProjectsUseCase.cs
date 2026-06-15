using Lyx.Domain.InputPort;
using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;

namespace Lyx.Application.CreateProjects;

public class CreateProjectsUseCase : ICreateProjectsUserCase
{
    private readonly IProcessRunner _process;

    public CreateProjectsUseCase(IProcessRunner process)
    {
        _process = process;
    }

    public bool Create(IProjectInfo projectInfo)
    {
        return projectInfo.Init(_process);
    }
}