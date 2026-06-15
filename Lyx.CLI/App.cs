using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lyx.Domain.Entity.Python;
using Lyx.Domain.InputPort;
using Lyx.Domain.Interfaces;
using Lyx.Domain.Statics;

namespace Lyx.CLI;

public class App
{
    private readonly ICreateProjectsUserCase _projects;
    
    public App(ICreateProjectsUserCase projects)
    {
        _projects = projects;
    }

    public void Run(string[] args)
    {
        if (args.Length == 0)
        {
            Documentation.DisplayWelcome();
            Environment.Exit(0);
        }

        switch (args[0].ToLower())
        {
            case "help":
                Console.WriteLine(Documentation.Helper);
                break;
            case "create":
                if (args.Length <= 1)
                {
                    Console.WriteLine("Aucun agument trouver pour la commande create");
                    Environment.Exit(1);
                }
                else if (args.Length == 3) CreateCase(args[1], args[2]);
                else CreateCase(args[1]);
                break;
            case "list":
                if (args.Length == 2) ListProjects(args[1]);
                else ListProjects();
                break;
            default:
                Console.WriteLine($"commande {args[0]} inconnu\nVoir `lyx help` pour plus d'information");
                break;
        }

        Environment.Exit(0);
    }

    private static void ListProjects()
    {
        Console.WriteLine(Documentation.Projects);
    }
    private static void ListProjects(string projectType)
    {
        switch (projectType.ToLower())
        {
            case "python":
                Console.WriteLine(Documentation.PythonProjects);
                break;
            case "html":
                Console.WriteLine(Documentation.HtmlProjects);
                break;
            case "php":
                Console.WriteLine(Documentation.PhpProjects);
                break;
            default:
                break;
        }
    }

    private void CreateCase(string projectType, string projectOption = "")
    {
        switch (projectType.ToLower())
        {
            case "python":
                CreatePython(projectOption);
                break;
            case "html":
                CreateHtml(projectOption);
                break;
            case "php":
                CreatePhp(projectOption);
                break;
            default:
                Console.WriteLine($"commande {projectType} inconnu\nVoir `lyx help` pour plus d'information");
                break;
        }
    }

    private void CreatePython(string projectOption)
    {
        Console.Write("Nom du projet : ");
        string projectName = Console.ReadLine() ?? "default";
        IProjectInfo python;
        switch (projectOption.ToLower())
        {
            case "flask":
                python = new PythonFlask(){ProjectName = projectName, ProjectPath = EnvironmentInfo.GetCurrentDirectory()};
                break;
            case "pygame":
                python = new PythonPyGames(){ProjectName = projectName, ProjectPath = EnvironmentInfo.GetCurrentDirectory()};
                break;
            default:
                python = new Python(){ProjectName = projectName, ProjectPath = EnvironmentInfo.GetCurrentDirectory()};
                break;
        }
        _projects.Create(python);
    }

    private void CreateHtml(string projectOption)
    {
        // Console.Write("Nom du projet : ");
        // string projectName = Console.ReadLine() ?? "default";
        // EnumOptions.HtmlOptions option;
        // switch (projectOption.ToLower())
        // {
        //     case "javascript":
        //         option = EnumOptions.HtmlOptions.javascript;
        //         break;
        //     case "typescript":
        //         option = EnumOptions.HtmlOptions.typescript;
        //         break;
        //     default:
        //         option = EnumOptions.HtmlOptions.vanilla;
        //         break;
        // }
        // HtmlInfo htmlInfo = new HtmlInfo() { Name = projectName, Option = option };
        // _libsGlobal.InitProject<HtmlInfo>(new ProjectInfo<HtmlInfo>() { ProjectInfos = htmlInfo, Type = _projectTypes.Html });
    }

    private void CreatePhp(string projectOption)
    {
        // Console.WriteLine("Nom du projet : ");
        // string projectName = Console.ReadLine() ?? "default";
        // EnumOptions.PhpOptions option;
        // switch (projectOption.ToLower())
        // {
        //     case "laravel":
        //         option = EnumOptions.PhpOptions.laravel;
        //         break;
        //     case "symfony":
        //         option = EnumOptions.PhpOptions.symfony;
        //         break;
        //     default:
        //         option = EnumOptions.PhpOptions.vanilla;
        //         break;
        // }
        // PhpInfo phpInfo = new PhpInfo() { Name = projectName, Options = option };
        // _libsGlobal.InitProject<PhpInfo>(new ProjectInfo<PhpInfo>() { ProjectInfos = phpInfo, Type = _projectTypes.Php });
    }


}
