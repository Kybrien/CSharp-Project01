using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblio;
using CombatLoader;

namespace Team
{
    public class PokeTeam
    {
        public static List<Pokemon> equipe = new List<Pokemon>();

        // Ajouter un Pokémon à l'équipe
        public static void AjouterPokemon(Pokemon pokemon)
        {
            if (equipe.Count < 6) // Limite d'équipe à 6 Pokémon
            {
                equipe.Add(pokemon);
            }
            else
            {
                Console.WriteLine("L'équipe est pleine !");
            }
        }

        // Retirer un Pokémon de l'équipe
        public void RetirerPokemon(Pokemon pokemon)
        {
            equipe.Remove(pokemon);
        }

        // Obtenir la liste des Pokémon de l'équipe
        public static List<Pokemon> ObtenirEquipe()
        {
            return equipe;
        }

        // Choisir un Pokémon actif pour le combat
        public Pokemon ChoisirActif(int index)
        {
            if (index >= 0 && index < equipe.Count)
            {
                return equipe[index];
            }
            return null; // Gérer l'erreur si l'index est invalide
        }
        public bool EstVide()
        {
            return equipe.Count == 0;
        }


    }
}
