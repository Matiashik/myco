using System;
using static System.Console;
using static System.Convert;
using static System.Math;

namespace practic_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Intput a1: "); int a1 = ToInt32(ReadLine());
            Write("Input b1: "); int b1 = ToInt32(ReadLine());
            task1(ref a1, b1); WriteLine(a1);
            bool yep = true;
            int a, b, c;
            while (yep)
            {
                Write("Intput a: "); a = ToInt32(ReadLine());
                Write("Intput b: "); b = ToInt32(ReadLine());
                Write("Intput c: "); c = ToInt32(ReadLine());
                task2(ref a, ref b, ref c);
                WriteLine("{0} >= {1} >= {2}", a, b, c);
                Write("Желаете повторить [y/n]: ");
                if (ReadLine() == "y") yep = true;
                else yep = false;
            }
            Write("Intput N: "); int n = ToInt32(ReadLine());
            Write("Intput k: "); int k = ToInt32(ReadLine());
            n = task3(n, k);
            Console.WriteLine(n);
        }
        static void task1(ref int a, int b)
        {
            int k = 0;
            do { k++; b /= 10; } while (b != 0);
            a *= (int)Math.Pow(10, k);
        }
        static void obmen(ref int a, ref int b)
        {
            int c = b;
            b = a;
            a = c;
        }
        static void task2(ref int a, ref int b, ref int c)
        {
            while (a < b || b < c || a < c)
            {
                if (a < b) obmen(ref a, ref b);
                if (b < c) obmen(ref b, ref c);
            }
        }
        static int task3(int n, int k)
        {
            int l = 0;
            int RES = 0;
            int temp = n;
            do { l++; temp /= 10; } while (temp != 0);
            for (int y = 0; y < l; y++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if ((n / (int)Pow(10, y) - (n / (int)Pow(10, y + 1)) * 10) + i < 10) temp = n + i * (int)Math.Pow(10, y);
                    if (temp % k == 0 && temp != n && temp > RES) RES = temp;
                    if ((n / (int)Pow(10, y) - (n / (int)Pow(10, y + 1)) * 10) - i >= 0) temp = n - i * (int)Math.Pow(10, y);
                    if (temp % k == 0 && temp != n && temp > RES) RES = temp;
                }
            }
            return RES;
        }
    }
}
