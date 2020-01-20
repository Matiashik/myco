using System;
using static  System.Math;

namespace fone_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine()); //8
            int b = Convert.ToInt32(Console.ReadLine()); //2
            int c = Convert.ToInt32(Console.ReadLine()); //2
            var res = Sin(Convert.ToDouble(b + c) / a) + Sqrt(c * c + b * b + a) + 0.4;
            Console.WriteLine(res);
        }
    }
}