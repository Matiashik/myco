using System;

namespace practic_10
{
    class Program
    {
        enum Days
        {
            jan = 31, feb = 28, mar = 31, apr = 30, 
            may = 31,jun = 30, jul = 31, aug = 31, 
            sep = 30, oct = 31, nov = 30, dec = 31
        }
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
            Days days;
            for(days = Days.jan; days <= Days.dec; days++) if(days.ToString() == month.ToString()) break;
            int DAYS = Date;
            while(D != 0)
            {
                if(DAYS > (int)days)
                {
                    DAYS = 1;
                    if(days != Days.dec) days++;
                    else days = Days.jan;
                    if(month != Month.dec) days++;
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

