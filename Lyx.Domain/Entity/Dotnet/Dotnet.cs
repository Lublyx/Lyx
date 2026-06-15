using Lyx.Domain.Interfaces;
using Lyx.Domain.OutputPort;

namespace Lyx.Domain.Entity.Dotnet;

public class Dotnet : IProjectInfo
{
    public required string ProjectName {get; set;}
    public required string ProjectPath {get; set;}

    public bool Init(IProcessRunner process)
    {
        
        return true;
    }
}