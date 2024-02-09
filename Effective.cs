using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effectiveness
{
    public class Effective
    {
        public Dictionary<string, List<string>> effectivenessChart;

        public Effective()
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

        public static bool IsSuperEffectiveSwitch(string attackingType, string defendingTypes)
        {
            // Séparation des types du défenseur s'il y en a plusieurs
            var types = defendingTypes.Split('/');

            // Vérification pour chaque type de défense
            foreach (var type in types)
            {
                switch (attackingType) 
                {
                    case "Fire":
                        var list = new string[] { "Grass", "Ice", "Bug", "Steel" };

                        if (list.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Water":
                        var list2 = new string[] { "Fire", "Ground", "Rock" };

                        if (list2.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Electric":
                        var list3 = new string[] { "Water", "Flying" };

                        if (list3.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Grass":
                        var list4 = new string[] { "Water", "Ground", "Rock" };

                        if (list4.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Ice":
                        var list5 = new string[] { "Grass", "Ground", "Flying", "Dragon" };

                        if (list5.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Fighting":
                        var list6 = new string[] { "Normal", "Ice", "Rock", "Dark", "Steel" };

                        if (list6.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Poison":
                        var list7 = new string[] { "Grass", "Fairy" };

                        if (list7.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Ground":
                        var list8 = new string[] { "Fire", "Electric", "Poison", "Rock", "Steel" };

                        if (list8.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Flying":
                        var list9 = new string[] { "Grass", "Fighting", "Bug" };

                        if (list9.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Psychic":
                        var list10= new string[] { "Fighting", "Poison" };

                        if (list10.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Bug": 
                        var list11 = new string[] { "Grass", "Psychic", "Dark" };

                        if (list11.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Rock":
                        var list12 = new string[] { "Fire", "Ice", "Flying", "Bug" };

                        if (list12.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Ghost":
                        var list13 = new string[] { "Psychic", "Ghost" };

                        if (list13.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Dragon":
                        var list14 = new string[] { "Dragon" };

                        if (list14.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Dark":
                        var list15 = new string[] { "Psychic", "Ghost" };

                        if (list15.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Steel":
                        var list16 = new string[] { "Ice", "Rock", "Fairy" };

                        if (list16.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;
                    case "Fairy":
                        var list17 = new string[] { "Fighting", "Dragon", "Dark" };

                        if (list17.Contains(defendingTypes))
                        {
                            return true;
                        }

                        break;

                }
            }

            return false; // Retourne faux si l'attaque n'est super efficace contre aucun des types
        }
    }
}
