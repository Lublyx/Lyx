using System;

namespace ManagerLyxCommon;

public class PythonInfo : IProjectBase
{
    public required string Name {get; set;}
    public required EnumOptions.PythonOptions Option {get; set;}

    public bool IsFlask()
    {
        return Option == EnumOptions.PythonOptions.flask;
    }

    public bool IsPygame()
    {
        return Option == EnumOptions.PythonOptions.pygame;
    }
}
