using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lyx.Domain.Entity.Dotnet;
using Lyx.Domain.Entity.Html;
using Lyx.Domain.Entity.Python;
using Lyx.Domain.InputPort;
using Lyx.Domain.Interfaces;
using Lyx.Domain.Statics;

namespace Lyx.CLI;

public class App(ICreateProjectsUserCase projects, IListProjectsUseCase listProjects)
{
    private readonly ICreateProjectsUserCase _projects = projects;
    private readonly IListProjectsUseCase _listProjects = listProjects;

    public void Run(string[] args)
    {
        if (args.Length == 0)
        {
            Documentation.DisplayWelcome();
            Environment.Exit(0);
        }
        _listProjects.GetProjectsOptions();

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
            case "dotnet":
                Console.WriteLine(Documentation.DotnetProjects);
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
            case "dotnet":
                CreateDotnet(projectOption);
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
        if (_projects.Create(python)) Success();
    }

    private void CreateHtml(string projectOption)
    {
        Console.Write("Nom du projet : ");
        string projectName = Console.ReadLine() ?? "default";
        IProjectInfo html;
        switch (projectOption.ToLower())
        {
            case "javascript":
                html = new HtmlJavascript(){ProjectName = projectName, ProjectPath = EnvironmentInfo.GetCurrentDirectory()};
                break;
            case "typescript":
                html = new HtmlTypescript(){ProjectName = projectName, ProjectPath = EnvironmentInfo.GetCurrentDirectory()};
                break;
            default:
                html = new Html(){ProjectName = projectName, ProjectPath = EnvironmentInfo.GetCurrentDirectory()};
                break;
        }
        if (_projects.Create(html)) Success();
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

    private void CreateDotnet(string projectOption)
    {
        Console.WriteLine("Nom de la solution :");
        string solutionName = Console.ReadLine() ?? "default";
        string projectName = string.Empty;
        if (!string.IsNullOrEmpty(projectOption))
        {
            Console.WriteLine("Nom du projet :");
            projectName = Console.ReadLine() ?? string.Empty;
        }
        IProjectInfo dotnet = new Dotnet() {SolutionName = solutionName, ProjectName = projectName, ProjectPath = EnvironmentInfo.GetCurrentDirectory(), ApplicationType = projectOption};

        _projects.Create(dotnet);
    }

    public static void Success()
    {
        Console.WriteLine("Projet créé !");
    }

}
