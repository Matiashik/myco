using System;

namespace practic_10
{
    class Program
    {
        static int[] Days = {
            31, 28, 31, 30, 
            31, 30, 31, 31, 
            30, 31, 30, 31
        };
        enum Month
        {
            jan = 1, feb, mar, apr, may, jun,
            jul, aug, sep, oct, nov, dec
        }
        static void Main(string[] args)
        {
            for(Month year = Month.jan; year <= Month.dec; year++) Console.WriteLine("Месяц - {0}, номер - {1}", year, (int)year);
            Console.Write("Введите месяц: "); int M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите день: "); int Date = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько нужно отсчитать: "); int D = Convert.ToInt32(Console.ReadLine());
            Month month = (Month)M;
            int DAYS = Date;
            while(D != 0)
            {
                if(DAYS > Days[(int)month - 1])
                {
                    DAYS = 1;
                    if(month != Month.dec) month++;
                    else month = Month.jan;
                }
                DAYS++;
                D--;
            }
            if(month <= Month.feb) Console.WriteLine("Зима");
            else if(month <= Month.mar) Console.WriteLine("Весна");
            else if(month <= Month.aug) Console.WriteLine("Лето");
            else if(month <= Month.nov) Console.WriteLine("Осень");
            else Console.WriteLine("Зима");
        }
    }
}

