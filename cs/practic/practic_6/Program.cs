using System;

namespace practic_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int res1 = one(N);
            int res2 = two(N);
            int res3 = three(N);
            five(N);
        }
        static int one(int n)
        {
            int k = 0, a = 0;
            while(n > 0)
            {
                a = n % 10;
                if(a < 8 && a%4 != 0 && a%3 != 0) k++;
                n = n / 10;
            }
            if(k != 0) Console.WriteLine(k);
            else Console.WriteLine("NO");
            return k;
        }
        static int two(int n)
        {
            int a = 0, b = 0, sum = 0;
            while(n/10 > 0)
            {
                a = n % 10;
                n /= 10;
                b = n % 10;
                if((a+b)%2 == 0) sum += a+b;
            }
            Console.WriteLine(sum);
            return sum;
        }
        static int three(int n)
        {
            int n1 = n;
            int k = 0;
            int sum1 = 0, sum2 = 0;
            while(n > 0)
            {
                k++;
                n /= 10;
            }
            n = n1;
            if(k%2 != 0) 
            {
                k /= 2;
                while(n > 0)
                {
                    if(k > 0) {k--; sum1 += n % 10;}
                    else if(k == 0) {k--; sum1 += n % 10; sum2 += n % 10;}
                    else sum2 += n % 10;
                    n /= 10;
                }
            }
            else
            {
                k /= 2;
                while(n > 0)
                {
                    if(k > 0) {k--; sum1 += n % 10;}
                    else sum2 += n % 10;
                    n /= 10;
                }
            }
            if(sum2 == sum1) {Console.WriteLine("Счастливое"); return 1;}
            else {Console.WriteLine("No"); return 0;}
        }
        static void five(int n)
        {
            int sum = 0;
            if(n > 1 && n >= 109)
            {
                for(int a = 6; a < n; a++)
                {
                    for(int i = 1; i < a; i++)
                    {
                        if(a % i == 0) sum += i;
                    }
                    if(sum == a) Console.WriteLine(a);
                    sum = 0;
                }
            }
        }
    }
}
