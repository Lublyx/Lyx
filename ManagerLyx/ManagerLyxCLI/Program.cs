using System.Formats.Asn1;
using ManagerLyxCommon;
using ProjectManagerCommon;
using ProjectManagerLibs;

class Program
{
    private static LibsGlobal _libsGlobal = new LibsGlobal();
    private static ProjectTypes _projectTypes = new ProjectTypes();
    public static void Main(string[] args)
    {
        if (args.Count() == 0)
        {
            DisplayWelcome();
            Environment.Exit(0);
        }

        switch (args[0].ToLower())
        {
            case "help":
                DisplayHelper();
                break;
            case "create":
                if (args.Count() <= 1)
                {
                    Console.WriteLine("Aucun agument trouver pour la commande create");
                    Environment.Exit(1);
                }
                else if (args.Count() == 3) CreateCase(args[1], args[2]);
                else CreateCase(args[1]);
                break;
            case "list":
                if (args.Count() == 2) ListProject(args[1]);
                else ListProject();
                break;
            default:
                Console.WriteLine($"commande {args[0]} inconnu\nVoir `lyx help` pour plus d'information");
                break;
        }

        Environment.Exit(0);
    }

    private static void ListProject(string projectType = "")
    {
        switch (projectType)
        {
            case "python":
                Console.WriteLine(@"
**Projet Python disponnible :**
- `flask` : `Permet de créé un project Python avec Flask pré-installer dans un envrionement virtuel`
- `pygame` : `Permet de créé un project Python avec PyGame pré-installer dans un envrionement virtuel`
        ");
                break;
            case "html":
                Console.WriteLine(@"
**Projet Html disponnible :**
- `javascript` : `Permet de créé un project web en HTML/CSS avec javascript`
- `typescript` : `Permet de créé un project web en HTML/CSS avec typescript pré-configurer (Node.js doit être installé !!)`
        ");
                break;
            case "php":
            Console.WriteLine(@"
**Projet Php disponnible :**
- `laravel` : `Permet de créé un project php avec le framework laravel (laravel doit être installé !!)`
- `symfony` : `Permet de créé un project php avec le framework symfony (symfony doit être installé !!)`
        ");
            break;
            default:
                Console.WriteLine(@"
**Projet disponnible :**
- `python` (option) : `Permet de créé un project Python`
- `html` (option) : `Permet de créé un project web en HTML et CSS`
- `php` (option) : `Permet de créé un project web en PHTML/CSS et PHP`
        ");
                break;
        }
    }

    private static void CreateCase(string projectType, string projectOption = "")
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

    private static void CreatePython(string projectOption)
    {
        Console.Write("Nom du projet : ");
        string projectName = Console.ReadLine() ?? "default";
        EnumOptions.PythonOptions option;
        switch (projectOption.ToLower())
        {
            case "flask":
                option = EnumOptions.PythonOptions.flask;
                break;
            case "pygame":
                option = EnumOptions.PythonOptions.pygame;
                break;
            default:
                option = EnumOptions.PythonOptions.vanilla;
                break;
        }
        PythonInfo pythonInfo = new PythonInfo() { Name = projectName, Option = option };
        _libsGlobal.InitProject<PythonInfo>(new ProjectInfo<PythonInfo>() { ProjectInfos = pythonInfo, Type = _projectTypes.Python });
    }

    private static void CreateHtml(string projectOption)
    {
        Console.Write("Nom du projet : ");
        string projectName = Console.ReadLine() ?? "default";
        EnumOptions.HtmlOptions option;
        switch (projectOption.ToLower())
        {
            case "javascript":
                option = EnumOptions.HtmlOptions.javascript;
                break;
            case "typescript":
                option = EnumOptions.HtmlOptions.typescript;
                break;
            default:
                option = EnumOptions.HtmlOptions.vanilla;
                break;
        }
        HtmlInfo htmlInfo = new HtmlInfo() { Name = projectName, Option = option };
        _libsGlobal.InitProject<HtmlInfo>(new ProjectInfo<HtmlInfo>() { ProjectInfos = htmlInfo, Type = _projectTypes.Html });
    }

    private static void CreatePhp(string projectOption)
    {
        Console.WriteLine("Nom du projet : ");
        string projectName = Console.ReadLine() ?? "default";
        EnumOptions.PhpOptions option;
        switch (projectOption.ToLower())
        {
            case "laravel":
                option = EnumOptions.PhpOptions.laravel;
                break;
            case "symfony":
                option = EnumOptions.PhpOptions.symfony;
                break;
            default:
                option = EnumOptions.PhpOptions.vanilla;
                break;
        }
        PhpInfo phpInfo = new PhpInfo(){Name = projectName, Options = option};
        _libsGlobal.InitProject<PhpInfo>(new ProjectInfo<PhpInfo>() {ProjectInfos = phpInfo, Type = _projectTypes.Php});
    }

    private static void DisplayWelcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
            ██╗     ██╗   ██╗██╗  ██╗
            ██║     ╚██╗ ██╔╝╚██╗██╔╝
            ██║      ╚████╔╝  ╚███╔╝ 
            ██║       ╚██╔╝   ██╔██╗ 
            ███████╗   ██║   ██╔╝ ██╗
            ╚══════╝   ╚═╝   ╚═╝  ╚═╝
");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("                     lyx v1.0\n");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("    ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("    lyx, gestionnaire de création de projet\n");
        Console.WriteLine("   'lyx help' pour afficher la documentation\n");

        Console.ResetColor();
    }

    private static void DisplayHelper()
    {
        Console.WriteLine(@"
**Utilisation :**
`lyx [commande] (option) (valeur)`

**Commande :**
- `create` [option] : `Creation du projet spécifier`
- `list` (option)   : `Liste les projets disponible ou les différentes options de création suivant le langague choisi`

**Options :**
- `projectName` : `Le nom du projet à créé, optensible avec `lyx list` ` 

**Exemple d'utilisation :**
`lyx create python flask` : `Créé un projet flask python`
        ");
    }
}
