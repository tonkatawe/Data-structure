using System;
using System.Linq;

namespace _01._Sum_And_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var sum = input.Sum();
            var avarage = input.Average();
            Console.WriteLine($"Sum={sum}; Average={avarage:f2}");
        }
    }
}
