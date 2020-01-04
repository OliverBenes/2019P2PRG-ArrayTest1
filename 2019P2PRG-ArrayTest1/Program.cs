using System;

namespace ArrayTest1
{
    class Program
    {
        static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            Array a = new Array();
            a.Insert(500, 5);
            a.Insert(5000, 15);
            a.Add(100);
            for (int i = 0; i < 10; i++)
            {
                a.Add(rnd.Next(1, 100));
            }
            a.Insert(1000, 10);

            int j = 0;
            foreach (var number in a)
            {
                Console.WriteLine($"[{j++,-2}] – {number,4}");
            }
        }
    }
}
