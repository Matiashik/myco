using System;

namespace bin
{
    class Program
    {
        public static void Main(String[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int mx = a;
            for (int i = 0; i < 3 - 1; i++)
            {
                a = int.Parse(Console.ReadLine());
                if (a > mx && a % 5 == 0) mx = a;
            }
            System.Console.WriteLine(mx);
        }
    }
}