using System;

namespace practic_3_1
{
    class Program
    {
        public static void Main(String[] args)
        {
            A();
            Console.WriteLine("");
            B();
        }
        static void A()
        {
            Console.Write("");
            for(int i = 1; i < 10; i++)
            {
                for(int k = 1; k < 10; k++)
                {
                    if(i*k < 10) Console.Write(k*i + "  ");
                    else Console.Write(k*i + " ");
                }
                Console.WriteLine("");
            }
        }

        static void B()
        {
            for (int a = 1; a < 11; a++)
            {
                for (int b = 2; b < 6; b++)
                {
                    if (a*b < 10)
                    {
                        Console.Write("{0} *  {1} =  {2}  ", b, a, a * b);
                    }
                    else if(a == 10)
                    {
                        Console.Write("{0} * {1} = {2}  ", b, a, a * b);
                    }
                    else
                    {
                        Console.Write("{0} *  {1} = {2}  ", b, a, a * b);
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            for (int a = 1; a < 11; a++)
            {
                for (int b = 6; b < 10; b++)
                {
                    if (a * b < 10)
                    {
                        Console.Write("{0} *  {1} =  {2}  ", b, a, a * b);
                    }
                    else if (a == 10)
                    {
                        Console.Write("{0} * {1} = {2}  ", b, a, a * b);
                    }
                    else
                    {
                        Console.Write("{0} *  {1} = {2}  ", b, a, a * b);
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
