using Lyx.Domain.Interfaces;

namespace Lyx.Domain.InputPort;

public interface ICreateProjectsUserCase
{
    public bool Create(IProjectInfo projectInfo);
}