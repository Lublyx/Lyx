using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Python;

public class PythonPyGames : Python
{
    private const string _pygame = "pygame";

    public override bool Init(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        if (!base.Init(process, projectDirectory)) return false;
        SetUpVenv(_pygame);
        CreateTemplateFile(ProjectsTemplates.Python.PyGame);

        return true;
    }
}