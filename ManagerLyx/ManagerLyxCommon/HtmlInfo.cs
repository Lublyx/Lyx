using System;

namespace ManagerLyxCommon;

public class HtmlInfo : IProjectBase
{
    public required string Name {get; set;}
    public required EnumOptions.HtmlOptions Option {get; set;}

    public bool IsTypeScript()
    {
        return EnumOptions.HtmlOptions.typescript == Option;
    }
    
    public bool IsJavaScript()
    {
        return EnumOptions.HtmlOptions.javascript == Option;
    }
}
