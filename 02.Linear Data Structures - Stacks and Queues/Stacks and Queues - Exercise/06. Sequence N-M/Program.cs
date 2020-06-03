using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Sequence_N_M
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var n = input[0];
            var m = input[1];

            var elements = new List<int>();

            var queue = new Queue<int>();
            queue.Enqueue(n);
            while (n < m)
            {
                var element = queue.Dequeue();
                elements.Add(element);
                queue.Enqueue(element+1);
                if (n+element ==m)
                {
                    break;
                }
                queue.Enqueue(element+2);
                if (n + element == m)
                {
                    break;
                }
                queue.Enqueue(element*2);
                if (n + element == m)
                {
                    break;
                }
                n = element;
            }

            Console.WriteLine(string.Join(" -> ", elements));
        }
    }
}
