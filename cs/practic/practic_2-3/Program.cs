using System;

namespace practic_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = Convert.ToChar(Console.Read());
            switch (a)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'y':
                    Console.WriteLine("Гласная");
                    break;
                default:
                    Console.WriteLine("Согласная");
                    break;
            }
        }
    }
}
