using System;

namespace DiceGame
{
    public class Die
    {
        public int Sides {get;}
        public Die() { this.Sides = 6; }
        public Die(int sides)
        {
            this.Sides = sides;
        }
        public int Roll()
        {
            return new Random().Next(1,Sides+1);
        }
    }
}