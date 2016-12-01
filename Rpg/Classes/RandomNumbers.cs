using System;
using Rpg.Interfaces;

namespace Rpg.Classes
{
    public class RandomNumbers : IRandom
    {
        private readonly Random _generator;
        public RandomNumbers(Random generator)
        {
            _generator = generator;
        }
        public int GetNextInteger(int min, int max)
        {
            return _generator.Next(min, max);
        }

        public int RollInitiative()
        {
            return _generator.Next(1, 10);
        }

        public int RollAttack()
        {
            return _generator.Next(1, 100);
        }
    }
}