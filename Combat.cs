using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Display;

namespace CombatLoader
{
    public class Combat
    {
        public static bool APokemonRencontre { get; set; } = false;
        public static int degatsInfliges = 0;

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
                    Console.WriteLine("Vous avez rencontré un Pokémon sauvage !");
                    APokemonRencontre = true;

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
                        AfficherCapacitesJoueur(pokemonRencontre);
                        int choixCapacite = DemanderChoixCapacite(pokemonRencontre.Capacites.Count);

                        // Appliquer les dégâts à Pokémon sauvage
                        int degatsInfliges = pokemonRencontre.Capacites[choixCapacite - 1].Puissance;
                        pokemonRencontre.PointsDeVie -= degatsInfliges;

                        Console.WriteLine($"Vous avez infligé {degatsInfliges} points de dégâts.");
                        Console.WriteLine($"Points de vie restants du {pokemonRencontre.Nom}: {pokemonRencontre.PointsDeVie}");

                        // Tour du Pokémon sauvage
                        Console.WriteLine($"\nC'est au tour du {pokemonRencontre.Nom} sauvage :");
                        iaEasy(pokemonRencontre);


                        if (pokemonRencontre.PointsDeVie <= 0)
                        {
                            Console.WriteLine($"Le {pokemonRencontre.Nom} sauvage a été vaincu !");
                            APokemonRencontre = false;
                            break;
                        }
                    }

                    // Réinitialiser la case de la carte à '.' seulement si le Pokémon n'a pas été vaincu
                    if (pokemonRencontre.PointsDeVie > 0)
                    {
                        carte[playerPosY, playerPosX] = ' ';
                        APokemonRencontre = false;
                    }
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

        public class Pokemon
        {
            public string Nom { get; set; }
            public string Type { get; set; }
            public int PointsDeVie { get; set; }
            public int Attack;
            public int Defense;
            public int SpecialAttack;
            public int SpecialDefense;
            public int Speed;
            public int Potion { get; set; } = 5;
            public List<Capacite> Capacites { get; set; }

            public Pokemon(string nom, string type, int pointsDeVie, int attack, int defense, int specialAttack, int specialDefense, int speed, List<Capacite> capacites)
            {
                Nom = nom;
                PointsDeVie = pointsDeVie;
                Attack = attack;
                Defense = defense;
                SpecialAttack = specialAttack;
                SpecialDefense = specialDefense;
                Speed = speed;

                Capacites = capacites;
            }
        }

        public class Capacite
        {
            public string Nom { get; set; }
            public string Type { get; set; }
            public int Puissance { get; set; }

            public int Precision { get; set; }
            public string Category { get; set; }



            public Capacite(string nom, string type, int puissance, int precision, string category)
            {
                Nom = nom;
                Type = type;
                Puissance = puissance;
                Precision = precision;
                Category = category;
            }
        }

        public class BibliothequePokemon
        {
            public static List<Pokemon> GetListePokemon()
            {
                List<Pokemon> listePokemon = new List<Pokemon>();


                listePokemon.Add(new Pokemon("Bulbasaur", "Grass/Poison", 45, 49, 49, 65, 65, 45, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("Growl", "Normal", 0, 100, "Status") }));
                listePokemon.Add(new Pokemon("Ivysaur", "Grass/Poison", 60, 62, 63, 80, 80, 60, new List<Capacite> { new Capacite("Vine Whip", "Grass", 45, 100, "Physical"), new Capacite("Take Down", "Normal", 90, 85, "Physical") }));
                listePokemon.Add(new Pokemon("Venusaur", "Grass/Poison", 80, 82, 83, 100, 100, 80, new List<Capacite> { new Capacite("Petal Blizzard", "Grass", 90, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical") }));
                listePokemon.Add(new Pokemon("Charmander", "Fire", 39, 52, 43, 60, 50, 65, new List<Capacite> { new Capacite("Scratch", "Normal", 40, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical") }));
                listePokemon.Add(new Pokemon("Charmeleon", "Fire", 58, 64, 58, 80, 65, 80, new List<Capacite> { new Capacite("Flamethrower", "Fire", 90, 100, "Special"), new Capacite("Smokescreen", "Normal", 0, 100, "Status") }));
                listePokemon.Add(new Pokemon("Charizard", "Fire/Flying", 78, 84, 78, 109, 85, 100, new List<Capacite> { new Capacite("Fire Spin", "Fire", 35, 85, "Special"), new Capacite("Air Slash", "Flying", 75, 95, "Special") }));
                listePokemon.Add(new Pokemon("Squirtle", "Water", 44, 48, 65, 50, 64, 43, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("Bubble", "Water", 40, 100, "Special") }));
                listePokemon.Add(new Pokemon("Wartortle", "Water", 59, 63, 80, 65, 80, 58, new List<Capacite> { new Capacite("Bite", "Dark", 60, 100, "Physical"), new Capacite("Water Pulse", "Water", 60, 100, "Special") }));
                listePokemon.Add(new Pokemon("Blastoise", "Water", 79, 83, 100, 85, 105, 78, new List<Capacite> { new Capacite("Ice Beam", "Ice", 90, 100, "Special"), new Capacite("Hydro Pump", "Water", 110, 80, "Special") }));
                // ... Ajoutez d'autres Pokémon de la même manière

                return listePokemon;
            }
        }
        public static void iaEasy(Pokemon pokemon)
        {
            Random random = new Random();

            for (int i = 0; i < 1; i++)
            {
                int choixCapacite = random.Next(1, pokemon.Capacites.Count + 1);

                // Appliquer les dégâts au joueur
                int degatsCapacite = pokemon.Capacites[choixCapacite - 1].Puissance;
                degatsInfliges += degatsCapacite;
                Console.WriteLine($"{pokemon.Nom} a utilisé {pokemon.Capacites[choixCapacite - 1].Nom} !");
                Console.WriteLine($"{pokemon.Nom} a infligé {degatsCapacite} points de dégâts.");
            }

            // En supposant que le joueur a 100 points de vie initiaux
            int pointsDeVieRestants = 100 - degatsInfliges;
            Console.WriteLine($"Points de vie restants du joueur: {pointsDeVieRestants}");

            if (pointsDeVieRestants <= 0)
            {
                Console.WriteLine($"Vous avez été vaincu par le {pokemon.Nom} sauvage !");
            }
        }
        public class TypeEffectiveness
        {
            private Dictionary<string, List<string>> effectivenessChart;

            public TypeEffectiveness()
            {
                effectivenessChart = new Dictionary<string, List<string>>
                {
                { "Fire", new List<string> { "Grass", "Ice", "Bug", "Steel" } },
                { "Water", new List<string> { "Fire", "Ground", "Rock" } },
                { "Electric", new List<string> { "Water", "Flying" } },
                { "Grass", new List<string> { "Water", "Ground", "Rock" } },
                { "Ice", new List<string> { "Grass", "Ground", "Flying", "Dragon" } },
                { "Fighting", new List<string> { "Normal", "Ice", "Rock", "Dark", "Steel" } },
                { "Poison", new List<string> { "Grass", "Fairy" } },
                { "Ground", new List<string> { "Fire", "Electric", "Poison", "Rock", "Steel" } },
                { "Flying", new List<string> { "Grass", "Fighting", "Bug" } },
                { "Psychic", new List<string> { "Fighting", "Poison" } },
                { "Bug", new List<string> { "Grass", "Psychic", "Dark" } },
                { "Rock", new List<string> { "Fire", "Ice", "Flying", "Bug" } },
                { "Ghost", new List<string> { "Psychic", "Ghost" } },
                { "Dragon", new List<string> { "Dragon" } },
                { "Dark", new List<string> { "Psychic", "Ghost" } },
                { "Steel", new List<string> { "Ice", "Rock", "Fairy" } },
                { "Fairy", new List<string> { "Fighting", "Dragon", "Dark" } }
                };
            }

            public bool IsSuperEffective(string attackingType, string defendingTypes)
            {
                // Séparation des types du défenseur s'il y en a plusieurs
                var types = defendingTypes.Split('/');

                // Vérification pour chaque type de défense
                foreach (var type in types)
                {
                    if (effectivenessChart.ContainsKey(attackingType) && effectivenessChart[attackingType].Contains(type))
                    {
                        return true; // Retourne vrai si l'attaque est super efficace contre au moins un des types
                    }
                }

                return false; // Retourne faux si l'attaque n'est super efficace contre aucun des types
            }
        }
    }


}
