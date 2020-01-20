using System;
using static System.Console;
using static System.Convert;

namespace practic_9
{
    class Program
    {

        static void Main(string[] args)
        {
            Write("Введите количество колец: "); int n = ToInt32(ReadLine());
            move(n, 'A', 'C', 'B');
        }
        static void move(int n, char withk, char needto, char buff)
        {
            if (n != 0)
            {
                move(n-1, withk, buff, needto);
                WriteLine("Переносим с {0} на {1}", withk, needto);
                move(n-1, buff, needto, withk);
            }
        }
    }
}
