using System;

namespace practic_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Последовательность:");
            int a = Convert.ToInt32(Console.ReadLine());
            int OUT = 0;
            int min = a;
            int max = a;
            for(int i = 1; i < N; i++)
            {
                a = Convert.ToInt32(Console.ReadLine());
                if (a > max) { OUT = i; max = a; }
                else if (a < min) { OUT = i; min = a; }
                else continue;
            }
            Console.WriteLine("Элемент: {0} (по человечески {1})", OUT, OUT + 1);
        }
    }
}
