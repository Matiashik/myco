using System;

namespace practic_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int a = 1; a < 8; a++)
            {
                for(int b = a + 1; b < 9; b++)
                {
                    for(int c = b + 1; c < 10; c++)
                    {
                        Console.Write(a);
                        Console.Write(b);
                        Console.Write(c + "; ");
                    }
                }
            }
        }
    }
}
