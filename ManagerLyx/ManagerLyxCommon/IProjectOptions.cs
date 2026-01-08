using System;
using ProjectManagerCommon;

namespace ManagerLyxCommon;

public class IProjectOptions
{
    private IProjectTypes _projectTypes = new IProjectTypes();
    private Dictionary<string, string> _options = new Dictionary<string, string>();

    public Dictionary<string, string> Options {get => _options;}

    public IProjectOptions()
    {
    _options.Add(_projectTypes.Python, "Flask");
    _options.Add(_projectTypes.Html, "js");
    _options.Add(_projectTypes.Html, "TypeScript");

    }
}
