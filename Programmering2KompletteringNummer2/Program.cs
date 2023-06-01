using System;
using System.Collections.Generic;

interface IGame
{
    void Start();
    void Play();
    void End();
}

class Potion
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string power { get; set; } = string.Empty;
    public int cost { get; set; }
}

class MagicShop : IGame
{
    private Dictionary<int, Potion> potions;
    private int souls;

    public MagicShop(int startingSouls)
    {
        potions = new Dictionary<int, Potion>();
        souls = startingSouls;
    }

    public void AddPotion(Potion potion)
    {
        potions.Add(potion.id, potion);
    }

    public void ShowAvailablePotions()
    {
        Console.WriteLine("Available potions in the magic shop:");
        foreach (var potion in potions.Values)
        {
            Console.WriteLine($"ID: {potion.id} | Name: {potion.name} | Power: {potion.power} | Cost: {potion.cost}");
        }
    }

    public void BuyPotion(int id)
    {
        if (potions.ContainsKey(id))
        {
            Potion potion = potions[id];
            Console.WriteLine($"You bought the potion \"{potion.name}\" for {potion.cost} souls of the damned.");
            potions.Remove(id);
        }
        else
        {
            Console.WriteLine("The potion does not exist in the shop.");
        }
    }

    public void SellPotion(Potion potion)
    {
        if (!potions.ContainsKey(potion.id))
        {
            potions.Add(potion.id, potion);
            Console.WriteLine($"You sold the potion \"{potion.name}\" for {potion.cost} souls of the damned.");
        }
        else
        {
            Console.WriteLine("The potion already exists in the shop.");
        }
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Magic Shop!");
        Play();
    }

    public void Play()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear(); // Rensa konsolfönstret

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Show available potions");
            Console.WriteLine("2. Buy a potion");
            Console.WriteLine("3. Sell a potion");
            Console.WriteLine("4. Exit");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    Console.Clear(); // Rensa konsolfönstret
                    ShowAvailablePotions();
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear(); // Rensa konsolfönstret
                    int buyId = GetUserInputAsInt("Enter the ID of the potion you want to buy: ");
                    BuyPotion(buyId);
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear(); // Rensa konsolfönstret
                    Console.WriteLine("Enter the details of the potion you want to sell:");
                    int sellId = GetUserInputAsInt("ID: ");
                    string sellName = GetUserInput("Name: ");
                    string sellPower = GetUserInput("Power: ");
                    int sellCost = GetUserInputAsInt("Cost: ");
                    Potion newPotion = new Potion { id = sellId, name = sellName, power = sellPower, cost = sellCost };
                    SellPotion(newPotion);
                    Console.WriteLine("Press any key to go back to the main menu.");
                    Console.ReadKey();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.Clear(); // Rensa konsolfönstret
        End();
    }

    public void End()
    {
        Console.WriteLine("Thank you for visiting the Magic Shop. Goodbye!");
    }

    private int GetUserChoice()
    {
        int choice = 0;
        bool validChoice = false;

        while (!validChoice)
        {
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
            }
            else
            {
                validChoice = true;
            }
        }

        return choice;
    }

    private string GetUserInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine()!;
    }

    private int GetUserInputAsInt(string message)
    {
        int input = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.Write(message);

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            else
            {
                validInput = true;
            }
        }

        return input;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MagicShop magicShop = new MagicShop(100);

        magicShop.AddPotion(new Potion { id = 1, name = "Elixir of Power", power = "III", cost = 50 });
        magicShop.AddPotion(new Potion { id = 2, name = "Potion of Healing", power = "I", cost = 20 });
        magicShop.AddPotion(new Potion { id = 3, name = "Mana Tonic", power = "IV", cost = 75 });

        magicShop.Start();
    }
}
