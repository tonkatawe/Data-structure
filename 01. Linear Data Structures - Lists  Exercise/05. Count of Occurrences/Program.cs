using System;
using System.Linq;

namespace _05._Count_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                var current = input[i];
                var count = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    if (input[j] == current)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"{current} -> {count} times");
                input.RemoveAll(n => n == current);
                i--;
            }
        }
    }
}
