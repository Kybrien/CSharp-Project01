using CombatLoader;
using Display;
using LoadingScreen;
using SaveEditor;
using SoundLoader;

namespace InputLoader
{
    public class Input
    {
        public static bool isSurfing = false;
        public static void ProcessChoice(char choice, char[,] carte)
        {
            switch (choice)
            {
                case '1':
                    Menu.ShowLoadingScreen("Lancement de la partie.", 500);
                    Menu.ShowLoadingScreen("Lancement de la partie..", 500);
                    Menu.ShowLoadingScreen("Lancement de la partie...", 500);
                    Console.Clear();
                    if (Program.currentMapIndex == 0)
                    {
                        Loading_Screen.Little_Woods();
                        Console.Clear();
                    }
                    Program.PlayGame();
                    break;
                case '2':
                    Input.ProcessDifficultyChoice();
                    break;
                case '3':
                    Console.WriteLine("\nVous avez choisi l'option 3");
                    break;
                case '4':
                    Save.DeleteSave();
                    Menu.ShowLoadingScreen("Suppression de la partie.", 500);
                    Menu.ShowLoadingScreen("Suppression de la partie..", 500);
                    Menu.ShowLoadingScreen("Suppression de la partie...", 500);
                    break;
                case '5':
                    Console.WriteLine("\nAu revoir !");
                    Save.SaveGame();
                    Console.WriteLine("\nAu revoir !");
                    Program.quit = true;
                    break;
                case (char)ConsoleKey.Escape:
                    Program.quit = true;
                    break;
                default:
                    Console.WriteLine("\nChoix invalide. Veuillez choisir une option valide.");
                    break;
            }
        }

        public static void ProcessDifficultyChoice()
        {

            Menu.difficulty_menu();
            Console.Write("\nChoisissez une option (1-4): ");
            char choice_difficulty = Console.ReadKey().KeyChar;

            switch (choice_difficulty)
            {
                case '1':
                    Menu.ShowLoadingScreen("Difficulte facile selectionnée.", 500);
                    Menu.ShowLoadingScreen("Difficulte facile selectionnée..", 500);
                    Menu.ShowLoadingScreen("Difficulte facile selectionnée...", 500);
                    break;
                case '2':
                    Menu.ShowLoadingScreen("Difficulte moyenne selectionnée.", 500);
                    Menu.ShowLoadingScreen("Difficulte moyenne selectionnée..", 500);
                    Menu.ShowLoadingScreen("Difficulte moyenne selectionnée...", 500);
                    break;
                case '3':
                    Menu.ShowLoadingScreen("Difficulte difficile selectionnée.", 500);
                    Menu.ShowLoadingScreen("Difficulte difficile selectionnée..", 500);
                    Menu.ShowLoadingScreen("Difficulte difficile selectionnée...", 500);
                    break;
                case '4':
                    Menu.main_menu();
                    break;
                default:
                    Console.WriteLine("Difficulte actuelle : Aucune");
                    break;
            }
        }

        public static void MovePlayer(ConsoleKeyInfo keyInfo, char[,] carte)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.Z:
                    MovePlayerIfValid(-1, 0, carte);
                    break;
                case ConsoleKey.S:
                    MovePlayerIfValid(1, 0, carte);
                    break;
                case ConsoleKey.Q:
                    MovePlayerIfValid(0, -1, carte);
                    break;
                case ConsoleKey.D:
                    MovePlayerIfValid(0, 1, carte);
                    break;
                case ConsoleKey.Escape:
                    #pragma warning disable CA1416
                    Sound.StopMusic();
                    Console.Clear();
                    Save.SaveGame();
                    Menu.main_menu();
                    break;
            }
            if (carte[Program.posY, Program.posX] == '►')
            {
                Program.currentMapIndex++; // Augmente l'indice de la carte
                Map.ChangeMap();
                if (Program.currentMapIndex == 2)
                {
                    Sound.ChangeMusicBasedOnMap(Program.currentMapIndex);
                }
                else if (Program.currentMapIndex == 4)
                {
                    Sound.ChangeMusicBasedOnMap(Program.currentMapIndex);
                }
            }
            else if (carte[Program.posY, Program.posX] == '◄')
            {
                Program.currentMapIndex--; // Diminue l'indice de la carte
                Map.ChangeMap();
                if (Program.currentMapIndex == 1)
                {
                    Sound.ChangeMusicBasedOnMap(Program.currentMapIndex);
                }
                else if (Program.currentMapIndex == 3)
                {
                    Sound.ChangeMusicBasedOnMap(Program.currentMapIndex);
                }

            }
        }

        public static bool ChoiceSurf()
        {
            Console.WriteLine("Voulez-vous utiliser Surf? (O/N)");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Ajoute une nouvelle ligne pour une meilleure lisibilité
            return choice == 'O' || choice == 'o';
        }
        private static void MovePlayerIfValid(int deltaY, int deltaX, char[,] carte)
        {
            int newPosY = Program.posY + deltaY;
            int newPosX = Program.posX + deltaX;

            if (IsValidMove(newPosY, newPosX, carte))
            {
                // Vérifier spécifiquement si le joueur est sur une case avec des hautes herbes
                if (carte[newPosY, newPosX] == 'H')
                {
                    Program.posX = newPosX;
                    Program.posY = newPosY;
                    if (isSurfing == true)
                    {
                        isSurfing = false;
                    }
                    Combat.LancerCombatSiRencontrePokemon(carte, newPosX, newPosY);
                    // Vous pouvez ajouter ici tout code supplémentaire nécessaire lorsque le joueur se déplace sur une case 'H'
                }
                else if (carte[newPosY, newPosX] == '┼')
                {
                    Program.posX = newPosX;
                    Program.posY = newPosY;
                    Program.PickUpItem(carte);
                }
                else if (carte[newPosY, newPosX] == '~' && isSurfing == false)
                {
                    if (ChoiceSurf()) // Demande à l'utilisateur s'il veut utiliser Surf
                    {
                        isSurfing = true;
                        // Si l'utilisateur choisit d'utiliser Surf, déplace le joueur sur la case '~'
                        Program.posX = newPosX;
                        Program.posY = newPosY;
                    }
                }
                else if (carte[newPosY, newPosX] == '~' && isSurfing == true)
                {
                    Program.posX = newPosX;
                    Program.posY = newPosY;
                }
                else if (carte[newPosY, newPosX] == ' ' || carte[newPosY, newPosX] == '►' || carte[newPosY, newPosX] == '◄' || carte[newPosY, newPosX] == '*')
                {
                    Program.posY = newPosY;
                    Program.posX = newPosX;
                    if (carte[newPosY, newPosX] == ' ' && isSurfing == true)
                    {
                        isSurfing = false;
                    }
                }

                // Gérer le changement de carte
                if (carte[Program.posY, Program.posX] == '►' || carte[Program.posY, Program.posX] == '◄')
                {
                    carte = Map.ChangeMap(carte);
                    Map.AfficherCarte(carte);
                }
            }
        }

        private static bool IsValidMove(int y, int x, char[,] carte)
        {
            return y >= 0 && y < carte.GetLength(0) && x >= 0 && x < carte.GetLength(1) && (carte[y, x] == ' ' || carte[y, x] == 'H' || carte[y, x] == '►' || carte[y, x] == '◄' || carte[y, x] == '┼' || carte[y, x] == '*' || carte[y, x] == '~');
        }
    }
}