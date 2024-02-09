using Biblio;
using Effectiveness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveControl
{
    public class Move
    {
        public static void ManageMoveJ(Pokemon attacker, Pokemon defender, Capacite attackAbility)
        {
            Random rand = new Random();
            int randomChance = rand.Next(100);
            string cat = attackAbility.Category;
            Console.WriteLine($"capacité : {attackAbility.Nom}");
            switch (cat)
            {
                case "Physical":
                    int damage = (attackAbility.Puissance + attacker.Attack) * 5 / defender.Defense + 10;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        
                        if (Effective.IsSuperEffectiveSwitch(attackAbility.Type, defender.Type))
                        {
                            damage *= 2;
                            Console.WriteLine("L'attaque est super efficace !");
                        }
                        Console.WriteLine($"{defender.Nom} a subi {damage} dommages.");

                        defender.TakeDamage(damage);

                    }
                    else
                    {
                        Console.WriteLine("L'attaque a échoué !");
                    }
                    break;
                case "Special":
                    int spe_damage = (attackAbility.Puissance + attacker.SpecialAttack) * 5 / defender.SpecialDefense + 10;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        if (Effective.IsSuperEffectiveSwitch(attackAbility.Type, defender.Type))
                        {
                            spe_damage *= 2;
                            Console.WriteLine("L'attaque est super efficace !");
                        }
                        Console.WriteLine($"{defender.Nom} a subi {spe_damage} dommages.");
                        defender.TakeDamage(spe_damage);
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
        public static void ManageMoveE(Pokemon attacker, Pokemon defender, Capacite attackAbility)
        {
            Random rand = new Random();
            int randomChance = rand.Next(100);
            string cat = attackAbility.Category;
            Console.WriteLine($"capacité : {attackAbility.Nom}");
            switch (cat)
            {
                case "Physical":
                    int damage = (attackAbility.Puissance + attacker.Attack) * 5 / defender.Defense + 10;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        if (Effective.IsSuperEffectiveSwitch(attackAbility.Type, defender.Type))
                        {
                            damage *= 2;
                            Console.WriteLine("L'attaque est super efficace !");
                        }
                        Console.WriteLine($"{defender.Nom} a subi {damage} dommages.");
                        defender.TakeDamage(damage);
                    }
                    else
                    {
                        Console.WriteLine("L'attaque a échoué !");
                    }
                    break;
                case "Special":
                    int spe_damage = (attackAbility.Puissance + attacker.SpecialAttack) * 5 / defender.SpecialDefense + 10;
                    Console.WriteLine($"{attacker.Nom} attaque !");
                    if (randomChance <= attackAbility.Precision)
                    {
                        if (Effective.IsSuperEffectiveSwitch(attackAbility.Type, defender.Type))
                        {
                            spe_damage *= 2;
                            Console.WriteLine("L'attaque est super efficace !");
                        }
                        Console.WriteLine($"{defender.Nom} a subi {spe_damage} dommages.");
                        defender.TakeDamage(spe_damage);
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
    }
}
