using Display;
using StoryLoader;
using Biblio;
using MoveControl;
using Anim;
using SoundLoader;
namespace CombatLoader
{
    public class Combat
    {
        public static bool fight_end { get; set; } = false;
        public static Random random2 = new Random();

        public static List<Pokemon> listePokemon = BibliothequePokemon.GetListePokemon();
        public static Pokemon pokemonJoueur = listePokemon[random2.Next(listePokemon.Count)];
        private static bool gameover = false;

        public static void LancerCombatSiRencontrePokemon(char[,] carte, int playerPosX, int playerPosY)
        {
            Random random = new Random();

            // Vérifier si le joueur est sur une case avec un Pokémon (case 'H')
            if (carte[playerPosY, playerPosX] == 'H')
            {
                // Vérifier aléatoirement s'il y a une rencontre avec un Pokémon
                if (random.Next(1, 10) == 1)
                {
                    if (Program.currentMapIndex == 0 || Program.currentMapIndex == 1)
                    {
                        Sound.ChangeMusicBasedOnMap(8);
                    }
                    if (Program.currentMapIndex == 2 || Program.currentMapIndex == 3)
                    {
                        Sound.ChangeMusicBasedOnMap(9);
                    }
                    if (Program.currentMapIndex == 4 || Program.currentMapIndex == 5)
                    {
                        Sound.ChangeMusicBasedOnMap(10);
                    }
                    // ---------------------------------Rencontre un Pokémon---------------------------------
                    // Sélectionner un Pokémon au hasard depuis la bibliothèque
                    List<Pokemon> listePokemon = BibliothequePokemon.GetListePokemon();
                    Pokemon pokemonRencontre = listePokemon[random.Next(listePokemon.Count)];

                    int pvMaxRencontre = pokemonRencontre.PointsDeVie;
                    int pvMaxJoueur = pokemonJoueur.PointsDeVie;

                    Animation.Fight_Anim();
                    Console.WriteLine("\n_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                    TextDisplay.Sleeping($"\nVotre Pokémon actuel : {pokemonJoueur.Nom}\n",10);
                    TextDisplay.Sleeping($"{pokemonJoueur.Nom} - \nHP: {pokemonJoueur.PointsDeVie}\nType : {pokemonJoueur.Type}\nAttack: {pokemonJoueur.Attack}\nDefense: {pokemonJoueur.Defense}\nSpecial Attack: {pokemonJoueur.SpecialAttack}\nSpecial Defense: {pokemonJoueur.SpecialDefense}\nSpeed: {pokemonJoueur.Speed}",10);
                    //On attend que l'utilisateur appuie sur une touche pour continuer
                    Console.ReadKey();
                    fight_end = true;
                    
                    Console.Clear();
                    // Combat
                    while (fight_end)
                    {
                        if (pokemonRencontre.PointsDeVie <= 0)
                        {
                            Console.WriteLine($"Vous avez vaincu le {pokemonRencontre.Nom} sauvage !\n");
                            Console.WriteLine("Votre Pokémon est soigné\n");
                            pokemonJoueur.PointsDeVie = pvMaxJoueur;
                            Console.ReadKey();

                            fight_end = false;

                            break;
                        }
                        if (pokemonJoueur.PointsDeVie <= 0)
                        {
                            Console.WriteLine($"Vous avez été vaincu par le {pokemonRencontre.Nom} sauvage !\n");
                            Console.WriteLine("Votre Pokémon est soigné");
                            pokemonJoueur.PointsDeVie = pvMaxJoueur;
                            Thread.Sleep(500);

                            gameover = true;
                            fight_end = false;
                            break;
                        }
                        Console.Clear() ;
                        Console.WriteLine("╔══════════════════════════════════╗");
                        Console.WriteLine("║               COMBAT             ║");
                        Console.WriteLine("╚══════════════════════════════════╝");
                        Console.WriteLine($"{pokemonRencontre.Nom}: {pokemonRencontre.PointsDeVie}/{pvMaxRencontre} PV");
                        Console.WriteLine($"{pokemonJoueur.Nom}: {pokemonJoueur.PointsDeVie}/{pvMaxJoueur} PV");

                        // Tour du joueur
                        Console.WriteLine("\n<------------------------------------>\nC'est à votre tour, que voulez-vous faire :\n");
                        AfficherCapacitesJoueur(pokemonJoueur);
                        int choixCapacite = DemanderChoixCapacite(pokemonJoueur.Capacites.Count);
                        Move.ManageMoveJ(pokemonJoueur,pokemonRencontre,pokemonJoueur.Capacites[choixCapacite - 1]);


                        // Tour du Pokémon sauvage
                        Console.WriteLine($"\nC'est au tour du {pokemonRencontre.Nom} sauvage :");
                        iaEasy(pokemonRencontre,pokemonJoueur);
                    }

                    // Réinitialiser la case de la carte à 'H' seulement si le Pokémon n'a pas été vaincu
                    carte[playerPosY, playerPosX] = 'H';
                    if (gameover)
                    {
                        Story.GameOver();
                    }
                    Sound.AutoOST();
                }
            }
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
        public static void iaEasy(Pokemon pokemon_attacker, Pokemon pokemon_defender)
        {
            Random random = new Random();

            for (int i = 0; i < 1; i++)
            {
                int choixCapacite = random.Next(1, pokemon_attacker.Capacites.Count + 1);

                // Appliquer les dégâts au joueur
                Move.ManageMoveE(pokemon_attacker, pokemon_defender, pokemon_attacker.Capacites[choixCapacite - 1]);
                //Console.WriteLine($"{pokemon.Nom} a utilisé {pokemon.Capacites[choixCapacite - 1].Nom} !");
                
            }
        }
    }
     
}
