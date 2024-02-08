namespace Effectiveness
{
    public class TypeEffectiveness
    {
        public Dictionary<string, List<string>> effectivenessChart;

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
