using System;

namespace fone_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вариант 8
            //Я ведь правильно понял что 0 выколот?
            Console.Write("Введите x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            double U;

            if (x < -2) U = Math.Abs(x * x - y * y * y);
            else if (x > 1) U = Math.Abs(x * x - y * y * y);
            else if (x == 0) U = Math.Abs(x * x - y * y * y);
            else if (y >= (x - 1) / 3) {
                if (x < 0)
                {
                    if (x >= -1)
                    {
                        if (y <= -x) U = 5;
                        else U = Math.Abs(x * x - y * y * y);
                    }
                    else if (y <= 2 * x + 3) U = 5;
                    else U = Math.Abs(x * x - y * y * y);
                }
                else if (y <= 0) U = 5;
                else U = Math.Abs(x * x - y * y * y);
            }
            else U = Math.Abs(x * x - y * y * y);

            Console.WriteLine(U);
        }
    }
}
   
