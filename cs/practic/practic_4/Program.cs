using System;
using static System.Math;

namespace practic_4
{
    class Program
    {
        //вариант 7
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(args[0]); //a = 6
            int b = Convert.ToInt32(args[1]); //b = 7
            var OUT = Min(Max((double)a/(double)(a+b), b, Abs(a*a+b)), Min((a+b), (a*b))) + 
                         Min(Max((5*a), (-b), (a+b)), 3) - 
                         Min(a, (7*b));
            Console.WriteLine("{0:F3}", OUT); //OUT = 10
        }
        static double Min(double a, double b)
        {
            if (a < b) return a;
            else return b;
        }
        static double Max(double a, double b, double c)
        {
            double max;
            if (a > b) max = a;
            else max = b;
            if (c > max) max = c;
            return max;
        }
    }
}
