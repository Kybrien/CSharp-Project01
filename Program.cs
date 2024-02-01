using System;
using System.Threading;
using fight;

class Program
{
    static bool quit = false;
    static int posX = 1, posY = 1;


    static void Main()
    {
        InitializeConsole();

        char[,] carte = InitializeCarte();
        LoadGame();

        do
        {
            Console.Clear();
            main_menu();

            Console.Write("Choisissez une option (1-5): ");
            char choice = Console.ReadKey().KeyChar;

            ProcessChoice(choice, carte);

        } while (!quit);
    }

    static void InitializeConsole()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.WindowWidth = 20;
            Console.WindowHeight = 20;
        }
    }

    static char[,] InitializeCarte()
    {
        char[,] carte =
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '#', '#', '#', '#', '#', '#', '#', '#', '#', '.', '.', '#', '.', '.', '#', '#', '#'},
            {'#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#', '#', '.', '.', '#', '.', '#'},
            {'#', '.', '.', '#', '.', '#', '#', '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '#', '.', '.', '.', '.', '#', '#', '#', '#', '#', '.', '#', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '#', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '#', '#', '.', '#', '.', '#', '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '.', '#', '.', '.', '#', '.', '.', '.', '.', '.', '#', '.', '.', '#'},
            {'#', 'H', 'H', 'H', '#', '.', '.', '.', '.', '.', '#', '#', '#', '#', '.', '.', '#', '.', '.', '#'},
            {'#', 'H', 'H', 'H', '#', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '#', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '#', '#', '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '#'},
            {'#', '.', '#', '#', '#', '.', '#', '.', '.', '#', '.', '.', '.', '#', '#', '#', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '#', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        return carte;
    }

    static void ProcessChoice(char choice, char[,] carte)
    {
        switch (choice)
        {
            case '1':
                ShowLoadingScreen("Lancement de la partie.", 500);
                ShowLoadingScreen("Lancement de la partie..", 500);
                ShowLoadingScreen("Lancement de la partie...", 500);
                Console.Clear();
                PlayGame(carte);
                break;

            case '2':
                ProcessDifficultyChoice();
                break;

            case '3':
                Console.WriteLine("\nVous avez choisi l'option 3");
                break;

            case '4':
                DeleteSave();
                posY = 1;
                posX = 1;
                ShowLoadingScreen("Suppression de la partie.", 500);
                ShowLoadingScreen("Suppression de la partie..", 500);
                ShowLoadingScreen("Suppression de la partie...", 500);
                break;

            case '5':
                Console.WriteLine("\nAu revoir !");
                SaveGame();
                Console.WriteLine("\nAu revoir !");
                quit = true;
                break;

            case (char)ConsoleKey.Escape:
                // Quitter la boucle principale lors de l'appui sur Escape
                quit = true;
                break;

            default:
                Console.WriteLine("\nChoix invalide. Veuillez choisir une option valide.");
                break;
        }

/*        // Ajouter une pause après l'affichage du menu principal
        if (!quit)
        {
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }*/
    }

    static void PlayGame(char[,] carte)
    {
        AfficherCarte(carte);

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            MovePlayer(keyInfo, carte);
            Console.Clear();
            AfficherCarte(carte);
            listPoke.txtest();

        } while (keyInfo.Key != ConsoleKey.Escape);
    }

    static void MovePlayer(ConsoleKeyInfo keyInfo, char[,] carte)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.W:
                MovePlayerIfValid(-1, 0, carte);
                break;
            case ConsoleKey.S:
                MovePlayerIfValid(1, 0, carte);
                break;
            case ConsoleKey.A:
                MovePlayerIfValid(0, -1, carte);
                break;
            case ConsoleKey.D:
                MovePlayerIfValid(0, 1, carte);
                break;
            case ConsoleKey.Escape:
                Console.Clear();
                SaveGame();
                main_menu();
                break;
        }
    }

    static void MovePlayerIfValid(int deltaY, int deltaX, char[,] carte)
    {
        int newPosY = posY + deltaY;
        int newPosX = posX + deltaX;

        if (IsValidMove(newPosY, newPosX, carte))
        {
            // Vérifier spécifiquement si le joueur est sur une case avec des hautes herbes
            /*if (carte[newPosY, newPosX] == 'H')
            {
                LancerCombatSiRencontrePokemon(carte);
            }*/

            posY = newPosY;
            posX = newPosX;
        }
    }

    static bool IsValidMove(int y, int x, char[,] carte)
    {
        return y >= 0 && y < carte.GetLength(0) && x >= 0 && x < carte.GetLength(1) && carte[y, x] == '.' || carte[y, x] == 'H';
    }

    static void main_menu()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════╗");
        Console.WriteLine("║          Menu          ║");
        Console.WriteLine("╠════════════════════════╣");
        Console.WriteLine("║ 1.  Lancer             ║");
        Console.WriteLine("║ 2.  Difficulte         ║");
        Console.WriteLine("║ 3.  Options            ║");
        Console.WriteLine("║ 4.  Supprimer Partie   ║");
        Console.WriteLine("║ 5.  Quitter            ║");
        Console.WriteLine("╚════════════════════════╝");
    }

    static void ProcessDifficultyChoice()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════╗");
        Console.WriteLine("║       Difficulte       ║");
        Console.WriteLine("╠════════════════════════╣");
        Console.WriteLine("║ 1.  Facile             ║");
        Console.WriteLine("║ 2.  Moyen              ║");
        Console.WriteLine("║ 3.  Difficile          ║");
        Console.WriteLine("║ 4.  --RETOUR--         ║");
        Console.WriteLine("╚════════════════════════╝");

        Console.Write("\nChoisissez une option (1-4): ");
        char choice_difficulty = Console.ReadKey().KeyChar;

        switch (choice_difficulty)
        {
            case '1':
                ShowLoadingScreen("Difficulte facile selectionnée.", 500);
                ShowLoadingScreen("Difficulte facile selectionnée..", 500);
                ShowLoadingScreen("Difficulte facile selectionnée...", 500);
                break;
            case '2':
                ShowLoadingScreen("Difficulte moyenne selectionnée.", 500);
                ShowLoadingScreen("Difficulte moyenne selectionnée..", 500);
                ShowLoadingScreen("Difficulte moyenne selectionnée...", 500);
                break;
            case '3':
                ShowLoadingScreen("Difficulte difficile selectionnée.", 500);
                ShowLoadingScreen("Difficulte difficile selectionnée..", 500);
                ShowLoadingScreen("Difficulte difficile selectionnée..", 500);
                break;
            case '4':
                main_menu();
                break;
            default:
                Console.WriteLine("Difficulte actuelle : Aucune");
                break;
        }
    }

    static void AfficherCarte(char[,] carte)
    {
        for (int i = 0; i < carte.GetLength(0); i++)
        {
            for (int j = 0; j < carte.GetLength(1); j++)
            {
                if (i == posY && j == posX)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("P ");
                }
                else
                {
                    // Couleur marron pour les murs
                    if (carte[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    // Couleur verte pour les hautes herbes
                    else if (carte[i, j] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.Write(carte[i, j] + " ");
                }
            }
            Console.WriteLine();
        }

        // Assure-toi de réinitialiser la couleur après avoir affiché la carte
        Console.ResetColor();
    }



    static void ShowLoadingScreen(string message, int durationMilliseconds)
    {
        Console.Clear();
        Console.WriteLine(message);

        Thread.Sleep(durationMilliseconds);
    }

    /*static void LancerCombatSiRencontrePokemon(char[,] carte)
    {
        Random random = new Random();

        // Vérifier si le joueur est sur une case avec un Pokémon
        if (carte[posY, posX] == 'H' && random.Next(1, 10) == 1)
        {
            // Rencontre un Pokémon
            Console.WriteLine("Vous avez rencontré un Pokémon sauvage !");

            // Sélectionner un Pokémon au hasard depuis la bibliothèque
            List<Pokemon> listePokemon = BibliothequePokemon.GetListePokemon();
            Pokemon pokemonRencontre = listePokemon[random.Next(listePokemon.Count)];

            Console.WriteLine($"Un {pokemonRencontre.Nom} sauvage apparaît !");
            Console.WriteLine($"Points de vie du {pokemonRencontre.Nom}: {pokemonRencontre.PointsDeVie}");

            // Combat
            while (pokemonRencontre.PointsDeVie > 0)
            {
                // Tour du joueur
                Console.WriteLine("\nC'est à votre tour :");
                AfficherAttaquesJoueur(pokemonRencontre);
                int choixAttaque = DemanderChoixAttaque(pokemonRencontre.Attaques.Count);

                // Appliquer les dégâts à Pokémon sauvage
                int degatsInfliges = pokemonRencontre.Attaques[choixAttaque - 1].Puissance;
                pokemonRencontre.PointsDeVie -= degatsInfliges;

                Console.WriteLine($"Vous avez infligé {degatsInfliges} points de dégâts.");
                Console.WriteLine($"Points de vie restants du {pokemonRencontre.Nom}: {pokemonRencontre.PointsDeVie}");

                if (pokemonRencontre.PointsDeVie <= 0)
                {
                    Console.WriteLine($"Le {pokemonRencontre.Nom} sauvage a été vaincu !");
                    break;
                }

                // Tour du Pokémon sauvage
                Console.WriteLine($"\nC'est au tour du {pokemonRencontre.Nom} sauvage :");
                int choixAttaquePokemon = random.Next(pokemonRencontre.Attaques.Count);

                // Appliquer les dégâts au joueur
                int degatsInfligesPokemon = pokemonRencontre.Attaques[choixAttaquePokemon].Puissance;
                // En supposant que le joueur a 100 points de vie initiaux
                Console.WriteLine($"{pokemonRencontre.Nom} a infligé {degatsInfligesPokemon} points de dégâts.");
                Console.WriteLine($"Points de vie restants du joueur: {100 - degatsInfligesPokemon}");

                if (100 - degatsInfligesPokemon <= 0)
                {
                    Console.WriteLine($"Vous avez été vaincu par le {pokemonRencontre.Nom} sauvage !");
                    break;
                }
            }

            // Réinitialiser la case de la carte à '.' seulement si le Pokémon n'a pas été vaincu
            if (pokemonRencontre.PointsDeVie > 0)
            {
                carte[posY, posX] = '.';
            }
        }
    }

    static void AfficherAttaquesJoueur(Pokemon pokemon)
    {
        Console.WriteLine("Choisissez une attaque :");
        for (int i = 0; i < pokemon.Attaques.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemon.Attaques[i].Nom} (Puissance : {pokemon.Attaques[i].Puissance})");
        }
    }

    static int DemanderChoixAttaque(int nombreAttaques)
    {
        int choix = 0;
        do
        {
            Console.Write("Votre choix : ");
        } while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > nombreAttaques);

        return choix;
    }

    public class Pokemon
    {
        public string Nom { get; set; }
        public int PointsDeVie { get; set; }
        public List<Attaque> Attaques { get; set; }

        public Pokemon(string nom, int pointsDeVie, List<Attaque> attaques)
        {
            Nom = nom;
            PointsDeVie = pointsDeVie;
            Attaques = attaques;
        }
    }

    public class Attaque
    {
        public string Nom { get; set; }
        public int Puissance { get; set; }

        public Attaque(string nom, int puissance)
        {
            Nom = nom;
            Puissance = puissance;
        }
    }*/



    //------------------------------------------------SAVE------------------------------------------------
    static void SaveGame()
    {
        string filePath = "save.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(posX);
                writer.WriteLine(posY);
            }

            Console.WriteLine("Partie sauvegardée avec succès.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la sauvegarde de la : " + ex.Message);
        }
    }

    static void LoadGame()
    {
        string filePath = "save.txt";

        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    if (int.TryParse(reader.ReadLine(), out posX) && int.TryParse(reader.ReadLine(), out posY))
                    {
                        Console.WriteLine("Partie chargée avec succès. Position actuelle : ({",posX,"}, {",posY,"})");
                    }
                    else
                    {
                        Console.WriteLine("Erreur lors de la lecture du fichier de sauvegarde.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Aucun fichier de sauvegarde trouvé.");
                Console.WriteLine("Creation d'une nouvelle partie...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors du chargement : " + ex.Message);
        }
    }

    static void DeleteSave()
    {
        string filePath = "save.txt";

        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("Sauvegarde supprimée avec succès.");
            }
            else
            {
                Console.WriteLine("Aucune sauvegarde trouvée.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la suppression de la sauvegarde : " + ex.Message);
        }
    }
}
