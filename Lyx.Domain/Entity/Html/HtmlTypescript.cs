using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Html;

public class HtmlTypescript : Html
{
    public override bool Init(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        _process = process;
        CreateTypeScriptProject();
        return true;
    }

    private void CreateTypeScriptProject()
    {
        _process?.Start($"""yes | npm create vite@latest {ProjectName} -- --template vanilla-ts 2>/dev/null && cd {ProjectName.ToLower()} && npm install""", EnvironmentInfo.GetCurrentDirectory());
    }
}