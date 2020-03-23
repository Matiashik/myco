using System;

namespace practic_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = 64.1;
            double pl = 7.8932597F;
            double pr = 100000000000f;
            double fl = 3.2;
            decimal dec = 18500.5m;
            byte sl = 4;
            byte p = 16;
            string s = "AMD";
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите дробное число: ");
            double f = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Привет, " + name);
            Console.WriteLine("*********************************");
            Console.WriteLine("*       Я твой компьютер!       *");
            Console.WriteLine("*********************************");
            Console.WriteLine("У меня следующие характеристики:\n");
            Console.WriteLine("Процессор               " + s + " с разрядностью " + fl + "GHz" );
            Console.WriteLine("Моя память              {1:D0}Gb (доступно {0:p0})", pl/10, p);
            Console.WriteLine("Жетский диск            " + sl + "Tb");
            Console.WriteLine("Тип системы             " + Math.Round(r) + "-разрядная OC");
            Console.WriteLine("\n");
            Console.WriteLine("Моя производительность  {0:E0} оп/сек", pr);
            Console.WriteLine("Индекс произв -ти       " + Math.Round(f));
            Console.WriteLine("Моя стоимость           {0:C2}", dec);
        }
    }
}
