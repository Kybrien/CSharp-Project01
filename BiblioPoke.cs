using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CombatLoader.Combat;

namespace Biblio
{
    public static class BibliothequePokemon
    {
        public static List<Pokemon> GetListePokemon()
        {
            List<Pokemon> listePokemon = new List<Pokemon>();


            listePokemon.Add(new Pokemon("Bulbasaur", "Grass/Poison", 45, 49, 49, 65, 65, 45, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("Growl", "Normal", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Ivysaur", "Grass/Poison", 60, 62, 63, 80, 80, 60, new List<Capacite> { new Capacite("Vine Whip", "Grass", 45, 100, "Physical"), new Capacite("Take Down", "Normal", 90, 85, "Physical") }));
            listePokemon.Add(new Pokemon("Venusaur", "Grass/Poison", 80, 82, 83, 100, 100, 80, new List<Capacite> { new Capacite("Petal Blizzard", "Grass", 90, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Charmander", "Fire", 39, 52, 43, 60, 50, 65, new List<Capacite> { new Capacite("Scratch", "Normal", 40, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Charmeleon", "Fire", 58, 64, 58, 80, 65, 80, new List<Capacite> { new Capacite("Flamethrower", "Fire", 90, 100, "Special"), new Capacite("Smokescreen", "Normal", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Charizard", "Fire/Flying", 78, 84, 78, 109, 85, 100, new List<Capacite> { new Capacite("Fire Spin", "Fire", 35, 85, "Special"), new Capacite("Air Slash", "Flying", 75, 95, "Special") }));
            listePokemon.Add(new Pokemon("Squirtle", "Water", 44, 48, 65, 50, 64, 43, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("Bubble", "Water", 40, 100, "Special") }));
            listePokemon.Add(new Pokemon("Wartortle", "Water", 59, 63, 80, 65, 80, 58, new List<Capacite> { new Capacite("Bite", "Dark", 60, 100, "Physical"), new Capacite("Water Pulse", "Water", 60, 100, "Special") }));
            listePokemon.Add(new Pokemon("Blastoise", "Water", 79, 83, 100, 85, 105, 78, new List<Capacite> { new Capacite("Ice Beam", "Ice", 90, 100, "Special"), new Capacite("Hydro Pump", "Water", 110, 80, "Special") }));
            // ... Ajoutez d'autres Pokémon de la même manière

            return listePokemon;
        }
    }
    public class Pokemon
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public int PointsDeVie { get; set; }
        public int Attack;
        public int Defense;
        public int SpecialAttack;
        public int SpecialDefense;
        public int Speed;


        public int Potion { get; set; } = 5;
        public List<Capacite> Capacites { get; set; }

        public Pokemon(string nom, string type, int pointsDeVie, int attack, int defense, int specialAttack, int specialDefense, int speed, List<Capacite> capacites)
        {
            Nom = nom;
            Type = type;
            PointsDeVie = pointsDeVie;
            Attack = attack;
            Defense = defense;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;

            Capacites = capacites;
        }
        public void UsePotion()
        {
            PointsDeVie = ;
            Console.WriteLine("Vous avez soigné 30 PV.");
            Potion--;
            Console.WriteLine($"Il vous reste {Potion} potions.");
        }
        public void DisplayStats(Pokemon pokemon)
        {
            Console.WriteLine($"{pokemon.Nom} - \nHP: {pokemon.PointsDeVie}\nType : {pokemon.Type}\nAttack: {pokemon.Attack}\nDefense: {pokemon.Defense}\nSpecial Attack: {pokemon.SpecialAttack}\nSpecial Defense: {pokemon.SpecialDefense}\nSpeed: {pokemon.Speed}");
        }
        public int TakeDamage(int damage)
        {
            PointsDeVie -= damage;
            return PointsDeVie;
        }



    }
    public class Capacite
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public int Puissance { get; set; }

        public int Precision { get; set; }
        public string Category { get; set; }



        public Capacite(string nom, string type, int puissance, int precision, string category)
        {
            Nom = nom;
            Type = type;
            Puissance = puissance;
            Precision = precision;
            Category = category;
        }
    }

}
