using System;
using System.Reflection.Metadata.Ecma335;

namespace ManagerLyxCommon;

public class PhpInfo : IProjectBase
{

    public required string Name {get; set;}

    public required EnumOptions.PhpOptions Options {get; set;}

    public bool IsLaravel()
    {
        return Options == EnumOptions.PhpOptions.laravel;
    }

    public bool IsSymfony()
    {
        return Options == EnumOptions.PhpOptions.symfony;
    }

}
