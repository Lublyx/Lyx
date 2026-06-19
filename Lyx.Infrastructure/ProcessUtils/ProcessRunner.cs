using System.Diagnostics;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Infrastructure.ProcessUtils;

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
        try
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
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }
}