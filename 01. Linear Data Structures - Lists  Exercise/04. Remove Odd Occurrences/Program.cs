using System;
using System.Linq;

namespace _04._Remove_Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                var oddCounter = 0;
                var current = input[i];
                for (int j = 0; j < input.Count; j++)
                {
                    if (current== input[j])
                    {
                        oddCounter++;
                    }
                }

                if (oddCounter % 2 == 1)
                {
                    input.RemoveAll(n => n == current);
                    i--;
                }

            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
