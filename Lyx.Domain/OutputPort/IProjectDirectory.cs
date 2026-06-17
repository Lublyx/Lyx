namespace Lyx.Domain.OutputPort;

public interface IProjectDirectory
{
    string CreateDirectory(string projectName, string projectPath);
}