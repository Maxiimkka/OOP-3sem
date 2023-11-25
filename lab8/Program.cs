using System;
using System.Linq;

class Game
{
    public event Action<string, int> Attack;
    public event Action<string, int> Heal;

    public void OnAttack(string playerName, int damage)
    {
        Attack?.Invoke(playerName, damage);
    }

    public void OnHeal(string playerName, int healing)
    {
        Heal?.Invoke(playerName, healing);
    }
}

class Player
{
    public string Name { get; }
    public int Health { get; private set; }
    private int initialHealth;

    public Player(string name, int initialHealth)
    {
        Name = name;
        Health = initialHealth;
        this.initialHealth = initialHealth;
    }

    public void SubscribeToEvents(Game game)
    {
        game.Attack += (attacker, damage) =>
        {
            if (attacker != Name)
            {
                Health -= damage;
                Console.WriteLine($"{Name} was attacked by {attacker}. Health: {Health}");
            }
        };

        game.Heal += (healer, healing) =>
        {
            if (healer == Name)
            {
                Health += healing;
                Console.WriteLine($"{Name} was healed. Health: {Health}");
            }
        };
    }

    public void DisplayInitialHealth()
    {
        Console.WriteLine($"{Name}'s initial health: {initialHealth}");
    }
}

class StringProcessing
{
    public static string RemovePunctuation(string input)
    {
        return new string(input.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());
    }

    public static string AddText(string input, string text)
    {
        return input + text;
    }

    public static string ConvertToUppercase(string input)
    {
        return input.ToUpper();
    }

    public static string RemoveExtraSpaces(string input)
    {
        return string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public static string ProcessString(string input, Func<string, string> processFunction)
    {
        return processFunction(input);
    }
}

class Program
{
    static void Main()
    {
        Game game = new Game();

        Player player1 = new Player("Player 1", 100);
        Player player2 = new Player("Player 2", 100);

        player1.SubscribeToEvents(game);
        player2.SubscribeToEvents(game);

        player1.DisplayInitialHealth();
        player2.DisplayInitialHealth();

        game.OnAttack("Player 2", 20);
        game.OnHeal("Player 1", 10);
        game.OnAttack("Player 1", 15);
        game.OnAttack("Player 2", 25);

        Console.WriteLine($"Player 1's final health: {player1.Name} - {player1.Health}");
        Console.WriteLine($"Player 2's final health: {player2.Name} - {player2.Health}");

        string text = "Hello,  World! This is an example text.";

        Action<string, Func<string, string>> processAndPrint = (title, processFunc) =>
        {
            Console.WriteLine($"{title}: {processFunc(text)}");
        };

        processAndPrint("Original Text", s => s);
        processAndPrint("Remove Punctuation", StringProcessing.RemovePunctuation);
        processAndPrint("Add Text", s => StringProcessing.AddText(s, " (Processed)"));
        processAndPrint("Convert to Uppercase", StringProcessing.ConvertToUppercase);
        processAndPrint("Remove Extra Spaces", StringProcessing.RemoveExtraSpaces);
        Console.ReadLine();
    }
}
