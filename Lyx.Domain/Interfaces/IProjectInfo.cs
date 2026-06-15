using System.Dynamic;
using System.Net.Cache;
using Lyx.Domain.OutputPort;

namespace Lyx.Domain.Interfaces;

public interface IProjectInfo
{
    public string ProjectName {get; set;}
    public string ProjectPath {get; set;}
    public bool Init(IProcessRunner process);
}