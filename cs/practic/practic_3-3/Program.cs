using System;

namespace practic_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int a = 1; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    Console.Write("{0}{0}{1}; ", a, b);
                    Console.Write("{0}{1}{1}; ", a, b);
                    Console.Write("{0}{1}{0}; ", a, b);
                }
            }
        }
    }
}
