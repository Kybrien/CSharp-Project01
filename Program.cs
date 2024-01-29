using System;
class Program
{
    static void Main()
    {
        bool quit = false;

        // Ajuste la taille de la console si le système d'exploitation est Windows
        if (OperatingSystem.IsWindows())
        {
            Console.WindowWidth = 20;
            Console.WindowHeight = 10;
        }

        // Définition de la carte sous forme de tableau 2D de caractères
        char[,] carte =
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '#'},
            {'#', '.', '.', '#', '#', '#', '#', '#', '#', '#', '#', '#', '.', '.', '.', '.', '.', '.', '#', '#'},
            {'#', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#', '#', '.', '.', '.', '#', '#'},
            {'#', '.', '.', '#', '.', '#', '#', '#', '#', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#', '#'},
            {'#', '.', '.', '#', '.', '.', '.', '.', '#', '#', '#', '#', '#', '.', '#', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '#', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '#', '#', '.', '#', '.', '#', '#', '#', '#', '#', '#', '#', '.', '#', '#', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        /* Position de départ du joueur */
        int posX = 1;
        int posY = 1;

        do
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

            Console.Write("Choisissez une option (1-4): ");
            char choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case '1':
                    Console.WriteLine("\nVous avez choisi l'option 1 ⚔.");
                    // Ajoutez le code correspondant à l'option 1 ici
                    AfficherCarte(carte, posX, posY);
                    // Fonction qui affiche la carte avec la position du joueur
                    static void AfficherCarte(char[,] carte, int posX, int posY)
                    {
                        for (int i = 0; i < carte.GetLength(0); i++)
                        {
                            for (int j = 0; j < carte.GetLength(1); j++)
                            {
                                if (i == posY && j == posX)
                                {
                                    // Met en rouge la position du joueur sur la carte
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("P ");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    // Affiche les autres éléments de la carte
                                    Console.Write(carte[i, j] + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }

                    // Récupère les touches de l'utilisateur jusqu'à ce que la touche Échap soit pressée
                    ConsoleKeyInfo keyInfo;
                    do
                    {
                        keyInfo = Console.ReadKey(true);

                        // Déplacement du joueur en fonction de la touche pressée
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.Z:
                                // Déplacement vers le haut si la case suivante est un point '.'
                                if (posY > 1 && carte[posY - 1, posX] == '.')
                                {
                                    carte[posY, posX] = '.';
                                    posY--;
                                }
                                break;
                            case ConsoleKey.S:
                                // Déplacement vers le bas si la case suivante est un point '.'
                                if (posY < carte.GetLength(0) - 2 && carte[posY + 1, posX] == '.')
                                {
                                    carte[posY, posX] = '.';
                                    posY++;
                                }
                                break;
                            case ConsoleKey.Q:
                                // Déplacement vers la gauche si la case suivante est un point '.'
                                if (posX > 1 && carte[posY, posX - 1] == '.')
                                {
                                    carte[posY, posX] = '.';
                                    posX--;
                                }
                                break;
                            case ConsoleKey.D:
                                // Déplacement vers la droite si la case suivante est un point '.'
                                if (posX < carte.GetLength(1) - 2 && carte[posY, posX + 1] == '.')
                                {
                                    carte[posY, posX] = '.';
                                    posX++;
                                }
                                break;
                        }

                        // Efface la console et réaffiche la carte mise à jour
                        Console.Clear();
                        AfficherCarte(carte, posX, posY);


                        // Affiche la carte avec la position mise à jour du joueur
                        AfficherCarte(carte, posX, posY);

                    } while (keyInfo.Key != ConsoleKey.Escape);

                    Console.ReadLine(); // Attend une pression de touche avant de quitter

                    break;

                case '2':
                    Console.WriteLine("\nVous avez choisi l'option 2 🎮.");
                    // Ajoutez le code correspondant à l'option 2 ici
                    break;
                case '3':
                    Console.WriteLine("\nVous avez choisi l'option 3 🌐.");
                    // Ajoutez le code correspondant à l'option 3 ici
                    break;
                case '4':
                    quit = true;
                    Console.WriteLine("\nAu revoir ❌ !");
                    break;
                default:
                    Console.WriteLine("\nChoix invalide. Veuillez choisir une option valide.");
                    break;
            }

        } while (!quit);
    }





    // Fonction qui affiche la carte avec la position du joueur
    static void AfficherCarte(char[,] carte, int posX, int posY)
    {
        for (int i = 0; i < carte.GetLength(0); i++)
        {
            for (int j = 0; j < carte.GetLength(1); j++)
            {
                if (i == posY && j == posX)
                {
                    // Met en rouge la position du joueur sur la carte
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("P ");
                    Console.ResetColor();
                }
                else
                {
                    // Affiche les autres éléments de la carte
                    Console.Write(carte[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
