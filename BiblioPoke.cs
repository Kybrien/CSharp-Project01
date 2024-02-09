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
            listePokemon.Add(new Pokemon("Squirtle", "Water", 44, 48, 65, 50, 64, 43, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("Bubble", "Water", 40, 100, "Special") }));
            listePokemon.Add(new Pokemon("Wartortle", "Water", 59, 63, 80, 65, 80, 58, new List<Capacite> { new Capacite("Bite", "Dark", 60, 100, "Physical"), new Capacite("Water Pulse", "Water", 60, 100, "Special") }));
            listePokemon.Add(new Pokemon("Blastoise", "Water", 79, 83, 100, 85, 105, 78, new List<Capacite> { new Capacite("Ice Beam", "Ice", 90, 100, "Special"), new Capacite("Hydro Pump", "Water", 110, 80, "Special") }));
            listePokemon.Add(new Pokemon("Caterpie", "Bug", 45, 30, 35, 20, 20, 45, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("String Shot", "Bug", 0, 95, "Status") }));
            listePokemon.Add(new Pokemon("Metapod", "Bug", 50, 20, 55, 25, 25, 30, new List<Capacite> { new Capacite("Harden", "Normal", 0, 100, "Status"), new Capacite("Tackle", "Normal", 40, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Butterfree", "Bug/Flying", 60, 45, 50, 90, 80, 70, new List<Capacite> { new Capacite("Gust", "Flying", 40, 100, "Special"), new Capacite("Confusion", "Psychic", 50, 100, "Special") }));
            listePokemon.Add(new Pokemon("Weedle", "Bug/Poison", 40, 35, 30, 20, 20, 50, new List<Capacite> { new Capacite("Poison Sting", "Poison", 15, 100, "Physical"), new Capacite("String Shot", "Bug", 0, 95, "Status") }));
            listePokemon.Add(new Pokemon("Kakuna", "Bug/Poison", 45, 25, 50, 25, 25, 35, new List<Capacite> { new Capacite("Harden", "Normal", 0, 100, "Status"), new Capacite("Poison Sting", "Poison", 15, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Beedrill", "Bug/Poison", 65, 90, 40, 45, 80, 75, new List<Capacite> { new Capacite("Twineedle", "Bug", 25, 100, "Physical"), new Capacite("Rage", "Normal", 20, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Pidgey", "Normal/Flying", 40, 45, 40, 35, 35, 56, new List<Capacite> { new Capacite("Gust", "Flying", 40, 100, "Special"), new Capacite("Quick Attack", "Normal", 40, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Pidgeotto", "Normal/Flying", 63, 60, 55, 50, 50, 71, new List<Capacite> { new Capacite("Wing Attack", "Flying", 60, 100, "Physical"), new Capacite("Twister", "Dragon", 40, 100, "Special") }));
            listePokemon.Add(new Pokemon("Pidgeot", "Normal/Flying", 83, 80, 75, 70, 70, 101, new List<Capacite> { new Capacite("Air Slash", "Flying", 75, 95, "Special"), new Capacite("Feather Dance", "Flying", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Rattata", "Normal", 30, 56, 35, 25, 35, 72, new List<Capacite> { new Capacite("Quick Attack", "Normal", 40, 100, "Physical"), new Capacite("Hyper Fang", "Normal", 80, 90, "Physical") }));
            listePokemon.Add(new Pokemon("Raticate", "Normal", 55, 81, 60, 50, 70, 97, new List<Capacite> { new Capacite("Crunch", "Dark", 80, 100, "Physical"), new Capacite("Sucker Punch", "Dark", 70, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Spearow", "Normal/Flying", 40, 60, 30, 31, 31, 70, new List<Capacite> { new Capacite("Peck", "Flying", 35, 100, "Physical"), new Capacite("Fury Attack", "Normal", 15, 85, "Physical") }));
            listePokemon.Add(new Pokemon("Fearow", "Normal/Flying", 65, 90, 65, 61, 61, 100, new List<Capacite> { new Capacite("Drill Peck", "Flying", 80, 100, "Physical"), new Capacite("Mirror Move", "Flying", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Ekans", "Poison", 35, 60, 44, 40, 54, 55, new List<Capacite> { new Capacite("Poison Sting", "Poison", 15, 100, "Physical"), new Capacite("Bite", "Dark", 60, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Arbok", "Poison", 60, 85, 69, 65, 79, 80, new List<Capacite> { new Capacite("Acid", "Poison", 40, 100, "Special"), new Capacite("Wrap", "Normal", 15, 90, "Physical") }));
            listePokemon.Add(new Pokemon("Pikachu", "Electric", 35, 55, 40, 50, 50, 90, new List<Capacite> { new Capacite("Thunder Shock", "Electric", 40, 100, "Special"), new Capacite("Quick Attack", "Normal", 40, 100, "Physical") }));


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
            PointsDeVie += 30 ;
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
