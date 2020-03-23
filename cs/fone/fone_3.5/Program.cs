using System;
using System.IO;

namespace fone_3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            //читаем файл и крестимся чтоб это работало
            FileStream file = File.OpenRead("RaspI.txt");
            byte[] arr = new byte[file.Length];
            file.Read(arr, 0, arr.Length);
            string FT = System.Text.Encoding.Default.GetString(arr);
            file.Close();
            //end

            //разбиваем по урокам
            string[] FTARR = FT.Split("\n===\n");
            Lesson[] DAY = new Lesson[FTARR.Length];
            //end

            //перекидываем из эррея стрингов в эррей структук
            for (int i = 0; i < DAY.Length; i++)
            {
                string[] a = FTARR[i].Split("\n");
                DAY[i].classroom = Convert.ToInt32(a[0]);
                DAY[i].teacher = a[1];
                DAY[i].group = Convert.ToInt32(a[2]);
                DAY[i].subject = a[3];
                DAY[i].number = (Number)(Convert.ToInt32(a[4]));
                Console.WriteLine($"#{i+1} принят");
            }
            //end

            //проверка на ошибки в расписании
            if (Lesson.TestForErrors(DAY)) return;
            //end

            //выборка
            Lesson.InfoList(DAY, Lesson.groups, 51);
            //end

            //все ли рабы при деле?
            Lesson.Window(DAY, 51);
            //end

            //расписание
            Lesson.Timetable(DAY);
            //end
        }
    }
    struct Lesson
    {
        public int classroom; //0
        public string teacher; //1
        public int group; //2
        public string subject; //3
        public Number number; //4
        public void Print()
        {
            Console.WriteLine("=====");
            Console.Write(this.classroom + "; ");
            Console.Write(this.teacher + "; ");
            Console.Write(this.group + "; ");
            Console.Write(this.subject + "; ");
            Console.WriteLine(this.number);
            Console.WriteLine("=====");
        }
        public static bool TestForErrors(Lesson[] DAY)
        {
            for (int i = 0; i < DAY.Length - 1; i++)
            {
                for (int j = i + 1; j < DAY.Length; j++)
                {
                    if (DAY[i].number == DAY[j].number)
                    {
                        if (DAY[i].classroom == DAY[j].classroom)
                        {
                            Console.WriteLine($"Classrooms error! Lesson Info {i + 1} == Lesson Info {j + 1}");
                            return true;
                        }
                        if (DAY[i].teacher == DAY[j].teacher)
                        {
                            Console.WriteLine($"Teachers error! Lesson Info {i + 1} == Lesson Info {j + 1}");
                            return true;
                        }
                        if (DAY[i].group == DAY[j].group)
                        {
                            Console.WriteLine($"Groups error! Lesson Info {i + 1} == Lesson Info {j + 1}");
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public const bool groups = true;
        public const bool numbers = false;
        public static void InfoList(Lesson[] DAY, bool a, int need)
        {
            if(a) foreach (var i in DAY) if (i.group == need) i.Print();
            if(!a) foreach (var i in DAY) if ((int)i.number == need) i.Print();
        }
        public static void Window(Lesson[] DAY, int GROUP)
        {
            int[] less = { 0, 0, 0, 0, 0, 0, 0 };
            int a = 0;
            foreach (var i in DAY) if (i.group == GROUP) { less[a] = (int)i.number; a++; }
            while (true)
            {
                bool b = true;
                for (int i = 0; i < less.Length - 1; i++)
                {
                    if (less[i] > less[i + 1])
                    {
                        b = false;
                        a = less[i];
                        less[i] = less[i + 1];
                        less[i + 1] = a;
                    }
                }
                if (b) break;
            }
            int window = 0;
            for (int i = 0; i < less.Length - 1; i++)
            {
                if ((less[i] != less[i + 1] + 1) && (less[i] != less[i + 1]))
                {
                    window = less[i] + 1;
                }
            }
            if (window == 0) return;
            string[] teachers = new string[DAY.Length];
            a = 0;
            foreach (var i in DAY)
            {
                if ((int)i.number == window)
                {
                    bool b = false;
                    foreach (var j in teachers) if (j == i.teacher) b = true;
                    if (!b) { teachers[a] = i.teacher; a++; }
                }
            }
            string TEACHER = "";
            foreach (var i in DAY)
            {
                int b = 0;
                int c = 0;
                foreach (var j in teachers)
                {
                    if (j != i.teacher) b++;
                    c++;
                }
                if (b == c)
                {
                    TEACHER = i.teacher;
                }
            }
            int[] classrooms = new int[DAY.Length];
            a = 0;
            foreach (var i in DAY)
            {
                if ((int)i.number == window)
                {
                    bool b = false;
                    foreach (var j in classrooms) if (j == i.classroom) b = true;
                    if (!b) { classrooms[a] = i.classroom; a++; }
                }
            }
            int CLASSROOM = 0;
            foreach (var i in DAY)
            {
                int b = 0;
                int c = 0;
                foreach (var j in classrooms)
                {
                    if (j != i.classroom) b++;
                    c++;
                }
                if (b == c)
                {
                    CLASSROOM = i.classroom;
                }
            }
            Console.WriteLine($"У группы имеется свободный урок №{window}");
            if (TEACHER == "") Console.WriteLine("Нет свободных учителей");
            if (CLASSROOM == 0) Console.WriteLine("Нет свободных классов");
            if (TEACHER == "" || CLASSROOM == 0) return;
            Console.WriteLine($"У группы имеется свободный урок №{window}. Можно провести с учителем {TEACHER} в {CLASSROOM}");
        }
        public static void Timetable(Lesson[] DAY)
        {
            const int LN = 17;
            int[] GROUP = new int[DAY.Length];
            int a = 0;
            foreach(var i in DAY)
            {
                int b = 0;
                int c = 0;
                foreach(var j in GROUP)
                {
                    if(j != i.group) b++;
                    c++;
                }
                if(c == b){ GROUP[a] = i.group; a++;}
            }
            string txt = "";
            txt += "Урок  ";
            foreach(var i in GROUP)
            {
                if(i != 0)
                {
                    string b = (i/10) + "." + (i - i/10*10);
                    string c = (i/10) + "." + (i - i/10*10);
                    if(i < 100)
                    {
                        int l = b.Length; 
                        txt += b;
                        for(int j = 0; j < LN - l; j++) txt += " ";
                    }
                    if(i > 100)
                    {
                        int l = c.Length; 
                        txt += c;
                        for(int j = 0; j < LN - l; j++) txt += " ";
                    }
                }
            }
            txt += "\n";
            for(int i = 1; i <= 7; i++)
            {
                txt += $"|||{i}";
                for(int b = 1; b < LN - 11; b++) txt += " ";
                foreach(var k in GROUP)
                {
                    bool P = true;
                    foreach(var item in DAY)
                    {
                        if(item.group == k && (int)item.number == i)
                        {
                            P = false;
                            string str = item.classroom + ", " + item.subject;
                            txt += str;
                            for(int j = 0; j < LN - str.Length; j++) txt += " ";
                        }
                    }
                    if(P) for(int j = 0; j < LN; j++) txt += " ";
                }
                txt += "\n";
            }
            txt += "\n";
            Console.Write(txt);
            FileStream file = new FileStream("RaspO.txt", FileMode.OpenOrCreate);
            byte[] arr = System.Text.Encoding.Default.GetBytes(txt);
            file.Write(arr, 0, arr.Length);
            file.Close();
        }
    }
    enum Number
    {
        первый = 1, второй, третий, четвертый, пятый, шестой, седьмой
    }
}