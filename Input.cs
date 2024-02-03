using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Display;
using SaveEditor;

namespace InputLoader
{
    public class Input
    {
        public static void ProcessChoice(char choice, char[,] carte)
        {
            switch (choice)
            {
                case '1':
                    Menu.ShowLoadingScreen("Lancement de la partie.", 500);
                    Menu.ShowLoadingScreen("Lancement de la partie..", 500);
                    Menu.ShowLoadingScreen("Lancement de la partie...", 500);
                    Console.Clear();
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
                    Program.posY = 1;
                    Program.posX = 1;
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
                    Console.Clear();
                    Save.SaveGame();
                    Menu.main_menu();
                    break;
            }
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
                    Program.LancerCombatSiRencontrePokemon(carte);

                }

                // On change de map si on rencontre un symbole de changement de map
                if (carte[newPosY, newPosX] == '►')
                {
                    carte = Map.ChangeMap(carte);
                    Map.AfficherCarte(carte);
                }
                if (carte[newPosY, newPosX] == '◄')
                {
                    carte = Map.ChangeMap(carte);
                    Map.AfficherCarte(carte);
                }
                Program.posY = newPosY;
                Program.posX = newPosX;
            }
        }

        private static bool IsValidMove(int y, int x, char[,] carte)
        {
            return y >= 0 && y < carte.GetLength(0) && x >= 0 && x < carte.GetLength(1) && carte[y, x] == ' ' || carte[y, x] == 'H' || carte[y, x] == '►' || carte[y, x] == '◄' || carte[y, x] == '▲' || carte[y, x] == '▼';
        }
    }
}
