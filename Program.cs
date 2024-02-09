using CombatLoader;
using Display;
using InputLoader;
using SaveEditor;
using StoryLoader;
using SoundLoader;

class Program
{
    public static bool quit = false;
    public static int posX = 8;
    public static int posY = 1;
    public static char[,] currentMap = { };
    public static int currentMapIndex = 0;
    public static int NumberOfItem = 0;

    public static void Main()
    {
        InitializeConsole();
        Console.Clear();

        // Initialiser la carte actuelle
        currentMap = Map.InitMap1();
        currentMapIndex = 0;
        Save.LoadGame();

        do
        {
            Console.Clear();
            Menu.main_menu();

            Console.Write("Choisissez une option (1-5): ");
            char choice = Console.ReadKey().KeyChar;

            Input.ProcessChoice(choice, currentMap);

            


        } while (!quit);
    }

    static void InitializeConsole()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.WindowWidth = 60;
            Console.WindowHeight = 20;
        }
    }

    public static void PlayGame()
    {
        Map.AfficherCarte(currentMap);
        Sound.ChangeMusicBasedOnMap(currentMapIndex);

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            Input.MovePlayer(keyInfo, currentMap);
            Console.Clear();
            if (NumberOfItem == 1)
            {
                Story.EndGame();
            }
            Map.AfficherCarte(currentMap);

            // Vérifier si le joueur a rencontré un Pokémon
            if (Combat.fight_end)
            {
                Combat.AfficherCapacitesJoueur(new Biblio.Pokemon("","",0,0,0,0,0, 0, new List<Biblio.Capacite>()));
                int choixAttaque = Combat.DemanderChoixCapacite(0);
                // Faites quelque chose avec le choix d'attaque, par exemple, appliquer des dégâts à l'adversaire
            }
        } while (keyInfo.Key != ConsoleKey.Escape);

    }


    public static void PickUpItem(char[,] carte)
    {
        Console.WriteLine("\nAppuyez sur la touche 'E' pour ramasser l'objet ->");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.E)
        {
            NumberOfItem++;
            Console.WriteLine("\nVous avez ramassé l'objet.");
            carte[posY, posX] = '*';
        }
    }
}
