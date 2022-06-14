using System;
using System.IO;
using System.Collections.Generic;
using DiceGame;

namespace challenge2
{
    class meta
    {
        public static ClGame game = new ClGame("Caves & Lizards", new List<int>()); 
        static void Main(string[] args)
        {
            // Hey there old data!
            if (File.Exists($@"{Environment.CurrentDirectory}\Rolls.csv"))
            {
                using StreamReader file = new StreamReader($@"{Environment.CurrentDirectory}\Rolls.csv");
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    string[] parts = ln.Split(',');
                    game.Results.Add(int.Parse(parts[0]));
                }
                file.Close();
            }
            // I have all the infinity loops...
            while (true)
            {
                Console.Clear();
                // Keyread!?! Nobody else seems to know how to use that!!
                Console.WriteLine("1. Roll\n2. Stats\n3. List rolls\n4. Save rolls\n5. Exit");
                switch (Console.ReadKey().Key.ToString())
                {
                    // Mapping keys to functions the lazy and inefficient way
                    case "D1":
                        Add();
                        continue;
                    case "D2":
                        Console.Clear();
                        Console.WriteLine($"Total: {game.GetTotal()}");
                        Console.WriteLine($"Average: {game.GetAverage()}");
                        Console.ReadKey();
                        continue;
                    case "D3":
                        Console.Clear();
                        List();
                        Console.ReadKey();
                        continue;
                    case "D4":
                        Console.Clear();
                        Save();
                        Console.ReadKey();
                        continue;
                    case "D5":
                        Console.Clear();
                        Console.WriteLine("Thanks for using the dice rolling app");
                        Console.ReadKey();
                        break;
                    default:
                        continue;
                }
                break;
            }
        }
        public static void Add()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You've selected to roll the dice");
                Random gen = new Random();
                int x = 0;
                // making sure input is an int
                while (true)
                {
                    Console.WriteLine("Please enter the amount of rolls you would like to make: ");
                    bool success = int.TryParse(Console.ReadLine().ToString(), out x);
                    Console.Clear();
                    if (success || x > 0)
                    {
                        break;
                    }
                }
                // Rollin', rollin', rollin' on the river
                for (int i = 0; i < x; i++)
                {
                    game.AddDie();
                }
                game.RollAllDice();
                Console.WriteLine($"You have successfully added {x} item{(x == 1 ? "" : "s")}");
                Console.WriteLine("Would you like to roll more? (Y/N)");
                if (Console.ReadKey().KeyChar != 'y')
                {
                    break;
                }
            }
        }
        public static void List()
        {
            // That's a lot of words. Too bad I'm not readin' 'em.
            foreach(int roll in game.Results)
            {
                Console.WriteLine(roll);
            }
        }

        public static void Save()
        {
            // Saving...
            StreamWriter writer = new StreamWriter($@"{Environment.CurrentDirectory}\Rolls.csv");
            foreach (int roll in game.Results)
            {
                writer.WriteLine(roll);
            }
            writer.Close();
            Console.WriteLine("Saved");
        }
    }
}