using System;

namespace bin
{
    class Program
    {
        static void Main(string[] args)
        {
            tablica();
            Console.WriteLine(numbit());
            dvoich();
        }
        static void tablica()
        {
            byte a = 1;
            byte b = 9;
            Console.WriteLine("a&b {0}", a&b);
            Console.WriteLine("a|b {0}", a|b);
            Console.WriteLine("a^b {0}", a^b);
            Console.WriteLine("~a {0}", ~a);
            Console.WriteLine("~b {0}", ~b);
            Console.WriteLine("a<<1 {0}", a<<1);
            Console.WriteLine("b>>2 {0}", b>>2);
        }
        static int numbit()
        {
            short x = Convert.ToInt16(Console.ReadLine());
            short n = Convert.ToInt16(Console.ReadLine());
            int ret = 0;
            x >>= n - 1;
            if((x|1) == x) ret = 1;
            else ret = 0;
            return ret;
        }
        static void dvoich()
        {
            byte mask = 0b10000000;
            byte c = Convert.ToByte(Console.ReadLine());
            for(int i = 7; i >= 0; i--)
            {
                if((c|mask) == c) Console.Write("1");
                else Console.Write("0");
                mask >>= 1;
            }
        }
    }
}
