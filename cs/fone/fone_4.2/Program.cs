using System;

namespace fone_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = new MatrixWeather();
            w.Print();
        }
    }
    class MatrixWeather
    {
        int mon;
        public int Month { get { return mon; } }
        static int[] days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int Days { get { return days[mon - 1]; } }
        int day;
        public int Day
        {
            get { return day; }
            set
            {
                try
                {
                    if (value > 0 && value < 8) day = value;
                    else throw new Exception("Invalid value");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.StackTrace);
                }
            }
        }
        public int ZeroDays
        {
            get
            {
                int z = 0;
                int c = 0;
                foreach (int i in temp)
                {
                    z++;
                    if (i == 0) c++;
                    if (z == days[mon - 1]) break;

                }
                return c;
            }
        }
        static int NoData { get { return -1000; } }
        int[,] temp;
        public int[,] Temp { get { return (int[,])temp.Clone(); } }
        public MatrixWeather()
        {
            day = (new Random()).Next(1, 8);
            mon = (new Random()).Next(1, 13);
            int wks = 1;
            int dd = day;
            for (int i = 0; i < days[mon - 1]; i++)
            {
                if (dd == 7 && i != days[mon - 1] - 1) { dd = 1; wks++; }
                else dd++;
            }
            this.temp = new int[wks, 7];
            int d = 0;
            int wk = 0;
            for (int i = 0; i < days[mon - 1]; i++)
            {
                if (d == 7) { wk++; d = 0; }
                temp[wk, d] = (new Random()).Next(-31, 31);
                d++;
            }
        }
        public MatrixWeather(int mon, int day)
        {
            this.day = day;
            this.mon = mon;
            int wks = 1;
            int dd = day;
            for (int i = 0; i < days[mon - 1]; i++)
            {
                if (dd == 7 && i != days[mon - 1] - 1) { dd = 1; wks++; }
                else dd++;
            }
            this.temp = new int[wks, 7];
            int d = 0;
            int wk = 0;
            for (int i = 0; i < days[mon - 1]; i++)
            {
                if (d == 7) { wk++; d = 0; }
                temp[wk, d] = (new Random()).Next(-31, 31);
                d++;
            }
        }
        public void Print()
        {
            System.Console.WriteLine("пн      вт      ср      чт      пт      сб      вс");
            int u = 1;
            for (int i = 1; i < day; i++)
            {
                u++;
                System.Console.Write("        ");
            }
            int z = 0;
            u--;
            for (int wk = 0; ; wk++)
            {
                for (int l = 0; l < 7; l++)
                {
                    int d;
                    try { d = temp[wk, l]; }
                    catch { Console.WriteLine(""); return; }
                    if (d != NoData)
                    {
                        u++; z++;
                        Console.Write($"{z} {d}");
                        for (int j = 0; j < 7 - d.ToString().Length - z.ToString().Length; j++) Console.Write(" ");
                        if (u % 7 == 0) Console.WriteLine("");
                        if (z == days[mon - 1]) { Console.WriteLine(""); return; }
                    }
                }
            }
        }
        public int GetMaxA()
        {
            int MaxA = 0;
            int bef = temp[0, 0];
            int z = 0;
            foreach (int i in temp)
            {
                z++;
                if (i - bef > MaxA) MaxA = i - bef;
                bef = i;
                if (z == days[mon - 1]) { break; }
            }
            return MaxA;
        }
        public int GetMaxA(out int day)
        {
            day = 0;
            int MaxA = 0;
            int bef = temp[0, 0];
            int z = 0;
            foreach (int i in temp)
            {
                z++;
                if (i == NoData) break;
                if (i - bef > MaxA) { MaxA = i - bef; day = z; }
                bef = i;
            }
            return MaxA;
        }
    }
}
