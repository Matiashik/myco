using System;
/*Амплитуда
    Неверно высчитывался день, с точностью данных все было ок
    Добавил условие для инкремента счетчика Z (198&212)
*/

/*Краш
    У меня все работает, понятия не имею что не так. Убрал StackTrace
*/
namespace fone_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Введите день недели и месяц через пробел: ");
            string str = Console.ReadLine();
            int d = Convert.ToInt32(str.Split(" ")[0]);
            str = str.Split(" ")[1];
            MatrixWeather w = new MatrixWeather(Convert.ToInt32(str), d);
            Console.WriteLine($"Текущий месяц: {w.Month}");
            Console.WriteLine($"Первый день идет под {w.Day}м номером дня недели, всего в месяце {w.Days} день/дней");
            Console.WriteLine($"В месяце {w.ZeroDays} дней с нулевой температурой");
            int x;
            Console.WriteLine($"Максимальная амплитуда {w.GetMaxA(out x)} в ночь на {x} число");
            System.Console.WriteLine("Текущий месяц: ");
            w.Print();
            System.Console.Write("Какой день теперь первый? ");
            w.Day = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Текущий месяц: ");
            w.Print();
            System.Console.WriteLine("Создадим еще 1 месяц");
            MatrixWeather w2 = new MatrixWeather();
            w.Print();
            System.Console.Write("Этот месяц " + (w > w2 ? "меньше" : "больше") + " существующего");
            MatrixWeather w3 = (MatrixWeather)w2.Clone();
            if (w3.Day != 7) w3++; else w3--;
            if (w2 & w3)
            {
                System.Console.WriteLine("Существует 3 месяц, равный второму");
                w3.Print();
            }
        }
    }
    class MatrixWeather : ICloneable //не бейте ради всего святого
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
                    if (value > 0 && value < 8)
                    {
                        if (value > day)
                        {
                            int dif = value - day;
                            for (int c = 0; c < dif; c++)
                            {
                                for (int w = 4; w >= 0; w--)
                                {
                                    for (int d = 6; d >= 0; d--)
                                    {
                                        if (d == 0)
                                        {
                                            if (w == 0) temp[w, d] = NoData;
                                            else temp[w, d] = temp[w - 1, 6];
                                        }
                                        else
                                        {
                                            temp[w, d] = temp[w, d - 1];
                                        }
                                    }
                                }
                            }
                        }
                        if (value < day)
                        {
                            int dif = value - day;
                            for (int c = 0; c < dif; c++)
                            {
                                for (int w = 0; w <= 4; w++)
                                {
                                    for (int d = 0; d <= 6; d++)
                                    {
                                        if (d == 6)
                                        {
                                            if (w == 5) temp[w, d] = NoData;
                                            else temp[w, d] = temp[w + 1, 0];
                                        }
                                        else
                                        {
                                            temp[w, d] = temp[w, d + 1];
                                        }
                                    }
                                }
                            }
                        }
                        day = value;
                    }
                    else throw new Exception("Invalid value");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
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
        public int[,] Temp
        {
            get { return (int[,])temp.Clone(); }
            private set { temp = (int[,])value.Clone(); }
        }


        public static bool operator >(MatrixWeather a, MatrixWeather b)
        {
            return a.Month > b.Month;
        }
        public static bool operator <(MatrixWeather a, MatrixWeather b)
        {
            return a.Month < b.Month;
        }
        public static MatrixWeather operator ++(MatrixWeather a)
        {
            a.Day += 1;
            return a;
        }
        public static MatrixWeather operator --(MatrixWeather a)
        {
            a.Day -= 1;
            return a;
        }
        public static bool operator true(MatrixWeather a)
        {
            foreach (int i in a.temp) if (i < 0 && i != NoData) return false;
            return true;
        }
        public static bool operator false(MatrixWeather a)
        {
            foreach (int i in a.temp) if (i < 0 && i != NoData) return false;
            return true;
        }
        public static bool operator &(MatrixWeather a, MatrixWeather b)
        {
            int[] arr = new int[a.Days];
            int[] brr = new int[b.Days];
            int ind = 0;
            foreach (int i in a.temp)
            {
                if (i != NoData)
                {
                    arr[ind] = i;
                    ind++;
                }
            }
            ind = 0;
            foreach (int i in b.temp)
            {
                if (i != NoData)
                {
                    brr[ind] = i;
                    ind++;
                }
            }
            for (int i = 0; i < (arr.Length < brr.Length ? arr.Length : brr.Length); i++) //надеюсь теперь моя работа не бездушна?
            {
                if (arr[i] != brr[i]) return false;
            }
            return true;
        }


        public int this[int w, int d]
        {
            get
            {
                try
                {
                    return temp[w, d];
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                return NoData;
            }
            set
            {
                try
                {
                    temp[w, d] = value;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }


        public MatrixWeather()
        {
            Random rand = new Random();
            day = rand.Next(1, 8);
            mon = rand.Next(1, 13);
            temp = new int[5, 7];
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 7; k++)
                {
                    temp[i, k] = NoData;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                int k = 0;
                if (i == 0) k = day - 1;
                for (; k < 7; k++)
                {
                    temp[i, k] = rand.Next(-31, 31);
                    if (i * 7 + k + 1 == days[mon - 1]) return;
                }
            }
        }
        public MatrixWeather(int mon, int day)
        {
            Random rand = new Random();
            this.day = day;
            this.mon = mon;
            temp = new int[5, 7];
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 7; k++)
                {
                    temp[i, k] = NoData;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                int k = 0;
                if (i == 0) k = day - 1;
                for (; k < 7; k++)
                {
                    temp[i, k] = rand.Next(-31, 31);
                    if (i * 7 + k + 2 - day == days[mon - 1]) return;
                }
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public void Print()
        {
            System.Console.WriteLine("пн      вт      ср      чт      пт      сб      вс");
            for (int i = 0; i < day - 1; i++) { System.Console.Write("        "); }
            int u = day;
            foreach (var i in temp)
            {
                if (i == NoData) continue;
                System.Console.Write($"{u - day + 1} {i}");
                for (int j = 0; j < 7 - i.ToString().Length - (u - day + 1).ToString().Length; j++) System.Console.Write(" ");
                if (u % 7 == 0) System.Console.WriteLine("");
                u++;
            }
            Console.WriteLine("");
        }
        public int GetMaxA()
        {
            int MaxA = 0;
            int bef = temp[0, 0];
            int z = 0;
            foreach (int i in temp)
            {
                if (i != NoData) z++;
                if (i - bef > MaxA && bef != NoData && i != NoData) MaxA = i - bef;
                bef = i;
            }
            return MaxA;
        }
        public int GetMaxA(out int day)
        {
            day = NoData;
            int MaxA = 0;
            int bef = temp[0, 0];
            int z = 0;
            foreach (int i in temp)
            {
                if (i != NoData) z++;
                if (i - bef > MaxA && bef != NoData && i != NoData) { MaxA = i - bef; day = z; }
                bef = i;
            }
            return MaxA;
        }
    }
}
