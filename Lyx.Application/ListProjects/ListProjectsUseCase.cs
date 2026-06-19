using Lyx.Domain.InputPort;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Application.ListProjects;

public class ListProjectsUseCase(IProcessRunner process) : IListProjectsUseCase
{
    private readonly IProcessRunner _process = process;
    public void GetProjectsOptions()
    {
        GetDotnetAvailableProjects(_process);
    }

    private static void GetDotnetAvailableProjects(IProcessRunner process)
    {
        Documentation.DotnetProjects += process.Start("dotnet new list -lang C# --columns language --type project", EnvironmentInfo.GetCurrentDirectory());
    }
}