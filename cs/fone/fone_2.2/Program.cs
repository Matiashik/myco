using System;
using static System.Math;

namespace fone_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Гномы";
            Console.WriteLine("Введите количество гномов [16 или 32]:");
            byte gnoms = 0;
            byte schet = 0;
            while (true)
            {
                gnoms = Convert.ToByte(Console.ReadLine());
                if (gnoms == 16 || gnoms == 32) break;
                else Console.WriteLine("Введено неправильное значение. Повторите ввод:");
            }
            Console.WriteLine("Введите число, двоичный код которого представляет гномов:");
            int shapki = Convert.ToInt32(Console.ReadLine());
            int mask = 1;
            Console.WriteLine("Гномы:");
            while (mask != 1 << gnoms)
            {
                if ((shapki | mask) == shapki) { Console.ForegroundColor = ConsoleColor.White; Console.Write(1); }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.Write(0); }
                mask <<= 1;
            }
            Console.WriteLine(); Console.ResetColor();
            bool color; //red - false - 0, white - true - 1
            for (int i = 1; i <= gnoms; i++)
            {
                if (nextsumchet(i, gnoms, shapki) == nextsumchet(i - 1, gnoms, shapki)) color = false;
                else color = true;
                schet += say(i, gnoms, shapki, color);
                Console.WriteLine("Счет - {0}", schet);
            }
            if (schet == gnoms || schet == gnoms - 1) Console.WriteLine("Гномы победили!");
            else Console.WriteLine("Не ставьте 2, я все исправлю");
        }
        static bool nextsumchet(int pornum, int gnoms, int shapki)
        {
            int k = 0;
            int mask = 1 << gnoms - 1;
            while (pornum != gnoms)
            {
                if ((shapki | mask) == shapki) k++;
                mask >>= 1;
                pornum++;
            }
            if (k % 2 == 0) return true;
            else return false;
        }
        static byte say(int pornum, int gnoms, int shapki, bool color)
        {
            var k = false;
            int mask = 1 << gnoms - 1;
            mask >>= (gnoms - pornum);
            if ((shapki | mask) == shapki) k = true;
            if (color == false) Console.Write("Гном №{0} утверждает, что красный. ", pornum);
            else Console.Write("Гном №{0} утверждает, что белый. ", pornum);
            if (k == color) { Console.Write("Гном оказался прав! "); return 1; }
            else { Console.Write("Гном оказался неправ! "); return 0; }
        }
    }
}
