using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Display;
using Effectiveness;
using static CombatLoader.Combat;
using Biblio;
using MoveControl;
namespace CombatLoader
{
    public class Combat
    {
        public static bool fight_end { get; set; } = false;
        public static Random random2 = new Random();

        public static List<Pokemon> listePokemon = BibliothequePokemon.GetListePokemon();
        public static Pokemon pokemonJoueur = listePokemon[random2.Next(listePokemon.Count)];

        public static void LancerCombatSiRencontrePokemon(char[,] carte, int playerPosX, int playerPosY)
        {
            Random random = new Random();
            


            // Vérifier si le joueur est sur une case avec un Pokémon (case 'H')
            if (carte[playerPosY, playerPosX] == 'H')
            {
                // Vérifier aléatoirement s'il y a une rencontre avec un Pokémon
                if (random.Next(1, 10) == 1)
                {
                    // Rencontre un Pokémon
                    // Sélectionner un Pokémon au hasard depuis la bibliothèque
                    List<Pokemon> listePokemon = BibliothequePokemon.GetListePokemon();
                    Pokemon pokemonRencontre = listePokemon[random.Next(listePokemon.Count)];

                    int pvMaxRencontre = pokemonRencontre.PointsDeVie;
                    int pvMaxJoueur = pokemonJoueur.PointsDeVie;

                    Fight_Anim(pokemonRencontre);
                    Console.WriteLine();
                    Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");

                    Console.WriteLine($"Votre Pokémon actuelle : {pokemonJoueur.Nom}");
                    Console.WriteLine();
                    Console.WriteLine($"{pokemonJoueur.Nom} - \nHP: {pokemonJoueur.PointsDeVie}\nType : {pokemonJoueur.Type}\nAttack: {pokemonJoueur.Attack}\nDefense: {pokemonJoueur.Defense}\nSpecial Attack: {pokemonJoueur.SpecialAttack}\nSpecial Defense: {pokemonJoueur.SpecialDefense}\nSpeed: {pokemonJoueur.Speed}");
                    fight_end = true;
                    
                    Thread.Sleep(2000);
                    Console.Clear();
                    // Combat
                    while (fight_end)
                    {
                        if (pokemonJoueur.PointsDeVie < 0)
                        {
                            Console.WriteLine($"Vous avez été vaincu par le {pokemonRencontre.Nom} sauvage !");
                            Console.WriteLine();
                            Console.WriteLine("votre Pokémon est soignée");
                            pokemonJoueur.PointsDeVie = pvMaxJoueur;
                            Thread.Sleep(500);

                            fight_end = false;
                            break;
                        }
                        if (pokemonRencontre.PointsDeVie < 0)
                        {
                            Console.WriteLine($"Vous avez vaincu le {pokemonRencontre.Nom} sauvage !");
                            Console.WriteLine() ;
                            Console.WriteLine("votre Pokémon est soignée");
                            pokemonJoueur.PointsDeVie = pvMaxJoueur;
                            Thread.Sleep(500);

                            fight_end = false;

                            break;
                        }
                        Console.WriteLine();
                        Console.Clear() ;
                        Console.WriteLine("╔══════════════════════════════════╗");
                        Console.WriteLine("║               COMBAT             ║");
                        Console.WriteLine("╠══════════════════════════════════╣");
                        Console.WriteLine($"║                 {pokemonRencontre.Nom}: {pokemonRencontre.PointsDeVie}/{pvMaxRencontre} PV║");
                        Console.WriteLine("║                                  ║");
                        Console.WriteLine("║                                  ║");
                        Console.WriteLine($"║ {pokemonJoueur.Nom}: {pokemonJoueur.PointsDeVie}/{pvMaxJoueur} PV                 ║");
                        Console.WriteLine("╚══════════════════════════════════╝");




                        // Tour du joueur
                        Console.WriteLine("\nC'est à votre tour :");
                        AfficherCapacitesJoueur(pokemonJoueur);
                        int choixCapacite = DemanderChoixCapacite(pokemonJoueur.Capacites.Count);
                        Move.ManageMoveJ(pokemonJoueur,pokemonRencontre,pokemonJoueur.Capacites[choixCapacite - 1]);


                        // Tour du Pokémon sauvage
                        Console.WriteLine($"\nC'est au tour du {pokemonRencontre.Nom} sauvage :");
                        iaEasy(pokemonRencontre,pokemonJoueur);
                    }

                    // Réinitialiser la case de la carte à '.' seulement si le Pokémon n'a pas été vaincu
                    carte[playerPosY, playerPosX] = ' ';  
                }
            }
        }

        

        public static void AfficherCapacitesJoueur(Pokemon pokemon)
        {
            Console.WriteLine("Choisissez une Capacite :");
            for (int i = 0; i < pokemon.Capacites.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemon.Capacites[i].Nom} (Puissance : {pokemon.Capacites[i].Puissance})");
            }
        }

        public static int DemanderChoixCapacite(int nombreCapacites)
        {
            int choix = 0;
            do
            {
                Console.Write("Votre choix : ");
            } while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > nombreCapacites);

            return choix;
        }

        

        

        
        public static void iaEasy(Pokemon pokemon_attacker, Pokemon pokemon_defender)
        {
            Random random = new Random();

            for (int i = 0; i < 1; i++)
            {
                int choixCapacite = random.Next(1, pokemon_attacker.Capacites.Count + 1);

                // Appliquer les dégâts au joueur
                Move.ManageMoveE(pokemon_attacker, pokemon_defender, pokemon_attacker.Capacites[choixCapacite - 1]);
                //Console.WriteLine($"{pokemon.Nom} a utilisé {pokemon.Capacites[choixCapacite - 1].Nom} !");
                
            }




        }
        static void Fight_Anim(Pokemon pokemon)
        {
            string[] frames = new string[]
            {
@"
            ┌────────────────────────────────────────┐
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │ | | | | | | | | | | | | | | | | | | | ││ 
            │ | | | | | | | | | | | | | | | | | | | ││ 
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            └────────────────────────────────────────┘
            ",
            @$"
                          ┌───────────────┐
                          │               │
                          │ WILD {pokemon.Nom}  │
                          │   APPEARS!    │
                          └───────────────┘
            "
            };

            foreach (string frame in frames)
            {
                Console.Clear();
                Console.WriteLine(frame);
                Thread.Sleep(500); // Delay between frames
            }

        }

    }

      
}
