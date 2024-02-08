using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Biblio;

namespace game
{
    internal class DisplayPokeStat
    {
        public List<Pokemon> team_poke = new List<Pokemon>();
        public List<Capacite> abilities = new List<Capacite>();

        public DisplayPokeStat()
        {
            Capacite feu = new Capacite("tes1","feu",15,15,"zob");
            Capacite eau = new Capacite("tes2", "eau", 118, 161, "zob");
            abilities.Add(feu);
            abilities.Add(eau);
            team_poke.Add(new Pokemon("BULBIBOZAR", "feu", 15, 15, 15, 15, 15, 15, abilities));
            team_poke.Add(new Pokemon("DORKLOFA", "Orage", 14, 19, 15, 19, 14, 15, abilities));
        }

        public DisplayPokeStat(List<Pokemon> team_poke)
        {
            this.team_poke = team_poke;
        }

        public void ShowPokeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Liste des Pokémon ===");

                // Afficher la liste des Pokémon avec leurs noms
                for (int i = 0; i < team_poke.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {team_poke[i].Nom}");
                }
                Console.WriteLine($"{team_poke.Count + 1}. Fermer le menu");

                // Sélectionner un Pokémon
                Console.Write($"\nSélectionnez un Pokémon : ");
                int selectedPokemonIndex;
                while (!int.TryParse(Console.ReadLine(), out selectedPokemonIndex) ||
                    selectedPokemonIndex < 1 || selectedPokemonIndex > team_poke.Count + 1)
                {
                    Console.WriteLine("Veuillez entrer un numéro valide.");
                }

                // Vérifier si l'option de fermeture du menu a été sélectionnée
                if (selectedPokemonIndex == team_poke.Count + 1)
                {
                    break;
                }

                // Afficher les statistiques du Pokémon sélectionné
                Pokemon selectedPokemon = team_poke[selectedPokemonIndex - 1];
                Console.Clear();
                Console.WriteLine($"=== Statistiques de {selectedPokemon.Nom} ===");
                Console.WriteLine($"Type: {selectedPokemon.Type}");
                Console.WriteLine($"Attaque: {selectedPokemon.Attack}");
                Console.WriteLine($"Défense: {selectedPokemon.Defense}");
                Console.WriteLine($"Vitesse: {selectedPokemon.Speed}");
                Console.WriteLine($"=== Capacités de {selectedPokemon.Nom} ===");
                for (int i = 0; i < selectedPokemon.Capacites.Count; i++)
                {
                    Capacite capa = selectedPokemon.Capacites[i];
                    Console.WriteLine($"Capacité {i + 1}:");
                    Console.WriteLine($"    Nom: {capa.Nom}");
                    Console.WriteLine($"    Type: {capa.Type}");
                    Console.WriteLine($"    Puissance: {capa.Puissance}");
                    Console.WriteLine($"    Précision: {capa.Precision}");
                }

                // Attendre une entrée pour revenir au menu principal
                Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
                Console.ReadKey();
            }
        }
    }
}
