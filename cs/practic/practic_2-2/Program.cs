using System;

namespace practic_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = Convert.ToInt32(Console.ReadLine());
            if(i >= 30) {
                Console.WriteLine("Перелет");
            } else if (i <= 0) {
                    Console.WriteLine("Не бей по своим");
            } else if (i <= 28) {
                Console.WriteLine("Попал");
            }
        }
    }
}
