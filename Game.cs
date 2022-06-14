using System;
using System.Collections.Generic;

namespace DiceGame
{
    public abstract class Game
    {
        public List<Die> Dice {get;} = new List<Die>();
        public Game(){}
        public Game(List<Die> dice)
        {
            this.Dice = dice;
        }
        abstract public int RollAllDice();
        public void AddDie()
        {
            Dice.Add(new Die());
        }
        public void AddDie(int sides)
        {
            Dice.Add(new Die(sides));
        }
    }
}