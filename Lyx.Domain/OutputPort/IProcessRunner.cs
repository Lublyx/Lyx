namespace Lyx.Domain.OutputPort;

public interface IProcessRunner
{
    public string Start(string argument, string workingDirectory);
}