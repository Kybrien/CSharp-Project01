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

                        if (list.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Water":
                        var list2 = new string[] { "Fire", "Ground", "Rock" };

                        if (list2.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Electric":
                        var list3 = new string[] { "Water", "Flying" };

                        if (list3.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Grass":
                        var list4 = new string[] { "Water", "Ground", "Rock" };

                        if (list4.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Ice":
                        var list5 = new string[] { "Grass", "Ground", "Flying", "Dragon" };

                        if (list5.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Fighting":
                        var list6 = new string[] { "Normal", "Ice", "Rock", "Dark", "Steel" };

                        if (list6.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Poison":
                        var list7 = new string[] { "Grass", "Fairy" };

                        if (list7.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Ground":
                        var list8 = new string[] { "Fire", "Electric", "Poison", "Rock", "Steel" };

                        if (list8.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Flying":
                        var list9 = new string[] { "Grass", "Fighting", "Bug" };

                        if (list9.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Psychic":
                        var list10= new string[] { "Fighting", "Poison" };

                        if (list10.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Bug": 
                        var list11 = new string[] { "Grass", "Psychic", "Dark" };

                        if (list11.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Rock":
                        var list12 = new string[] { "Fire", "Ice", "Flying", "Bug" };

                        if (list12.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Ghost":
                        var list13 = new string[] { "Psychic", "Ghost" };

                        if (list13.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Dragon":
                        var list14 = new string[] { "Dragon" };

                        if (list14.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Dark":
                        var list15 = new string[] { "Psychic", "Ghost" };

                        if (list15.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Steel":
                        var list16 = new string[] { "Ice", "Rock", "Fairy" };

                        if (list16.Contains(type))
                        {
                            return true;
                        }

                        break;
                    case "Fairy":
                        var list17 = new string[] { "Fighting", "Dragon", "Dark" };

                        if (list17.Contains(type))
                        {
                            return true;
                        }

                        break;

                }
            }

            return false; // Retourne faux si l'attaque n'est super efficace contre aucun des types
        }
        public static bool IsNotVeryEffectiveSwitch(string attackingType, string defendingTypes)
        {
            // Séparation des types du défenseur s'il y en a plusieurs
            var types = defendingTypes.Split('/');

            // Vérification pour chaque type de défense
            foreach (var type in types)
            {
                switch (attackingType)
                {
                    case "Fire":
                        var list = new string[] { "Fire", "Water", "Rock", "Dragon" };
                        if (list.Contains(type)) { return true; }
                        break;
                    case "Water":
                        var list2 = new string[] { "Water", "Grass", "Dragon" };
                        if (list2.Contains(type)) { return true; }
                        break;
                    case "Electric":
                        var list3 = new string[] { "Electric", "Grass", "Dragon", "Ground" };
                        if (list3.Contains(type)) { return true; }
                        break;
                    case "Grass":
                        var list4 = new string[] { "Fire", "Grass", "Poison", "Flying", "Bug", "Dragon", "Steel" };
                        if (list4.Contains(type)) { return true; }
                        break;
                    case "Ice":
                        var list5 = new string[] { "Fire", "Water", "Ice", "Steel" };
                        if (list5.Contains(type)) { return true; }
                        break;
                    case "Fighting":
                        var list6 = new string[] { "Poison", "Flying", "Psychic", "Bug", "Fairy" };
                        if (list6.Contains(type)) { return true; }
                        break;
                    case "Poison":
                        var list7 = new string[] { "Poison", "Ground", "Rock", "Ghost" };
                        if (list7.Contains(type)) { return true; }
                        break;
                    case "Ground":
                        var list8 = new string[] { "Grass", "Bug" };
                        if (list8.Contains(type)) { return true; }
                        break;
                    case "Flying":
                        var list9 = new string[] { "Electric", "Rock", "Steel" };
                        if (list9.Contains(type)) { return true; }
                        break;
                    case "Psychic":
                        var list10 = new string[] { "Psychic", "Steel" };
                        if (list10.Contains(type)) { return true; }
                        break;
                    case "Bug":
                        var list11 = new string[] { "Fire", "Fighting", "Poison", "Flying", "Ghost", "Steel", "Fairy" };
                        if (list11.Contains(type)) { return true; }
                        break;
                    case "Rock":
                        var list12 = new string[] { "Fighting", "Ground", "Steel" };
                        if (list12.Contains(type)) { return true; }
                        break;
                    case "Ghost":
                        var list13 = new string[] { "Dark" };
                        if (list13.Contains(type)) { return true; }
                        break;
                    case "Dragon":
                        var list14 = new string[] { "Steel" };
                        if (list14.Contains(type)) { return true; }
                        break;
                    case "Dark":
                        var list15 = new string[] { "Fighting", "Dark", "Fairy" };
                        if (list15.Contains(type)) { return true; }
                        break;
                    case "Steel":
                        var list16 = new string[] { "Fire", "Water", "Electric", "Steel" };
                        if (list16.Contains(type)) { return true; }
                        break;
                    case "Fairy":
                        var list17 = new string[] { "Fire", "Poison", "Steel" };
                        if (list17.Contains(type)) { return true; }
                        break;
                }
            }

            return false; // Retourne faux si l'attaque n'est pas très efficace contre aucun des types
        }

    }
}


