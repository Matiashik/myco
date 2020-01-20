using static System.Convert;
using static System.Console;
using static System.Math;
namespace fone_3._2
{
    class Program
    {
        static void Main()
        {
            Write("Длина: ");
            int n = ToInt32(ReadLine());
            int[] arr = Makearr(n);
            Writearr(arr);
            Zamena(arr);
            Write("Введите разность для пар элементов: ");
            int k = ToInt32(ReadLine());
            WriteLine("Таких пар: {0}", Pari(arr, k));
            WriteLine("Итого, нужно удалить минимум {0} элем. массива(см выше)", Pila(arr));
        }

        static int[] Makearr(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Write("Элемент {0}: ", i + 1);
                arr[i] = ToInt32(ReadLine());
            }
            return arr;
        }
        static void Writearr(int[] arr)
        {
            Write("arr = ");
            foreach (int i in arr)
            {
                Write("{0}; ", i);
            }
            WriteLine("");
        }

        static void Zamena(int[] constarray)
        {
            int[] arr = new int[constarray.Length];
            for (int i = 0; i < arr.Length; i++) arr[i] = constarray[i];
            int sum = 0;
            int min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    sum += arr[i];
                    if (arr[i] > arr[min]) min = i;
                }
            }
            if (sum == 0) WriteLine("В массиве нет отрицательных элементов");
            else arr[min] = Abs(sum);
            sum = 1;
            int k = 0;
            min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    k++;
                    sum *= arr[i];
                    if (arr[i] < arr[min]) min = i;
                }
            }
            if (k == 0) WriteLine("В массиве нет положительных элементов");
            else arr[min] = Abs(sum);
            Write("Результат замены: ");
            Writearr(arr);
        }

        static int Pari(int[] arr, int k)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (Abs(arr[i] - arr[i + 1]) == k) sum++;
            }
            return sum;
        }

        static int Pila(int[] arr)
        {
            int res = 0;
            if (arr.Length == 1) return 0;
            if (arr.Length == 2)
            {
                if (arr[0] != arr[1]) return 0;
                WriteLine("Для пилообразности удаляем любой из 2х элементов");
                return 1;
            }
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if ((arr[i] < arr[i + 1] && arr[i] < arr[i - 1]) || (arr[i] > arr[i + 1] && arr[i] > arr[i - 1]))
                {
                    if (i == arr.Length - 2) return 0;
                    continue;
                }
                break;
            }
            Write("Для пилообразности удаляем: ");
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1] && arr[i] > arr[i - 1]) { res++; Write("Элемент №{0} ", i + 1); }
                if (arr[i] > arr[i + 1] && arr[i] < arr[i - 1]) { res++; Write("Элемент №{0} ", i + 1); }
                if (arr[i] == arr[i - 1]) { res++; Write("Элемент №{0} ", i + 1); }
            }
            if(arr[arr.Length - 1] == arr[arr.Length - 2]) {res++; Write("Элемент №{0} ", arr.Length);}
            WriteLine("");
            return res;
        }
    }
}