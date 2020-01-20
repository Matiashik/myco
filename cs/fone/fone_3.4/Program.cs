using System;

namespace bin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество строк: "); int N = Convert.ToInt32(Console.ReadLine());
            int[][] mas = InputArray(N);
            OutputArray(mas);
            Console.Write("Положительных чисел в строчках: ");
            foreach(int i in Pol(mas, N))
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("В строке с индексом {0}", Max(mas, N));
        }
        static int[][] InputArray(int N)
        {
            int[][] mas = new int[N][];
            for(int i = 0; i < N; i++)
            {
                Console.Write("Длина строки: "); int a = Convert.ToInt32(Console.ReadLine());
                mas[i] = new int[a];
                for(int j = 0; j < a;j++)
                {
                    Console.Write("Введите элемент: "); mas[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return mas;
        }
        static void OutputArray(int[][]mas)
        {
            foreach(int[] i in mas)
            {
                foreach(int j in i) Console.Write("{0} ", j);
                Console.Write("* ");
            }
            Console.WriteLine("");
        }
        static int[] Pol(int[][] mas, int N)
        { 
            int[] res = new int[N];
            for(int i = 0; i < N; i++)
            {
                int k = 0;
                foreach(int j in mas[i]) if(j > 0) k++;
                res[i] = k;
            }
            return res;
        }
        static int Max(int[][] mas, int N)
        {
            int Max = int.MaxValue;
            int res = 0;
            for(int i = 0; i < N; i++)
            {
                int max = int.MinValue;
                foreach(int j in mas[i]) if(j > max) max = j;
                if(max < Max) {res = i; Max = max;}
            }
            return res;
        }
    }
}
