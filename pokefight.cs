using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fight
{
        public class Pokemon
        {
            private string name;
            private int hp;
            private int attack;
            private int defense;
            private int specialAttack;
            private int specialDefense;
            private int speed;
            public int Potion { get; set; } = 5;

            public Pokemon(string name, int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
            {
                this.name = name;
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
    }

