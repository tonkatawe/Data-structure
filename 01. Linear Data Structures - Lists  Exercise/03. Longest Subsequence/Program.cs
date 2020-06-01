using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        var longestSequenceCount = 1;
        var longestSequenceStartIndex = 0;
        var currentSequenceCount = 1;
        var currentSequenceStartIndex = 0;

        for (var i = 1; i < list.Count; i++)
        {
            if (list[i] == list[i - 1])
            {
                currentSequenceCount++;

                if (currentSequenceCount > longestSequenceCount)
                {
                    longestSequenceCount = currentSequenceCount;
                    longestSequenceStartIndex = currentSequenceStartIndex;
                }
            }
            else
            {
                currentSequenceCount = 1;
                currentSequenceStartIndex = i;
            }
        }

        Console.WriteLine(String.Join(" ", list.Skip(longestSequenceStartIndex).Take(longestSequenceCount)));
    }
}