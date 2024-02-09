namespace Biblio
{
    public static class BibliothequePokemon
    {
        public static List<Pokemon> GetListeStarter()
        {
            List<Pokemon> listePokemon = new List<Pokemon>();

            listePokemon.Add(new Pokemon("Venusaur", "Grass/Poison", 130, 82, 83, 100, 100, 80, new List<Capacite> {new Capacite("Solar Beam", "Grass", 120, 100, "Special"),new Capacite("Sludge Bomb", "Poison", 90, 100, "Special"),new Capacite("Sleep Powder", "Grass", 0, 75, "Status"),new Capacite("Earthquake", "Ground", 100, 100, "Physical")}));

            listePokemon.Add(new Pokemon("Blastoise", "Water", 120, 83, 100, 85, 105, 78, new List<Capacite> {new Capacite("Hydro Pump", "Water", 110, 80, "Special"),new Capacite("Ice Beam", "Ice", 90, 100, "Special"),new Capacite("Flash Cannon", "Steel", 80, 100, "Special"),new Capacite("Protect", "Normal", 0, 100, "Status")}));

            listePokemon.Add(new Pokemon("Charizard", "Fire/Flying", 110, 84, 78, 109, 85, 100, new List<Capacite> {new Capacite("Flamethrower", "Fire", 90, 100, "Special"),new Capacite("Fly", "Flying", 90, 95, "Physical"),new Capacite("Dragon Claw", "Dragon", 80, 100, "Physical"),new Capacite("Solar Beam", "Grass", 120, 100, "Special")}));



            return listePokemon;
        }
        public static List<Pokemon> GetListeMewtwo()
        {
            List<Pokemon> listePokemon = new List<Pokemon>();
            listePokemon.Add(new Pokemon("Mewtwo", "Psychic", 106, 110, 90, 154, 90, 130, new List<Capacite> { new Capacite("Psychic", "Psychic", 90, 100, "Special"), new Capacite("Aura Sphere", "Fighting", 80, 100, "Special"), new Capacite("Shadow Ball", "Ghost", 80, 100, "Special"), new Capacite("Recover", "Normal", 0, 100, "Status") }));


            return listePokemon;
        }
        public static List<Pokemon> GetListePokeZone1()
        {
            List<Pokemon> listePokemon = new List<Pokemon>();

            listePokemon.Add(new Pokemon("Bulbasaur", "Grass/Poison", 45, 49, 49, 65, 65, 45, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("Growl", "Normal", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Charmander", "Fire", 39, 52, 43, 60, 50, 65, new List<Capacite> { new Capacite("Scratch", "Normal", 40, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Charizard", "Fire/Flying", 78, 84, 78, 109, 85, 100, new List<Capacite> { new Capacite("Fire Spin", "Fire", 35, 85, "Special"), new Capacite("Air Slash", "Flying", 75, 95, "Special") }));
            listePokemon.Add(new Pokemon("Squirtle", "Water", 44, 48, 65, 50, 64, 43, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("Bubble", "Water", 40, 100, "Special") }));
            listePokemon.Add(new Pokemon("Caterpie", "Bug", 45, 30, 35, 20, 20, 45, new List<Capacite> { new Capacite("Tackle", "Normal", 40, 100, "Physical"), new Capacite("String Shot", "Bug", 0, 95, "Status") }));
            listePokemon.Add(new Pokemon("Metapod", "Bug", 50, 20, 55, 25, 25, 30, new List<Capacite> { new Capacite("Harden", "Normal", 0, 100, "Status"), new Capacite("Tackle", "Normal", 40, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Butterfree", "Bug/Flying", 60, 45, 50, 90, 80, 70, new List<Capacite> { new Capacite("Gust", "Flying", 40, 100, "Special"), new Capacite("Confusion", "Psychic", 50, 100, "Special") }));
            listePokemon.Add(new Pokemon("Weedle", "Bug/Poison", 40, 35, 30, 20, 20, 50, new List<Capacite> { new Capacite("Poison Sting", "Poison", 15, 100, "Physical"), new Capacite("String Shot", "Bug", 0, 95, "Status") }));
            listePokemon.Add(new Pokemon("Kakuna", "Bug/Poison", 45, 25, 50, 25, 25, 35, new List<Capacite> { new Capacite("Harden", "Normal", 0, 100, "Status"), new Capacite("Poison Sting", "Poison", 15, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Pidgey", "Normal/Flying", 40, 45, 40, 35, 35, 56, new List<Capacite> { new Capacite("Gust", "Flying", 40, 100, "Special"), new Capacite("Quick Attack", "Normal", 40, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Pidgeotto", "Normal/Flying", 63, 60, 55, 50, 50, 71, new List<Capacite> { new Capacite("Wing Attack", "Flying", 60, 100, "Physical"), new Capacite("Twister", "Dragon", 40, 100, "Special") }));
            listePokemon.Add(new Pokemon("Rattata", "Normal", 30, 56, 35, 25, 35, 72, new List<Capacite> { new Capacite("Quick Attack", "Normal", 40, 100, "Physical"), new Capacite("Hyper Fang", "Normal", 80, 90, "Physical") }));
            listePokemon.Add(new Pokemon("Spearow", "Normal/Flying", 40, 60, 30, 31, 31, 70, new List<Capacite> { new Capacite("Peck", "Flying", 35, 100, "Physical"), new Capacite("Fury Attack", "Normal", 15, 85, "Physical") }));
            listePokemon.Add(new Pokemon("Ekans", "Poison", 35, 60, 44, 40, 54, 55, new List<Capacite> { new Capacite("Poison Sting", "Poison", 15, 100, "Physical"), new Capacite("Bite", "Dark", 60, 100, "Physical") }));
            listePokemon.Add(new Pokemon("Pikachu", "Electric", 35, 55, 40, 50, 50, 90, new List<Capacite> { new Capacite("Thunder Shock", "Electric", 40, 100, "Special"), new Capacite("Quick Attack", "Normal", 40, 100, "Physical") }));


            return listePokemon;
        }
        public static List<Pokemon> GetListePokeZone2()
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
        public static List<Pokemon> GetListePokeZone3()
        {
            List<Pokemon> listePokemon = new List<Pokemon>();

            listePokemon.Add(new Pokemon("Venusaur", "Grass/Poison", 80, 82, 83, 100, 100, 80, new List<Capacite> { new Capacite("Solar Beam", "Grass", 120, 100, "Special"), new Capacite("Sludge Bomb", "Poison", 90, 100, "Special"), new Capacite("Sleep Powder", "Grass", 0, 75, "Status"), new Capacite("Earthquake", "Ground", 100, 100, "Physical") }));

            listePokemon.Add(new Pokemon("Blastoise", "Water", 79, 83, 100, 85, 105, 78, new List<Capacite> { new Capacite("Hydro Pump", "Water", 110, 80, "Special"), new Capacite("Ice Beam", "Ice", 90, 100, "Special"), new Capacite("Flash Cannon", "Steel", 80, 100, "Special"), new Capacite("Protect", "Normal", 0, 100, "Status") }));

            listePokemon.Add(new Pokemon("Charizard", "Fire/Flying", 78, 84, 78, 109, 85, 100, new List<Capacite> { new Capacite("Flamethrower", "Fire", 90, 100, "Special"), new Capacite("Fly", "Flying", 90, 95, "Physical"), new Capacite("Dragon Claw", "Dragon", 80, 100, "Physical"), new Capacite("Solar Beam", "Grass", 120, 100, "Special") }));
            listePokemon.Add(new Pokemon("Salamence", "Dragon/Flying", 95, 135, 80, 110, 80, 100, new List<Capacite> { new Capacite("Dragon Claw", "Dragon", 80, 100, "Physical"), new Capacite("Fly", "Flying", 90, 95, "Physical"), new Capacite("Fire Fang", "Fire", 65, 95, "Physical"), new Capacite("Dragon Dance", "Dragon", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Garchomp", "Dragon/Ground", 108, 130, 95, 80, 85, 102, new List<Capacite> { new Capacite("Dragon Claw", "Dragon", 80, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical"), new Capacite("Fire Fang", "Fire", 65, 95, "Physical"), new Capacite("Swords Dance", "Normal", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Alakazam", "Psychic", 55, 50, 45, 135, 95, 120, new List<Capacite> { new Capacite("Psychic", "Psychic", 90, 100, "Special"), new Capacite("Focus Blast", "Fighting", 120, 70, "Special"), new Capacite("Shadow Ball", "Ghost", 80, 100, "Special"), new Capacite("Calm Mind", "Psychic", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Lucario", "Fighting/Steel", 70, 110, 70, 115, 70, 90, new List<Capacite> { new Capacite("Aura Sphere", "Fighting", 80, 100, "Special"), new Capacite("Flash Cannon", "Steel", 80, 100, "Special"), new Capacite("Dark Pulse", "Dark", 80, 100, "Special"), new Capacite("Swords Dance", "Normal", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Gyarados", "Water/Flying", 95, 125, 79, 60, 100, 81, new List<Capacite> { new Capacite("Hydro Pump", "Water", 110, 80, "Special"), new Capacite("Hurricane", "Flying", 110, 70, "Special"), new Capacite("Ice Fang", "Ice", 65, 95, "Physical"), new Capacite("Dragon Dance", "Dragon", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Dragonite", "Dragon/Flying", 91, 134, 95, 100, 100, 80, new List<Capacite> { new Capacite("Outrage", "Dragon", 120, 100, "Physical"), new Capacite("Fire Punch", "Fire", 75, 100, "Physical"), new Capacite("Thunder Punch", "Electric", 75, 100, "Physical"), new Capacite("Roost", "Flying", 0, 100, "Status") }));
            listePokemon.Add(new Pokemon("Tyranitar", "Rock/Dark", 100, 134, 110, 95, 100, 61, new List<Capacite> { new Capacite("Stone Edge", "Rock", 100, 80, "Physical"), new Capacite("Crunch", "Dark", 80, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical"), new Capacite("Hyper Beam", "Normal", 150, 90, "Special") }));
            listePokemon.Add(new Pokemon("Metagross", "Steel/Psychic", 80, 135, 130, 95, 90, 70, new List<Capacite> { new Capacite("Meteor Mash", "Steel", 90, 90, "Physical"), new Capacite("Psychic", "Psychic", 90, 100, "Special"), new Capacite("Hammer Arm", "Fighting", 100, 90, "Physical"), new Capacite("Bullet Punch", "Steel", 40, 100, "Physical") }));

            listePokemon.Add(new Pokemon("Zapdos", "Electric/Flying", 90, 90, 85, 125, 90, 100, new List<Capacite> { new Capacite("Thunderbolt", "Electric", 90, 100, "Special"), new Capacite("Drill Peck", "Flying", 80, 100, "Physical"), new Capacite("Heat Wave", "Fire", 95, 90, "Special"), new Capacite("Roost", "Flying", 0, 100, "Status") }));


            listePokemon.Add(new Pokemon("Machamp", "Fighting", 90, 130, 80, 65, 85, 55, new List<Capacite> { new Capacite("Dynamic Punch", "Fighting", 100, 50, "Physical"), new Capacite("Knock Off", "Dark", 65, 100, "Physical"), new Capacite("Stone Edge", "Rock", 100, 80, "Physical"), new Capacite("Bulk Up", "Fighting", 0, 100, "Status") }));


            listePokemon.Add(new Pokemon("Snorlax", "Normal", 160, 110, 65, 65, 110, 30, new List<Capacite> { new Capacite("Body Slam", "Normal", 85, 100, "Physical"), new Capacite("Crunch", "Dark", 80, 100, "Physical"), new Capacite("Earthquake", "Ground", 100, 100, "Physical"), new Capacite("Rest", "Psychic", 0, 100, "Status") }));


            listePokemon.Add(new Pokemon("Arcanine", "Fire", 90, 110, 80, 100, 80, 95, new List<Capacite> { new Capacite("Flare Blitz", "Fire", 120, 100, "Physical"), new Capacite("Extreme Speed", "Normal", 80, 100, "Physical"), new Capacite("Wild Charge", "Electric", 90, 100, "Physical"), new Capacite("Morning Sun", "Normal", 0, 100, "Status") }));

            listePokemon.Add(new Pokemon("Gardevoir", "Psychic/Fairy", 68, 65, 65, 125, 115, 80, new List<Capacite> { new Capacite("Psychic", "Psychic", 90, 100, "Special"), new Capacite("Moonblast", "Fairy", 95, 100, "Special"), new Capacite("Shadow Ball", "Ghost", 80, 100, "Special"), new Capacite("Calm Mind", "Psychic", 0, 100, "Status") }));



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
