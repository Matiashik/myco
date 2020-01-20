using System;

namespace fone_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //task 1
            Console.Write("Строка 1: "); string str1 = Console.ReadLine();
            Console.Write("Строка 2: "); string str2 = Console.ReadLine();
            Console.Write("Действие: "); string znak = Console.ReadLine();
            Console.WriteLine("{0} {1} {2} = {3}", str1, znak, str2, Arythm(str1, str2, znak));
            //task 2
            Console.Write("Введите подстроку: "); string str = Console.ReadLine();
            Console.WriteLine("Минимальная длина исходной строки: {0}", Motherstring(str));

        }
        static string Arythm(string str1, string str2, string znak)
        {
            string res = "";
            int n = 0;
            char str1Zn = str1[0];
            if (str1Zn == '-') str1 = str1.Remove(0, 1);
            else str1Zn = '+';
            char str2Zn = str2[0];
            if (str2Zn == '-') str2 = str2.Remove(0, 1);
            else str2Zn = '+';
            if (str1.Length > str2.Length)
            {
                n = str1.Length - 1;
                for (int i = 0; i < str1.Length - str2.Length; i++)
                {
                    str2 = str2.Insert(0, "0");
                }
            }
            else if (str1.Length < str2.Length)
            {
                n = str2.Length - 1;
                for (int i = 0; i < str2.Length - str1.Length; i++)
                {
                    str1 = str1.Insert(0, "0");
                }
            }
            else
            {
                n = str2.Length;
                str1 = str1.Insert(0, "0");
                str2 = str2.Insert(0, "0");
            }
            int a = 0, b = 0, c = 0, razr = 0;
            if ((znak.Equals("+") && str2Zn == str1Zn) || (znak.Equals(str2Zn.ToString()) && str1Zn != '-'))
            {
                for (int i = n; i >= 0; i--)
                {
                    a = str1[i] - 48;
                    b = str2[i] - 48;
                    c = razr;
                    razr = (a + b + c) / 10;
                    res = string.Concat((a + b + c - razr * 10).ToString(), res);
                }
                if (str1Zn == '-') res = string.Concat(str2Zn, res);
            }
            else
            {
                char reszn = '0';
                if (str1.CompareTo(str2) < 0)
                {
                    string temp = str1;
                    str1 = str2;
                    str2 = temp;
                    reszn = '-';
                }
                else if (str1Zn == '-') reszn = str1Zn;
                for (int i = n; i >= 0; i--)
                {
                    a = str1[i] - 48;
                    b = str2[i] - 48;
                    c = razr;
                    razr = 0;
                    if (a < b + c)
                    {
                        a += 10;
                        razr = 1;
                    }
                    res = string.Concat((a - b - c).ToString(), res);
                }
                if (reszn == '-') res = string.Concat(reszn, res);
            }
            while(true)
            {
                if(res[0] == '0' && res.Length != 1) res = res.Remove(0, 1);
                else if(res [0] == '-' && res[1] == '0') res = res.Remove(1, 1);
                else break;
            }
            return res;
        }
        static int Motherstring(string str)
        {
            string res = str;
            string temp = "";
            string sub = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int k = 1; k <= str.Length - i; k++)
                {
                    sub = str.Substring(i, k);
                    for(int j = 0; j < str.Length; j++) temp = string.Concat(temp, sub);
                    if(temp.Contains(str) && sub.Length < res.Length) res = sub;
                    temp = "";
                }
            }
            return res.Length;
        }
    }
}
