using System;
using static System.Math;
//    1
//0        2
//    3
namespace fone_5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PACMAN";

            FPrint(Field);

            while (true)
            {
                pac.Move();
                if (pac.X == gh1.X && pac.Y == gh1.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == gh2.X && pac.Y == gh2.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == sgh.X && pac.Y == sgh.Y) { System.Console.WriteLine("Game Over"); break; }
                if (Field[pac.Y, pac.X] == 2) Field[pac.Y, pac.X] = 0;
                if (Field[pac.Y, pac.X] == 3) { Field[pac.Y, pac.X] = 0; pac.v = 2; }
                bool t = true;
                foreach (var i in Field) { if (i == 2) { t = false; break; } }
                if (t) { System.Console.WriteLine("You win!"); break; }
                gh1.Move();
                if (pac.X == gh1.X && pac.Y == gh1.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == gh2.X && pac.Y == gh2.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == sgh.X && pac.Y == sgh.Y) { System.Console.WriteLine("Game Over"); break; }
                gh2.Move();
                if (pac.X == gh1.X && pac.Y == gh1.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == gh2.X && pac.Y == gh2.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == sgh.X && pac.Y == sgh.Y) { System.Console.WriteLine("Game Over"); break; }
                sgh.Move(pac);
                if (pac.X == gh1.X && pac.Y == gh1.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == gh2.X && pac.Y == gh2.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == sgh.X && pac.Y == sgh.Y) { System.Console.WriteLine("Game Over"); break; }
                FPrint(Field);
            }
            FPrint(Field);
        }
        public static int[,] Field =
        {
            {2,2,2,1,2,2,2,2,2,2,2,2,2,2,2},
            {2,2,2,1,2,2,2,2,2,2,2,2,2,2,2},
            {2,2,2,1,2,2,2,2,2,2,2,2,2,2,2},
            {1,1,1,1,2,2,2,1,1,1,1,2,1,2,2},
            {2,2,2,2,2,2,2,2,2,2,2,2,1,2,2},
            {2,2,2,2,1,1,1,1,1,1,1,1,1,2,2},
            {2,2,2,2,2,2,1,2,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,2,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,1,1,1,2,2,2,2,2},
            {2,2,2,2,2,2,1,2,2,1,1,1,1,1,2},
            {2,2,2,1,2,2,1,2,2,1,2,2,2,2,2},
            {2,2,2,1,2,2,2,2,2,2,2,2,2,2,2},
            {1,2,2,1,1,1,1,1,1,1,1,2,2,2,2},
            {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
            {1,1,1,1,2,1,1,1,2,2,1,1,1,2,1}
        };
        public static Pacman pac = new Pacman(7, 7, 0);
        public static Ghost gh1 = new Ghost(5, 3, 2);
        public static Ghost gh2 = new Ghost(4, 7, 2);
        public static SGhost sgh = new SGhost(4, 3, 0);
        public static void FPrint(int[,] a)
        {
            Console.Clear();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (j == pac.X && pac.Y == i) pac.Draw();
                    else if (j == gh1.X && gh1.Y == i) gh1.Draw();
                    else if (j == gh2.X && gh2.Y == i) gh1.Draw();
                    else if (j == sgh.X && sgh.Y == i) sgh.Draw();
                    else
                    {
                        Console.ForegroundColor = a[i, j] == 1 ? ConsoleColor.White : (a[i, j] == 2 ? ConsoleColor.DarkMagenta : ConsoleColor.Black);
                        System.Console.Write(a[i, j]);
                        Console.ResetColor();
                    }
                }
                System.Console.WriteLine();
            }
        }
    }
    class Creature
    {
        protected Random rand = new Random();
        public int X { get; set; } = 0;
        public int N { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int v { get; set; } = 1;
        public Creature() { }
        public Creature(int x, int y, int n)
        {
            this.X = x;
            this.Y = y;
            this.N = n;
        }
        public virtual void Draw() { }
        public virtual void Move() { }
    }
    class Pacman : Creature
    {
        public Pacman() : base() { }
        public Pacman(int x, int y, int n) : base(x, y, n) { }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write("P");
            Console.ResetColor();
        }
        public override void Move()
        {
            var a = Console.ReadKey();
            switch (a.KeyChar.ToString().ToLower())
            {
                case "w":
                    if (Y > 0) { if (Program.Field[Y - v, X] != 1) Y -= v; return; }
                    else if (Program.Field[14, X] != 1) { Y = 14; return; }
                    break;
                case "s":
                    if (Y < 14) { if (Program.Field[Y + v, X] != v) Y += v; return; }
                    else if (Program.Field[0, X] != 1) { Y = 0; return; }
                    break;
                case "a":
                    if (X > 0) { if (Program.Field[Y, X - v] != v) X -= v; return; }
                    else if (Program.Field[Y, 14] != 1) { X = 14; return; }
                    break;
                case "d":
                    if (X < 14) { if (Program.Field[Y, X + v] != v) X += v; return; }
                    else if (Program.Field[Y, 0] != 1) { X = 0; return; }
                    break;
                default: break;
            }
        }
    }
    class Ghost : Creature
    {
        public Ghost() : base() { }
        public Ghost(int x, int y, int n) : base(x, y, n) { }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("G");
            Console.ResetColor();
        }
        public override void Move()
        {
            while (true)
            {
                var a = N == 1 ? 'w' : (N == 0 ? 'a' : (N == 3 ? 'd' : 's'));
                switch (a.ToString().ToLower())
                {
                    case "w":
                        if (Y > 0) { if (Program.Field[Y - v, X] != 1) { Y -= v; return; } }
                        else if (Program.Field[14, X] != 1) { Y = 14; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                    case "s":
                        if (Y < 14) { if (Program.Field[Y + v, X] != v) { Y += v; return; } }
                        else if (Program.Field[0, X] != 1) { Y = 0; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                    case "a":
                        if (X > 0) { if (Program.Field[Y, X - v] != v) { X -= v; return; } }
                        else if (Program.Field[Y, 14] != 1) { X = 14; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                    case "d":
                        if (X < 14) { if (Program.Field[Y, X + v] != v) { X += v; return; } }
                        else if (Program.Field[Y, 0] != 1) { X = 0; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                }
            }
        }
    }
    class SGhost : Creature
    {
        public SGhost() : base() { }
        public SGhost(int x, int y, int n) : base(x, y, n) { }
        private double Length(int x, int y, Pacman pac)
        {
            return Sqrt(Pow(x - pac.X, 2) + Pow(y - pac.Y, 2));
        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("S");
            Console.ResetColor();
        }
        public void Move(Pacman pac)
        {
            var a = N == 1 ? 'w' : (N == 0 ? 'a' : (N == 3 ? 'd' : 's'));
            if (X == pac.X)
            {
                if (pac.Y < Y) a = 'w';
                if (pac.Y > Y) a = 's';
            }
            if (Y == pac.Y)
            {
                if (pac.X < X) a = 'a';
                if (pac.X > X) a = 'd';
            }
            while (true)
            {
                switch (a.ToString().ToLower())
                {
                    case "w":
                        if (Y > 0) { if (Program.Field[Y - v, X] != 1) { Y -= v; return; } }
                        else if (Program.Field[14, X] != 1) { Y = 14; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                    case "s":
                        if (Y < 14) { if (Program.Field[Y + v, X] != v) { Y += v; return; } }
                        else if (Program.Field[0, X] != 1) { Y = 0; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                    case "a":
                        if (X > 0) { if (Program.Field[Y, X - v] != v) { X -= v; return; } }
                        else if (Program.Field[Y, 14] != 1) { X = 14; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                    case "d":
                        if (X < 14) { if (Program.Field[Y, X + v] != v) { X += v; return; } }
                        else if (Program.Field[Y, 0] != 1) { X = 0; return; }
                        N = N < 4 ? (N + rand.Next()) % 4 : 0;
                        break;
                }
                a = N == 1 ? 'w' : (N == 0 ? 'a' : (N == 3 ? 'd' : 's'));
            }
        }
    }
}
