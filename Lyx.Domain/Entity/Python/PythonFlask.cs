using Lyx.Domain.OutputPort;

namespace Lyx.Domain.Entity.Python;

public class PythonFlask : Python
{
    private const string _flask = "Flask";

    public override bool Init(IProcessRunner process)
    {
        base.Init(process);

        base.SetUpVenv(_flask);

        return true;
    }
}