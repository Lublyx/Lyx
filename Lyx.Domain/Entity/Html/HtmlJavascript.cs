using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Domain.Entity.Html;

public class HtmlJavascript : Html
{

    public override bool Init(IProcessRunner process, IProjectDirectory projectDirectory)
    {
        if (!base.Init(process, projectDirectory)) return false;

        CreateTemplateFile();
        return true;
    }

    private void CreateTemplateFile()
    {
        CreateTemplateFile("index.html", ProjectsTemplates.Html.NativeHtml(true));
        CreateTemplateFile("script.js", ProjectsTemplates.Html.JavaScript);
    }
}