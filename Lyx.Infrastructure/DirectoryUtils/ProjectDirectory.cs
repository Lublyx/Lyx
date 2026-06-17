using System.Reflection.Metadata;
using Lyx.Domain.OutputPort;
using Lyx.Domain.Statics;

namespace Lyx.Infrastructure.DirectoryUtils;

public class ProjectDirectory : IProjectDirectory
{

    public string CreateDirectory(string projectName, string projectPath)
    {
        string projectDirectory;
        if (string.IsNullOrEmpty(projectPath))
        {
            projectDirectory = Path.Combine(EnvironmentInfo.GetCurrentDirectory(), projectName);
        }
        else
        {
            projectDirectory = Path.Combine(projectPath, projectName);
        }
        if (Directory.Exists(projectDirectory))
        {
            Console.WriteLine($"Le dossier {projectName}, existe déjà à l'emplacement : ${projectDirectory}");
            return string.Empty;
        }
        Directory.CreateDirectory(projectDirectory);
        return projectDirectory;
    }
}