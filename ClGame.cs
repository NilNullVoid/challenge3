using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame
{
    public class ClGame : Game
    {
        public string Name {get;}
        public List<int> Results {get;} = new List<int>();
        public ClGame(){}
        public ClGame(string name, List<int> results)
        {
            this.Name = name;
            Results = results;
        }
        public double GetAverage()
        {
            // Algebraic!
            if(Results.Count == 0)
            return 0;
            return ((double)GetTotal())/Results.Count;
        }
        public int GetTotal()
        {
            // Mathematical!
            if(Results.Count == 0)
            return 0;
            return Results.Sum();
        }
        override public int RollAllDice()
        {
            foreach(Die die in Dice)
            {
                Results.Add(die.Roll());
            }
            return 1;
        }
    }
}