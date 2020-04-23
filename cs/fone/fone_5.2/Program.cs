using System;
using static System.Math;
//    v
//0        2
//    3
namespace fone_5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PACMAN";

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Field[i, j] = 0;
                }
            }
            FPrint(Field);

            while (true)
            {
                pac.Move();
                if (pac.X == gh.X && pac.Y == gh.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == sgh.X && pac.Y == sgh.Y) { System.Console.WriteLine("Game Over"); break; }
                if (Field[pac.X, pac.Y] == 2) Field[pac.X, pac.Y] = 0;
                if (Field[pac.X, pac.Y] == 3) { Field[pac.X, pac.Y] = 0; pac.v = 2; }
                gh.Move();
                if (pac.X == gh.X && pac.Y == gh.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == sgh.X && pac.Y == sgh.Y) { System.Console.WriteLine("Game Over"); break; }
                sgh.Move(pac);
                if (pac.X == gh.X && pac.Y == gh.Y) { System.Console.WriteLine("Game Over"); break; }
                if (pac.X == sgh.X && pac.Y == sgh.Y) { System.Console.WriteLine("Game Over"); break; }
                FPrint(Field);
            }
        }
        public static int[,] Field = new int[15, 15];
        public static Pacman pac = new Pacman(7, 7, 0);
        public static Ghost gh = new Ghost(5, 3, 2);
        public static SGhost sgh = new SGhost(6, 7, 0);
        public static void FPrint(int[,] a)
        {
            Console.Clear();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (j == pac.X && pac.Y == i) pac.Draw();
                    else if (j == gh.X && gh.Y == i) gh.Draw();
                    else if (j == sgh.X && sgh.Y == i) sgh.Draw();
                    else System.Console.Write(a[i, j]);
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
                    if (Y > 0) { if (Program.Field[X, Y - v] != 1) Y -= v; return; }
                    else if (Program.Field[X, 14] != 1) { Y = 14; return; }
                    break;
                case "s":
                    if (Y < 14) { if (Program.Field[X, Y + v] != v) Y += v; return; }
                    else if (Program.Field[X, 0] != 1) { Y = 0; return; }
                    break;
                case "a":
                    if (X > 0) { if (Program.Field[X - v, Y] != v) X -= v; return; }
                    else if (Program.Field[14, Y] != 1) { X = 14; return; }
                    break;
                case "d":
                    if (X < 14) { if (Program.Field[X + v, Y] != v) X += v; return; }
                    else if (Program.Field[0, Y] != 1) { X = 0; return; }
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
            var a = N == 1 ? 'w' : (N == 0 ? 'a' : (N == 3 ? 'd' : 's'));
            while (true)
            {
                switch (a.ToString().ToLower())
                {
                    case "w":
                        if (Y > 0) { if (Program.Field[X, Y - v] != 1) Y -= v; return;}
                        else if (Program.Field[X, 14] != 1) {Y = 14; return;}
                        break;
                    case "s":
                        if (Y < 14) { if (Program.Field[X, Y + v] != v) Y += v; return;}
                        else if (Program.Field[X, 0] != 1) {Y = 0; return;}
                        break;
                    case "a":
                        if (X > 0) { if (Program.Field[X - v, Y] != v) X -= v; return;}
                        else if (Program.Field[14, Y] != 1) {X = 14; return;}
                        break;
                    case "d":
                        if (X < 14) { if (Program.Field[X + v, Y] != v) X += v; return;}
                        else if (Program.Field[0, Y] != 1) {X = 0; return;}
                        break;
                    default:
                        N = N < 4 ? N + 1 : 0;
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
            while (true)
            {
                
            }
        }
    }
}