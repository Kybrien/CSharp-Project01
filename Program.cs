using System;
using System.Threading;

class Program
{
    static bool quit = false;
    static int posX = 1, posY = 1;

    static void Main()
    {
        InitializeConsole();

        char[,] carte = InitializeCarte();

        do
        {
            Console.Clear();
            main_menu();

            Console.Write("Choisissez une option (1-4): ");
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
            {'#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '#', '#', '#', '#', '.', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '#', '#'},
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
                quit = true;
                Console.WriteLine("\nAu revoir !");
                break;

            default:
                Console.WriteLine("\nChoix invalide. Veuillez choisir une option valide.");
                break;
        }
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

        } while (keyInfo.Key != ConsoleKey.Escape);

        Console.ReadLine();
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
        }
    }

    static void MovePlayerIfValid(int deltaY, int deltaX, char[,] carte)
    {
        int newPosY = posY + deltaY;
        int newPosX = posX + deltaX;

        if (IsValidMove(newPosY, newPosX, carte))
        {
            carte[posY, posX] = '.';
            posY = newPosY;
            posX = newPosX;
        }
    }

    static bool IsValidMove(int y, int x, char[,] carte)
    {
        return y >= 0 && y < carte.GetLength(0) && x >= 0 && x < carte.GetLength(1) && carte[y, x] == '.';
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
                ShowLoadingScreen("Difficulte selectionnée..", 500);
                ShowLoadingScreen("Difficulte selectionnée...", 500);
                Console.WriteLine("\nDifficulte actuelle : Facile\n");
                break;
            case '2':
                ShowLoadingScreen("Difficulte moyenne selectionnée.", 500);
                ShowLoadingScreen("Difficulte moyenne selectionnée..", 500);
                ShowLoadingScreen("Difficulte moyenne selectionnée...", 500);
                Console.WriteLine("\nDifficulte actuelle : Moyen\n");
                break;
            case '3':
                ShowLoadingScreen("Difficulte difficile selectionnée.", 500);
                ShowLoadingScreen("Difficulte difficile selectionnée..", 500);
                ShowLoadingScreen("Difficulte difficile selectionnée..", 500);
                Console.WriteLine("\nDifficulte actuelle : Difficile\n");
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
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(carte[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
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
        Console.WriteLine("║ 4.  Quitter            ║");
        Console.WriteLine("╚════════════════════════╝");
    }

    static void ShowLoadingScreen(string message, int durationMilliseconds)
    {
        Console.Clear();
        Console.WriteLine(message);

        Thread.Sleep(durationMilliseconds);
    }
}
