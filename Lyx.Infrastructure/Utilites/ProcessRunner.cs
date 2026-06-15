using System.Diagnostics;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Infrastructure.Utilites;

public class ProcessRunner : IProcessRunner
{
    private readonly string _bash;
    private readonly string _bashOption;

    public ProcessRunner()
    {
        if (EnvironmentInfo.IsLinux() || EnvironmentInfo.IsOsx())
        {
            _bash = "/bin/bash";
            _bashOption = "-c";
        }
        else
        {
            _bash = "cmd.exe";
            _bashOption = "/c";
        }
    }
    public string Start(string argument, string workingDirectory)
    {
        if (EnvironmentInfo.IsLinux() || EnvironmentInfo.IsOsx())
        {
            argument = $"\"{argument}\"";
        }

        Process process = new Process()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = $"{_bash}",
                Arguments = $"{_bashOption} {argument}",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WorkingDirectory = workingDirectory,
            },
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd();

        return output;
    }
}