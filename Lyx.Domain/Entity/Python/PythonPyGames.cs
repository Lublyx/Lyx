using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Python;

public class PythonPyGames : Python
{
    private const string _pygame = "pygame";

    public override bool Init(IProcessRunner process)
    {
        base.Init(process);
        SetUpVenv(_pygame);
        CreateTemplateFile(ProjectsTemplates.Python.PyGame);

        return true;
    }
}