using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using Display;
using SaveEditor;
using InputLoader;

class Program
{
    public static bool quit = false;
    public static int posX = 1, posY = 1;
    public static char[,] currentMap = { };

    static void Main()
    {
        InitializeConsole();

        // Initialiser la carte actuelle
        currentMap = Map.InitMap1();
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

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            Input.MovePlayer(keyInfo, currentMap);
            Console.Clear();
            Map.AfficherCarte(currentMap);

        } while (keyInfo.Key != ConsoleKey.Escape);
    }
    



    //A METTRE DANS UNE CLASSE A PART (COMBAT)
    // ----------------------Combat Pokemon-----------------------
    public static void LancerCombatSiRencontrePokemon(char[,] carte)
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
                carte[posY, posX] = ' ';
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
    }

    public class BibliothequePokemon
    {
        public static List<Pokemon> GetListePokemon()
        {
            List<Pokemon> listePokemon = new List<Pokemon>();

            // Ajoutez vos Pokémon ici
            listePokemon.Add(new Pokemon("Pikachu", 100, new List<Attaque> { new Attaque("Éclair", 20), new Attaque("Queue de fer", 15) }));
            listePokemon.Add(new Pokemon("Bulbizarre", 120, new List<Attaque> { new Attaque("Fouet lianes", 18), new Attaque("Vampigraine", 12) }));
            // ... Ajoutez d'autres Pokémon de la même manière

            return listePokemon;
        }
    }
}
