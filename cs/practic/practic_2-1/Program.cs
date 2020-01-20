using System;

namespace practic_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            uint i = Convert.ToUInt32(Console.ReadLine());
            string s = i < 10 ? ("Да") : ("Нет");
            Console.WriteLine(s);
        }
    }
}
