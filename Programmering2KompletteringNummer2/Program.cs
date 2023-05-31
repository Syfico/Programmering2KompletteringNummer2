using System;
using System.Collections.Generic;

class Potion
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string potency { get; set; } = string.Empty;
    public int cost { get; set; }
}

class MagicShop
{
    private Dictionary<int, Potion> potions;

    public MagicShop()
    {
        potions = new Dictionary<int, Potion>();
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
            Console.WriteLine($"ID: {potion.id} | Name: {potion.name} | Potency: {potion.potency} | Cost: {potion.cost}");
        }
    }

    public void BuyPotion(int id)
    {
        if (potions.ContainsKey(id))
        {
            Potion potion = potions[id];
            Console.WriteLine($"You bought the potion \"{potion.name}\" for {potion.cost} coins.");
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
            Console.WriteLine($"You sold the potion \"{potion.name}\" for {potion.cost} coins.");
        }
        else
        {
            Console.WriteLine("The potion already exists in the shop.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MagicShop magicShop = new MagicShop();

        Potion potion1 = new Potion { id = 1, name = "Elixir of Power", potency = "III", cost = 50 };
        Potion potion2 = new Potion { id = 2, name = "Potion of Healing", potency = "I", cost = 20 };
        Potion potion3 = new Potion { id = 3, name = "Mana Tonic", potency = "IV", cost = 75 };

        magicShop.AddPotion(potion1);
        magicShop.AddPotion(potion2);
        magicShop.AddPotion(potion3);

        magicShop.ShowAvailablePotions();

        Console.WriteLine();

        magicShop.BuyPotion(2);

        Console.WriteLine();

        magicShop.ShowAvailablePotions();

        Console.WriteLine();

        Potion newPotion = new Potion { id = 4, name = "Invisibility Potion", potency = "II", cost = 40 };
        magicShop.SellPotion(newPotion);

        Console.WriteLine();

        magicShop.ShowAvailablePotions();
    }
}
