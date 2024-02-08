using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Display;
using fight;
using static CombatLoader.Combat;

namespace CombatLoader
{
    public class Combat
    {
        public static bool fight_end { get; set; } = false;
        public static int pvRencontre { get; set; } = 0;
        public static Random random2 = new Random();

        public static List<Pokemon> listePokemon = BibliothequePokemon.GetListePokemon();
        public static Pokemon pokemonJoueur = listePokemon[random2.Next(listePokemon.Count)];
        public static int pvPlayer { get; set; } = pokemonJoueur.PointsDeVie + 50;

        public static void TakeDamageJ(Pokemon pokemon,int damage)
        {
            pokemon.pointsDeVieRestantsPlayer -= damage;
        }
        public static void TakeDamageR(Pokemon pokemon, int damage)
        {
            pokemon.pointsDeVieRestantsRencontre -= damage;
        }

        public static class BibliothequePokemon
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

                    //int pointsDeVieRestantsPlayer = pokemonJoueur.PointsDeVie + 50;
                    //int pointsDeVieRestantsRencontre = pokemonRencontre.PointsDeVie;
                    Console.WriteLine("Vous avez rencontré un Pokémon sauvage !");
                    Console.WriteLine();
                    Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");

                    Console.WriteLine($"Votre Pokémon actuelle : {pokemonJoueur.Nom}");
                    Console.WriteLine();
                    Console.WriteLine($"{pokemonJoueur.Nom} - \nHP: {pokemonJoueur.PointsDeVie}\nType : {pokemonJoueur.Type}\nAttack: {pokemonJoueur.Attack}\nDefense: {pokemonJoueur.Defense}\nSpecial Attack: {pokemonJoueur.SpecialAttack}\nSpecial Defense: {pokemonJoueur.SpecialDefense}\nSpeed: {pokemonJoueur.Speed}");
                    fight_end = true;
                    Console.WriteLine($"Un {pokemonRencontre.Nom} sauvage apparaît !");
                    Thread.Sleep(2000);
                    Console.Clear();
                    // Combat
                    while (fight_end)
                    {
                        Console.WriteLine();

                        Console.WriteLine($"Points de vie {pokemonRencontre.Nom}: {pokemonRencontre.pointsDeVieRestantsRencontre}/{pokemonRencontre.PointsDeVie}");
                        Console.WriteLine($"Points de vie {pokemonJoueur.Nom}: {pokemonJoueur.pointsDeVieRestantsPlayer}/{pokemonJoueur.PointsDeVie + 50}");



                        // Tour du joueur
                        Console.WriteLine("\nC'est à votre tour :");
                        AfficherCapacitesJoueur(pokemonJoueur);
                        int choixCapacite = DemanderChoixCapacite(pokemonJoueur.Capacites.Count);
                        ManageMoveJ(pokemonJoueur,pokemonRencontre,pokemonJoueur.Capacites[choixCapacite - 1]);


                        if (pokemonRencontre.pointsDeVieRestantsRencontre < 0)
                        {
                            Console.WriteLine($"Le {pokemonRencontre.Nom} sauvage a été vaincu !");
                            Thread.Sleep(500);
                            fight_end = false;
                            break;
                        }

                        // Tour du Pokémon sauvage
                        Console.WriteLine($"\nC'est au tour du {pokemonRencontre.Nom} sauvage :");
                        iaEasy(pokemonRencontre,pokemonJoueur);
                    }

                    // Réinitialiser la case de la carte à '.' seulement si le Pokémon n'a pas été vaincu
                    carte[playerPosY, playerPosX] = ' ';
                }
            }
        }

        public static void ManageMoveJ(Pokemon attacker, Pokemon defender, Capacite attackAbility)
        {
                Random rand = new Random();
                int randomChance = rand.Next(100);
                string cat = attackAbility.Category;
            Console.WriteLine($"capacité : {attackAbility.Nom}");
                switch (cat)
                {
                    case "Physical":
                        int damage = (attackAbility.Puissance + attacker.Attack) / defender.Defense + 10;
                        Console.WriteLine($"{attacker.Nom} attaque !");
                        if (randomChance <= attackAbility.Precision)
                        {
                            Console.WriteLine($"{defender.Nom} a subi {damage} dommages.");
                        TakeDamageR(defender,damage);
                        }
                        else
                        {
                            Console.WriteLine("L'attaque a échoué !");
                        }
                        break;
                    case "Special":
                        int spe_damage = (attackAbility.Puissance + attacker.SpecialAttack) / defender.SpecialDefense + 10 ;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        Console.WriteLine($"{defender.Nom} a subi {spe_damage} dommages.");
                        TakeDamageR(defender, spe_damage);
                    }
                    else
                    {
                        Console.WriteLine("L'attaque a échoué !");
                    }
                    break;
                    case "Status":
                        int stat = rand.Next(5);
                        switch(stat)
                    {
                        case 1:
                            Console.WriteLine("l'attaque adverse est réduite");
                            defender.Attack -= 10;
                            break;
                        case 2:
                            Console.WriteLine("La défense adverse est réduite");
                            defender.Defense -= 10;
                            break;
                        case 3:
                            Console.WriteLine("l'attaque spéciale adverse est réduite");
                            defender.SpecialAttack -= 10;
                            break;
                        case 4:
                            Console.WriteLine("la défense spéciale adverse est réduite");
                            defender.SpecialDefense -= 10;
                            break;
                        case 5:
                            Console.WriteLine("La vitesse adverse est réduite");
                            defender.Speed -= 10;
                            break;
                    }



                    break;
                }

                Thread.Sleep(2000); // Pause for 2 seconds
            }
        public static void ManageMoveE(Pokemon attacker, Pokemon defender, Capacite attackAbility)
        {
            Random rand = new Random();
            int randomChance = rand.Next(100);
            string cat = attackAbility.Category;
            Console.WriteLine($"capacité : {attackAbility.Nom}");
            switch (cat)
            {
                case "Physical":
                    int damage = (attackAbility.Puissance + attacker.Attack) / defender.Defense +10;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        Console.WriteLine($"{defender.Nom} a subi {damage} dommages.");
                        TakeDamageJ(defender,damage);
                    }
                    else
                    {
                        Console.WriteLine("L'attaque a échoué !");
                    }
                    break;
                case "Special":
                    int spe_damage = (attackAbility.Puissance + attacker.SpecialAttack) / defender.SpecialDefense +10;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        Console.WriteLine($"{defender.Nom} a subi {spe_damage} dommages.");
                        TakeDamageJ(defender, spe_damage);
                    }
                    else
                    {
                        Console.WriteLine("L'attaque a échoué !");
                    }
                    break;
                case "Status":
                    int stat = rand.Next(5);
                    switch (stat)
                    {
                        case 1:
                            Console.WriteLine("l'attaque adverse est réduite");
                            defender.Attack -= 10;
                            break;
                        case 2:
                            Console.WriteLine("La défense adverse est réduite");
                            defender.Defense -= 10;
                            break;
                        case 3:
                            Console.WriteLine("l'attaque spéciale adverse est réduite");
                            defender.SpecialAttack -= 10;
                            break;
                        case 4:
                            Console.WriteLine("la défense spéciale adverse est réduite");
                            defender.SpecialDefense -= 10;
                            break;
                        case 5:
                            Console.WriteLine("La vitesse adverse est réduite");
                            defender.Speed -= 10;
                            break;
                    }



                    break;
            }

            Thread.Sleep(2000); // Pause for 2 seconds
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
            public int pointsDeVieRestantsRencontre { get; set; } = pvRencontre;
            public int pointsDeVieRestantsPlayer { get; set; } = pvPlayer;

            public int Potion { get; set; } = 5;
            public List<Capacite> Capacites { get; set; }

            public Pokemon(string nom,string type, int pointsDeVie,int attack,int defense,int specialAttack,int specialDefense, int speed, List<Capacite> capacites)
            {
                Nom = nom;
                Type = type;
                PointsDeVie = pointsDeVie;
                Attack = attack;
                Defense = defense;
                SpecialAttack = specialAttack;
                SpecialDefense = specialDefense;
                Speed = speed;

                Capacites = capacites;
            }
            public void DisplayStats(Pokemon pokemon)
            {
                Console.WriteLine($"{pokemon.Nom} - \nHP: {pokemon.PointsDeVie}\nType : {pokemon.Type}\nAttack: {pokemon.Attack}\nDefense: {pokemon.Defense}\nSpecial Attack: {pokemon.SpecialAttack}\nSpecial Defense: {pokemon.SpecialDefense}\nSpeed: {pokemon.Speed}");
            }
        }

        public class Capacite
        {
            public string Nom { get; set; }
            public string Type { get; set; }
            public int Puissance { get; set; }

            public int Precision { get; set; }
            public string Category { get; set; }



            public Capacite(string nom,string type, int puissance, int precision, string category)
            {
                Nom = nom;
                Type = type;
                Puissance = puissance;
                Precision = precision;
                Category = category;
            }
        }

        
        public static void iaEasy(Pokemon pokemon_attacker, Pokemon pokemon_defender)
        {
            Random random = new Random();

            for (int i = 0; i < 1; i++)
            {
                int choixCapacite = random.Next(1, pokemon_attacker.Capacites.Count + 1);

                // Appliquer les dégâts au joueur
                ManageMoveE(pokemon_attacker, pokemon_defender, pokemon_attacker.Capacites[choixCapacite - 1]);
                //Console.WriteLine($"{pokemon.Nom} a utilisé {pokemon.Capacites[choixCapacite - 1].Nom} !");
                
            }



            if (pvRencontre == 0)
            {
                Console.WriteLine($"Vous avez été vaincu par le {pokemon_attacker.Nom} sauvage !");
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
