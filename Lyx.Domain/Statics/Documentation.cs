using System.Reflection.Metadata;

namespace Lyx.Domain.Statics;

public static class Documentation
{
    public static readonly string Helper = @"
**Utilisation :**
`lyx [commande] (option) (valeur)`

**Commande :**
- `create` [option] : `Creation du projet spécifier`
- `list` (option)   : `Liste les projets disponible ou les différentes options de création suivant le langague choisi`

**Options :**
- `projectName` : `Le nom du projet à créé, optensible avec `lyx list` ` 

**Exemple d'utilisation :**
`lyx create python flask` : `Créé un projet flask python`
    ";

    public static readonly string PythonProjects = @"
**Projet Python disponnible :**
- `flask` : `Permet de créé un project Python avec Flask pré-installer dans un envrionement virtuel`
- `pygame` : `Permet de créé un project Python avec PyGame pré-installer dans un envrionement virtuel`
    ";

    public static readonly string HtmlProjects = @"
**Projet Html disponnible :**
- `javascript` : `Permet de créé un project web en HTML/CSS avec javascript`
- `typescript` : `Permet de créé un project web en HTML/CSS avec typescript pré-configurer (Node.js doit être installé !!)`
    ";

    public static readonly string PhpProjects = @"
**Projet Php disponnible :**
- `laravel` : `Permet de créé un project php avec le framework laravel (laravel doit être installé !!)`
- `symfony` : `Permet de créé un project php avec le framework symfony (symfony doit être installé !!)`
    ";

    public static readonly string Projects = @"
**Projet disponnible :**
- `python` (option) : `Permet de créé un project Python`
- `html` (option) : `Permet de créé un project web en HTML et CSS`
- `php` (option) : `Permet de créé un project web en PHTML/CSS et PHP`
    ";

    public static void DisplayWelcome()
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
}