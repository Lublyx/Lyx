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
                else CreateCase(args[1]);
                break;
            case "list":
                break;
            default:
                Console.WriteLine($"commande {args[0]} inconnu\nVoir `lyx help` pour plus d'information");
                break;
        }

        Environment.Exit(0);
    }

    private static void CreateCase(string projectType)
    {
        switch (projectType.ToLower())
        {
            case "python":
                Console.Write("Nom du projet : ");
                string projectName = Console.ReadLine() ?? "default";
                PythonInfo pythonInfo = new PythonInfo(){Name = projectName, Option = " "};
                _libsGlobal.InitProject<PythonInfo>(new ProjectInfo<PythonInfo>(){ProjectInfos = pythonInfo, Type = _projectTypes.Python});
                break;
            default:
                Console.WriteLine($"commande {projectType} inconnu\nVoir `lyx help` pour plus d'information");
                break;
        }   
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
