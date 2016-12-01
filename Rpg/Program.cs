using System;
using Rpg.Classes;

namespace Rpg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            var randomizer = new RandomNumbers(random);
            var a = new Character("Attacker");
            var b = new Character("Defender");

            var battle = new Battle(randomizer, a, b);
            var results = battle.Resolve();
            results.DisplayResults();

            Console.ReadKey();
        }
    }
}

