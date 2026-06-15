using Lyx.Domain.OutputPort;

namespace Lyx.Domain.Entity.Python;

public class PythonPyGames : Python
{
    private const string _pygame = "pygame";

    public override bool Init(IProcessRunner process)
    {
        base.Init(process);

        base.SetUpVenv(_pygame);

        return true;
    }
}