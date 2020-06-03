using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var queque = new Queue<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                queque.Enqueue(input[i]);
            }
            Console.WriteLine(string.Join(" ", queque));
        }
    }
}
