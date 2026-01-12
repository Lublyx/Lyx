using System;
using System.Diagnostics;

namespace ManagerLyxLibs;

public class ProcessHelper
{
    private SystemHelper _systemHelper = new SystemHelper();
    private string _bash = "";
    private string _bashOption = "";

    public ProcessHelper()
    {
        if (_systemHelper.IsLinux())
        {
            _bash = "/bin/bash";
            _bashOption = "-c";
        }
        else if (_systemHelper.IsWindows())
        {
            _bash = "cmd.exe";
            _bashOption = "/c";
        }
    }
    public string CommandExecute(string argument, string currentDirectory)
    {
        if (_systemHelper.IsLinux())
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
                WorkingDirectory = currentDirectory,
            },
        };

        process.Start();
        string output = process.StandardOutput.ReadToEnd();

        return output;
    }
}
