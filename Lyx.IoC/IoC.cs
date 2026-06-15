using Lyx.Application.CreateProjects;
using Lyx.Domain.InputPort;
using Lyx.Domain.OutputPort;
using Lyx.Infrastructure.Utilites;
using Microsoft.Extensions.DependencyInjection;

namespace Lyx.IoC;

public static class IoC
{
    public static void Init(ServiceCollection services)
    {
        services.AddSingleton<IProcessRunner, ProcessRunner>();
        services.AddSingleton<ICreateProjectsUserCase, CreateProjectsUseCase>();
    }
}