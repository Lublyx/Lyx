using Lyx.Application.CreateProjects;
using Lyx.Application.ListProjects;
using Lyx.Domain.InputPort;
using Lyx.Domain.OutputPort;
using Lyx.Infrastructure.DirectoryUtils;
using Lyx.Infrastructure.ProcessUtils;
using Microsoft.Extensions.DependencyInjection;

namespace Lyx.IoC;

public static class IoC
{
    public static void Init(ServiceCollection services)
    {
        services.AddSingleton<IProcessRunner, ProcessRunner>();
        services.AddSingleton<ICreateProjectsUserCase, CreateProjectsUseCase>();
        services.AddSingleton<IProjectDirectory, ProjectDirectory>();
        services.AddSingleton<IListProjectsUseCase, ListProjectsUseCase>();
    }
}