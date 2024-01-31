using System;
using System.Threading;

class Program
{
    static bool quit = false;
    static int posX = 1, posY = 1;


public class Pokemon
{
    private string name;
    private int hp;
    private int attack;
    private int defense;
    private int specialAttack;
    private int specialDefense;
    private int speed;
    public int Potion { get; set; } = 5;

    public Pokemon(string name, int hp, int attack, int defense, int specialAttack, int specialDefense, int speed)
    {
        this.name = name;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.specialAttack = specialAttack;
        this.specialDefense = specialDefense;
        this.speed = speed;
    }

    public void UsePotion()
    {
        hp += 10;
        Console.WriteLine("Vous avez soigné 10 PV.");
        Potion--;
        Console.WriteLine($"Il vous reste {Potion} potions.");
    }

    public int TakeDamage(int damage)
    {
        hp -= damage;
        return hp;
    }

    public void LowerAttack()
    {
        attack -= 5;
    }

    public void LowerDefense()
    {
        defense -= 5;
    }

    public bool IsFainted()
    {
        return hp <= 0;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"{name} - \nHP: {hp}\nAttack: {attack}\nDefense: {defense}\nSpecial Attack: {specialAttack}\nSpecial Defense: {specialDefense}\nSpeed: {speed}");
    }

    // Accessor methods
    public string GetName() => name;
    public int GetHp() => hp;
    public int GetSpeed() => speed;
    public int GetAttack() => attack;
    public int GetDefense() => defense;
    public int GetSpecialAttack() => specialAttack;
    public int GetSpecialDefense() => specialDefense;
}

public class Ability
{
    private string name;
    private int power;
    private double accuracy;
    private string category; // "Physical", "Special", or "Status"

    public Ability(string name, int power, double accuracy, string category)
    {
        this.name = name;
        this.power = power;
        this.accuracy = accuracy;
        this.category = category;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {name}\nPower: {power}\nAccuracy: {accuracy}\nCategory: {category}");
    }

    public string GetName() => name;
    public int GetPower() => power;
    public double GetAccuracy() => accuracy;
}

public class Move
{
    public static void ManageMove(int choice, Pokemon attacker, Pokemon defender, Ability attackAbility, Ability statusAbility)
    {
        Random rand = new Random();
        int randomChance = rand.Next(100);

        switch (choice)
        {
            case 1:
                int damage = (attackAbility.GetPower() + (attacker.GetAttack() / defender.GetDefense())) / 8 + 1;
                Console.WriteLine($"{attacker.GetName()} attaque !");
                if (randomChance <= attackAbility.GetAccuracy())
                {
                    Console.WriteLine($"{defender.GetName()} a subi {damage} dommages.");
                    defender.TakeDamage(damage);
                }
                else
                {
                    Console.WriteLine("L'attaque a échoué !");
                }
                break;
            case 2:
                if (statusAbility.GetName() == "Growl")
                {
                    Console.WriteLine($"{attacker.GetName()} a affaibli l'attaque de l'ennemi.");
                    defender.LowerAttack();
                }
                else if (statusAbility.GetName() == "Tail Whip" || statusAbility.GetName() == "Leer")
                {
                    Console.WriteLine($"{attacker.GetName()} a affaibli la défense de l'ennemi.");
                    defender.LowerDefense();
                }
                break;
            case 3:
                attacker.UsePotion();
                break;
        }

        Thread.Sleep(2000); // Pause for 2 seconds
    }

}

    static void Main()
    {
        InitializeConsole();

        char[,] carte = InitializeCarte();

        do
        {
            Console.Clear();
            main_menu();

            Console.Write("Choisissez une option (1-4): ");
            char choice = Console.ReadKey().KeyChar;

            ProcessChoice(choice, carte);

        } while (!quit);
    }

    static void InitializeConsole()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.WindowWidth = 20;
            Console.WindowHeight = 20;
        }
    }

    static char[,] InitializeCarte()
    {
        char[,] carte =
        {
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
            {'#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '#', '#', '#', '#', '#', '#', '#', '#', '#', '.', '.', '#', '.', '.', '#', '#', '#'},
            {'#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#', '#', '.', '.', '#', '.', '#'},
            {'#', '.', '.', '#', '.', '#', '#', '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '#', '.', '.', '.', '.', '#', '#', '#', '#', '#', '.', '#', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '#', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '#', '#', '.', '#', '.', '#', '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '.', '#', '.', '.', '#', '.', '.', '.', '.', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '#', '#', '#', '#', '.', '.', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '#', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '#', '#', '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '#'},
            {'#', '.', '#', '#', '#', '.', '#', '.', '.', '#', '.', '.', '.', '#', '#', '#', '#', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '#', '.', '.', '.', '#', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#'},
            {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        return carte;
    }

    static void ProcessChoice(char choice, char[,] carte)
    {
        switch (choice)
        {
            case '1':
                ShowLoadingScreen("Lancement de la partie.", 500);
                ShowLoadingScreen("Lancement de la partie..", 500);
                ShowLoadingScreen("Lancement de la partie...", 500);
                Console.Clear();
                PlayGame(carte);
                break;

            case '2':
                ProcessDifficultyChoice();
                break;

            case '3':
                Console.WriteLine("\nVous avez choisi l'option 3");
                break;

            case '4':
                quit = true;
                Console.WriteLine("\nAu revoir !");
                break;

            default:
                Console.WriteLine("\nChoix invalide. Veuillez choisir une option valide.");
                break;
        }
    }

    static void PlayGame(char[,] carte)
    {
        AfficherCarte(carte);

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            MovePlayer(keyInfo, carte);
            Console.Clear();
            AfficherCarte(carte);

        } while (keyInfo.Key != ConsoleKey.Escape);

        Console.ReadLine();
    }

    static void MovePlayer(ConsoleKeyInfo keyInfo, char[,] carte)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.W:
                MovePlayerIfValid(-1, 0, carte);
                break;
            case ConsoleKey.S:
                MovePlayerIfValid(1, 0, carte);
                break;
            case ConsoleKey.A:
                MovePlayerIfValid(0, -1, carte);
                break;
            case ConsoleKey.D:
                MovePlayerIfValid(0, 1, carte);
                break;
        }
    }

    static void MovePlayerIfValid(int deltaY, int deltaX, char[,] carte)
    {
        int newPosY = posY + deltaY;
        int newPosX = posX + deltaX;

        if (IsValidMove(newPosY, newPosX, carte))
        {
            carte[posY, posX] = '.';
            posY = newPosY;
            posX = newPosX;
        }
    }

    static bool IsValidMove(int y, int x, char[,] carte)
    {
        return y >= 0 && y < carte.GetLength(0) && x >= 0 && x < carte.GetLength(1) && carte[y, x] == '.';
    }

    static void ProcessDifficultyChoice()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════╗");
        Console.WriteLine("║       Difficulte       ║");
        Console.WriteLine("╠════════════════════════╣");
        Console.WriteLine("║ 1.  Facile             ║");
        Console.WriteLine("║ 2.  Moyen              ║");
        Console.WriteLine("║ 3.  Difficile          ║");
        Console.WriteLine("║ 4.  --RETOUR--         ║");
        Console.WriteLine("╚════════════════════════╝");

        Console.Write("\nChoisissez une option (1-4): ");
        char choice_difficulty = Console.ReadKey().KeyChar;

        switch (choice_difficulty)
        {
            case '1':
                ShowLoadingScreen("Difficulte facile selectionnée.", 500);
                ShowLoadingScreen("Difficulte selectionnée..", 500);
                ShowLoadingScreen("Difficulte selectionnée...", 500);
                Console.WriteLine("\nDifficulte actuelle : Facile\n");
                break;
            case '2':
                ShowLoadingScreen("Difficulte moyenne selectionnée.", 500);
                ShowLoadingScreen("Difficulte moyenne selectionnée..", 500);
                ShowLoadingScreen("Difficulte moyenne selectionnée...", 500);
                Console.WriteLine("\nDifficulte actuelle : Moyen\n");
                break;
            case '3':
                ShowLoadingScreen("Difficulte difficile selectionnée.", 500);
                ShowLoadingScreen("Difficulte difficile selectionnée..", 500);
                ShowLoadingScreen("Difficulte difficile selectionnée..", 500);
                Console.WriteLine("\nDifficulte actuelle : Difficile\n");
                break;
            case '4':
                main_menu();
                break;
            default:
                Console.WriteLine("Difficulte actuelle : Aucune");
                break;
        }
    }

    static void AfficherCarte(char[,] carte)
    {
        for (int i = 0; i < carte.GetLength(0); i++)
        {
            for (int j = 0; j < carte.GetLength(1); j++)
            {
                if (i == posY && j == posX)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("P ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(carte[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }

    static void main_menu()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════╗");
        Console.WriteLine("║          Menu          ║");
        Console.WriteLine("╠════════════════════════╣");
        Console.WriteLine("║ 1.  Lancer             ║");
        Console.WriteLine("║ 2.  Difficulte         ║");
        Console.WriteLine("║ 3.  Options            ║");
        Console.WriteLine("║ 4.  Quitter            ║");
        Console.WriteLine("╚════════════════════════╝");
    }

    static void ShowLoadingScreen(string message, int durationMilliseconds)
    {
        Console.Clear();
        Console.WriteLine(message);

        Thread.Sleep(durationMilliseconds);
    }
}
