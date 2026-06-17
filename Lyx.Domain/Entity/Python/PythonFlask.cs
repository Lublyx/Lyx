using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Python;

public class PythonFlask : Python
{
    private const string _flask = "Flask";

    public override bool Init(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        if (!base.Init(process, projectDirectory)) return false;
        SetUpVenv(_flask);
        CreateTemplateFile(ProjectsTemplates.Python.Flask);

        return true;
    }
}