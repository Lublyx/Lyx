using System;
using System.Runtime.InteropServices;

namespace ManagerLyxLibs;

public class SystemHelper
{

    public bool IsWindows()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
    public bool IsLinux()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    } 
       public bool IsOsx()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
    }
}
