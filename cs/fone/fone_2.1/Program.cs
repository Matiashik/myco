using System;

namespace fone_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort x1 = Convert.ToUInt16(Console.ReadLine());
            ushort n = Convert.ToUInt16(Console.ReadLine());
            short x2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(nulbit(x1));
            beznulbit(x2);
            sdvig(x1, n);
        }
        static ushort nulbit(ushort n)
        {
            ushort mask = 0b1000000000000000, k = 0;;
            while(mask != 0)
            {
                if((n|mask) != n) k++;
                mask >>= 1;
            }
            return k;
        }
        static void beznulbit(short n)
        {
            ushort mask = 0b1000000000000000;
            while((n|mask) != n) mask >>= 1;
            while(mask != 0)
            {
                if((n|mask) == n) Console.Write(1);
                else Console.Write(0);
                mask >>= 1;
            }
            Console.WriteLine("");
        }
        static void sdvig(ushort a, ushort b)
        {
            int k = 0;
            ushort mask = 0b1000000000000000;
            for(; b != 0; b--)
            {
                k = 0;
                if((a|1) == a) k = 1;
                a >>= 1;
                if(k == 1) a |= mask;
            }
            while(mask != 0)
            {
                if((a|mask) == a) Console.Write(1);
                else Console.Write(0);
                mask >>= 1;
            }
            Console.WriteLine("");
        }
    }
}
