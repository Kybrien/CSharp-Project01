using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            public Pokemon(string name, string type, int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
            {
                this.name = name;
                this.type = type;
                this.hp = hp;
                this.attack = attack;
                this.defense = defense;
                this.specialAttack = specialAttack;
                this.specialDefense = specialDefense;
                this.speed = speed;
            }

            public void UsePotion()
            {
                hp += 10;
                Console.WriteLine("Vous avez soigné 10 PV.");
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
                Console.WriteLine($"{name} - \nHP: {hp}\nAttack: {attack}\nDefense: {defense}\nSpecial Attack: {specialAttack}\nSpecial Defense: {specialDefense}\nSpeed: {speed}");
            }

            // Accessor methods
            public string GetName() => name;
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

            public Ability(string name, int power, double accuracy, string category)
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


public class Program
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

        public static void txtest(string[] args)
        {
            string filePath = "./CSharp-Project01/Pokedico.txt"; // Remplacez par le chemin réel de votre fichier
            List<Pokemon> pokemons = ReadPokemonFromFile(filePath);

            // Affichage des Pokémon pour vérifier la lecture du fichier
            foreach (Pokemon pokemon in pokemons)
            {
                pokemon.DisplayStats();
                Console.WriteLine(); // Pour ajouter une ligne vide entre les Pokémon
            }

            // Ici, vous pouvez ajouter la logique pour initialiser le jeu, choisir des Pokémon, etc.
        }
    }

}

