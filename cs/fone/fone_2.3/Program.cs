using System;

namespace fone_2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input n: "); int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input m: "); int m = Convert.ToInt32(Console.ReadLine());
            if(n > m)
            {
                obmen(ref n, ref m);
            }
            if(search(ref n, ref m)) Console.WriteLine("Существуют ли числа-близнецы на диапазоне от n до m? - Да\nНовое значение n = {1}\nНвое значение m = {2}", 0, n, m);
            else Console.WriteLine("Существуют ли числа-близнецы на диапазоне от n до m? - Нет\nНовое значение n = {1}\nНвое значение m = {2}", 0, n, m);
        }
        static void obmen(ref int n, ref int m)
        {
            n = n + m;
            m = n - m;
            n = n - m;
        }
        static bool search(ref int n, ref int m)
        {
            int a = n;
            int z = 0;
            for(int i = n; i <= m; i++)
            {
                z = 0;
                for(int j = 1; j <= i; j++)
                {
                    if(i%j == 0) z++;
                }
                if(z == 2)
                {
                    if(i - a == 2){ n = a; m = i; return true;}
                    a = i;
                }
            }
            return false;
        }
    }
}
