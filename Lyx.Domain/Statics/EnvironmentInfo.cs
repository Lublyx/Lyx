using System.Runtime.InteropServices;

namespace Lyx.Domain.Statics;

public static class EnvironmentInfo
{
    public static bool IsWindows()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
    public static bool IsLinux()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
    public static bool IsOsx()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
    }

    public static string GetCurrentDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    public static string GetExecutionDirectory()
    {
        return AppDomain.CurrentDomain.BaseDirectory;
    }
}