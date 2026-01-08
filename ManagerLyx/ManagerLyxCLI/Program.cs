

class Program
{
    public static void Main(string[] args)
    {
        if (args.Count() == 0)
        {
            DisplayWelcome();
            Environment.Exit(1);
        }

        switch (args[0].ToLower())
        {
            case "help":
                DisplayHelper();
                break;
            default:
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
