using System;
using Xunit;
using DiceGame;
using System.Collections.Generic;
using System.Linq;

namespace metatest
{
    public class UnitTest1
    {

        [Theory]
        [InlineData(new int[] { 2, 7, 3, 11, 2, 2 }, 4.50)]
        [InlineData(new int[] { 18, 4, 6, 12, 19 }, 11.80)]
        [InlineData(new int[] { 5 }, 5)]
        [InlineData(new int[] {  }, 0)]
        public void Average(int[] results, Double expected)
        {
            ClGame test = new ClGame("", results.ToList<int>());
            Assert.Equal(expected, test.GetAverage());
        }
        [Theory]
        [InlineData(new int[] { 2, 7, 3, 11, 2, 2 }, 27)]
        [InlineData(new int[] { 18, 4, 6, 12, 19 }, 59)]
        [InlineData(new int[] { 5 }, 5)]
        [InlineData(new int[] {  }, 0)]
        public void Total(int[] results, Double expected)
        {
            ClGame test = new ClGame("", results.ToList<int>());
            Assert.Equal(expected, test.GetTotal());
        }

    }
}
