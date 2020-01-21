using System;

namespace practic_10
{
    class Program
    {
        enum Month 
        {
            jan = 31,
            feb = 28,
            mar = 31,
            apr = 30,
            may = 31,
            jun = 30,
            jul = 31,
            aug = 31,
            sep = 30,
            oct = 31,
            nov = 30,
            dec = 31
        }
        enum Year
        {
            jan = 1,
            feb,
            mar,
            apr,
            may,
            jun,
            jul,
            aug,
            sep,
            oct,
            nov,
            dec
        }
        static void Main(string[] args)
        {
            for(Year year = Year.jan; year <= Year.dec; year++)
            {
                Console.WriteLine("Месяц - {0}, номер - {1}", year, (int)year);
            }
            Console.Write("Введите месяц: "); int M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите день: "); int D = Convert.ToInt32(Console.ReadLine());
            Year month = (Year)1;
        }
    }
}
