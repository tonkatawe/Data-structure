

namespace _02._Sort_Words
{
    using System;
    using System.Linq;


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(" ", Console.ReadLine().Split().OrderBy(s => s).ToList()));
        }
    }
}
