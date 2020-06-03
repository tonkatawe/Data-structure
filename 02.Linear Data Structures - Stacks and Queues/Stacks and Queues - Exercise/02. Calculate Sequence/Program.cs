using System;
using System.Collections.Generic;

namespace _02._Calculate_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = new Queue<int>();
            result.Enqueue(n);

            var index = 0;
            var elements = new int[50];
            while (result.Count > 0)
            {
                int element = result.Dequeue();
                elements[index] = element;
                index++;
                if (index == 50)
                {
                    break;
                }
                result.Enqueue(element + 1);
                result.Enqueue(2 * element + 1);
                result.Enqueue(element + 2);

            }
            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
