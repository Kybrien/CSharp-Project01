/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Program;
using fight;
namespace fight
{
    public class Pokemon
    {
        private string name;
        private string type;

        private int hp;
        private int attack;
        private int defense;
        private int specialAttack;
        private int specialDefense;
        private int speed;
        public int Potion { get; set; } = 5;
        public List<Ability> Abilities { get; set; }

        public Pokemon(string name, string type, int hp, int attack, int defense, int specialAttack, int specialDefense, int speed, List<Ability> Abilities)
        {
            this.name = name;
            this.type = type;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            this.specialAttack = specialAttack;
            this.specialDefense = specialDefense;
            this.speed = speed;
            this.Abilities = Abilities;
        }

        public void UsePotion()
        {
            hp += 10;
            Console.WriteLine("Vous avez soigné 30 PV.");
            Potion--;
            Console.WriteLine($"Il vous reste {Potion} potions.");
        }

        public int TakeDamage(int damage)
        {
            hp -= damage;
            return hp;
        }

        public void LowerAttack()
        {
            attack -= 5;
        }

        public void LowerDefense()
        {
            defense -= 5;
        }

        public bool IsFainted()
        {
            return hp <= 0;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"{name} - \nHP: {hp}\nType : {type}\nAttack: {attack}\nDefense: {defense}\nSpecial Attack: {specialAttack}\nSpecial Defense: {specialDefense}\nSpeed: {speed}");
        }

        // Accessor methods
        public string GetName() => name;
        public string GetType() => type;

        public int GetHp() => hp;
        public int GetSpeed() => speed;
        public int GetAttack() => attack;
        public int GetDefense() => defense;
        public int GetSpecialAttack() => specialAttack;
        public int GetSpecialDefense() => specialDefense;
    }

        public class Ability
    {
        private string name;
        private int power;
        private double accuracy;
        private string category; // "Physical", "Special", or "Status"

        public Ability(string name, int power, int accuracy, string category)
        {
            this.name = name;
            this.power = power;
            this.accuracy = accuracy;
            this.category = category;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {name}\nPower: {power}\nAccuracy: {accuracy}\nCategory: {category}");
        }

        public string GetName() => name;
        public int GetPower() => power;
        public double GetAccuracy() => accuracy;
        public string GetCategory() => category;


    }


    public class Move
    {
        public static void ManageMove(int choice, Pokemon attacker, Pokemon defender, Ability attackAbility, Ability statusAbility)
        {
            Random rand = new Random();
            int randomChance = rand.Next(100);

            switch (choice)
            {
                case 1:
                    int damage = (attackAbility.GetPower() + (attacker.GetAttack() / defender.GetDefense())) / 8 + 1;
                    Console.WriteLine($"{attacker.GetName()} attaque !");
                    if (randomChance <= attackAbility.GetAccuracy())
                    {
                        Console.WriteLine($"{defender.GetName()} a subi {damage} dommages.");
                        defender.TakeDamage(damage);
                    }
                    else
                    {
                        Console.WriteLine("L'attaque a échoué !");
                    }
                    break;
                case 2:
                    if (statusAbility.GetName() == "Growl")
                    {
                        Console.WriteLine($"{attacker.GetName()} a affaibli l'attaque de l'ennemi.");
                        defender.LowerAttack();
                    }
                    else if (statusAbility.GetName() == "Tail Whip" || statusAbility.GetName() == "Leer")
                    {
                        Console.WriteLine($"{attacker.GetName()} a affaibli la défense de l'ennemi.");
                        defender.LowerDefense();
                    }
                    break;
                case 3:
                    attacker.UsePotion();
                    break;
            }

            Thread.Sleep(2000); // Pause for 2 seconds
        }

    }


    public class listPoke
    {
        // Méthode pour lire les Pokémon à partir d'un fichier
        public static List<Pokemon> ReadPokemonFromFile(string filePath)
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 7)
                    {
                        string name = parts[0];
                        string type = parts[1];
                        int hp = int.Parse(parts[2]);
                        int attack = int.Parse(parts[3]);
                        int defense = int.Parse(parts[4]);
                        int specialAttack = int.Parse(parts[5]);
                        int specialDefense = int.Parse(parts[6]);
                        int speed = int.Parse(parts[7]);


                        Pokemon pokemon = new Pokemon(name, type, hp, attack, defense, specialAttack, specialDefense, speed);
                        pokemons.Add(pokemon);
                    }
                }
            }

            return pokemons;
        }
        public static List<Ability> ReadAbilitiesFromFile(string filePath)
        {
            List<Ability> abilities = new List<Ability>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            string name = parts[0].Trim();
                            int power = int.Parse(parts[1].Trim());
                            int accuracy = int.Parse(parts[2].Trim());
                            string category = parts[3].Trim();

                            abilities.Add(new Ability(name, power, accuracy, category));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the abilities file: {ex.Message}");
            }

            return abilities;
        }

        public static void createPokefile()
        {
            string pokemonFilePath = "Pokedico.txt"; // Chemin du fichier des Pokémon
            string abilitiesFilePath = "Abilities.txt"; // Chemin du fichier des capacités

            List<Pokemon> pokemons = ReadPokemonFromFile(pokemonFilePath);
            List<Ability> abilities = ReadAbilitiesFromFile(abilitiesFilePath);


            foreach (var pokemon in pokemons)
            {
                CreatePokemonFile(pokemon, abilities.GetRange(0, Math.Min(4, abilities.Count)));
            }
        }

        public static void CreatePokemonFile(Pokemon pokemon, List<Ability> abilities)
        {
            string fileName = $"Pokemon_{pokemon.GetName()}.txt"; // Nom du fichier basé sur le nom du Pokémon
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Écriture des statistiques du Pokémon
                writer.WriteLine($"Name: {pokemon.GetName()}");
                writer.WriteLine($"HP: {pokemon.GetHp()}");
                writer.WriteLine($"Type: {pokemon.GetType()}");

                writer.WriteLine($"Attack: {pokemon.GetAttack()}");
                writer.WriteLine($"Defense: {pokemon.GetDefense()}");
                writer.WriteLine($"Special Attack: {pokemon.GetSpecialAttack()}");
                writer.WriteLine($"Special Defense: {pokemon.GetSpecialDefense()}");
                writer.WriteLine($"Speed: {pokemon.GetSpeed()}");

                // Écriture des capacités du Pokémon
                writer.WriteLine("\nAbilities:");
                Console.WriteLine(abilities.Count);
                foreach (var ability in abilities)
                {

                    writer.WriteLine($"- {ability.GetName()} (Power: {ability.GetPower()}, Accuracy: {ability.GetAccuracy()}, Category: {ability.GetCategory()})");
                }

            }

            Console.WriteLine($"Fichier créé pour {pokemon.GetName()}.");
        }
        public static void txtest()
        {
            string filePath = "Pokedico.txt"; // Remplacez par le chemin réel de votre fichier
            List<Pokemon> pokemons = ReadPokemonFromFile(filePath);

            // Affichage des Pokémon pour vérifier la lecture du fichier
            foreach (Pokemon pokemon in pokemons)
            {
                pokemon.DisplayStats();
                Console.WriteLine(); // Pour ajouter une ligne vide entre les Pokémon
            }


        }
        /*public class BibliothequePokemon
        {
            string pokemonFilePath = "Pokedico.txt"; // Chemin du fichier des Pokémon
            string abilitiesFilePath = "Abilities.txt"; // Chemin du fichier des capacités

            List<Pokemon> pokemons = ReadPokemonFromFile(pokemonFilePath);
            List<Ability> abilities = ReadAbilitiesFromFile(abilitiesFilePath);

         
            foreach (var pokemon in pokemons)
            {

            }
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
}*/
