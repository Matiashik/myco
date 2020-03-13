using System;

namespace fone_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = new MatrixWeather();
            w.Print();
        }
    }
    class MatrixWeather
    {
        int mon;
        public int Month
        {
            get { return mon; }
        }
        static int[] days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int day;
        public int Day
        {
            get { return day; }
        }
        int[,] temp;
        public int[,] Temp
        {
            get { return (int[,])temp.Clone(); }
        }
        public MatrixWeather()
        {
            this.day = (new Random()).Next(1, 8);
            this.mon = (new Random()).Next(1, 13);
            int wks = 1;
            int dd = day;
            for (int i = 0; i < days[mon - 1]; i++)
            {
                 if (dd == 7 && i != days[mon - 1] - 1) { dd = 1; wks++; }
		 else  dd++;
            }
            this.temp = new int[wks,7];
	    
	    int d = 0;
            int wk = 0;
	    Random rand = new Random();
            for (int i = 0; i < days[mon - 1]; i++)
            {
                if(d == 7) {wk++; d = 0;}
                temp[wk,d] = rand.Next(-51, 51);
		foreach(var j in temp) Console.Write(j);
            }
	    foreach(var i in temp) Console.Write(i);
        }
        public MatrixWeather(int day, int mon)
        {
            this.day = day;
            this.mon = mon;
            {
                int wks = 1;
                int dd = day;
                for (int i = 0; i < days[mon - 1]; i++)
                {
                    if (dd == 7 && i != days[mon - 1] - 1) { dd = 1; wks++; }
                    dd++;
                }
                this.temp = new int[wks, 7];
            }
            int d = this.day - 1;
            int wk = 0;
            for (int i = 0; i < days[mon - 1]; i++)
            {
                if(d == 6) {wk++; d = 0;}
                temp[wk,d] = (new Random()).Next(-51, 51);
                d++;
            }
        }
       public void Print()
        {
            System.Console.WriteLine("пн    вт    ср    чт    пт    сб    вс");
	    int u = 1;
            for (int i = 1; i < day; i++)
	    {
		    u++;
		    System.Console.Write("      ");
	    }
	    int z = 0;
	    u--;
	    for(int wk = 0;; wk++)
	    {
		for(int l = 0; l < 7; l++)
		{
			int d;
			try {d = temp[wk, l];}
			catch {return;}
			u++;
			z++;
			Console.Write($"{z} {d}");
			for (int j = 0; j < 5 - d.ToString().Length - z.ToString().Length; j++) Console.Write(" ");
			if(u%7 == 0) Console.WriteLine("");
			if(z == days[mon - 1]) break;
		}
	    } 
        }
    }
}
