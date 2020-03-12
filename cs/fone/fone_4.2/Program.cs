using System;

namespace fone_4._2 {
    class Program {
        static void Main (string[] args) {
            var w = new MatrixWeather();
            w.Print();
        }
    }
    class MatrixWeather {
        int mon;
        public int Month {
            get { return mon; }
        }
        static int[] days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        int day;
        public int Day {
            get { return day; }
        }
        int[, ] temp;
        public int[, ] Temp {
            get { return (int[, ]) temp.Clone (); }
        }
        public MatrixWeather () {
            this.day = (new Random()).Next(0, 8);
            this.mon = (new Random()).Next(0, 13);
            int wk = 1;
            for (int i = 1; i <= days[i - 1]; i++) {
                temp[wk, day] = (new Random ()).Next (-51, 51);
                if (day == 7) { day = 1; wk++; }
            }
        }
        public MatrixWeather (int day, int mon) {
            this.day = day;
            this.mon = mon;
            int wk = 1;
            for (int i = 1; i <= days[i - 1]; i++) {
                this.temp[wk, day] = (new Random ()).Next (-51, 51);
                if (day == 7) { day = 1; wk++; }
            }
        }
        public void Print() {
            int day = this.day;
            System.Console.WriteLine("пн  вт  ср  чт  пт  сб  вс");
            for(int i = 0; i < day; i++) System.Console.Write("  ");
            int wk = 1;
            for (int i = 1; i <= days[i - 1]; i++) {
                Console.Write($"{i} {temp[wk, day]}  ");
                if (day == 7) { day = 1; wk++; System.Console.WriteLine("");}
            }
        }
    }
}