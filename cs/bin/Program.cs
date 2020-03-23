using System;

namespace bin
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Point
    {
        double x;
        public double X { get { return x; } set { x = value; } }
        double y;
        public double Y { get { return y; } set { y = value; } }
        public Point() { x = 0; y = 0; }
        public Point(double x, double y) { this.x = x; this.y = y; }
        public double DistanceTo(Point p) { return Math.Sqrt(Math.Pow(p.x - this.x, 2) + Math.Pow(p.y - this.y, 2)); }
        public Point Vector(Point p) { return new Point(p.x - x, p.y - y); }
        public void Move(int n, int m)
        {
            switch (n)
            {
                case 1: Y += m; break;
                case 2: Y += Math.Sqrt(Math.Pow(m, 2) / 2); X += Math.Sqrt(Math.Pow(m, 2) / 2); break;
                case 3: X += m; break;
                case 4: X += Math.Sqrt(Math.Pow(m, 2) / 2); Y -= Math.Sqrt(Math.Pow(m, 2) / 2); break;
                case 5: Y -= m; break;
                case 6: Y -= Math.Sqrt(Math.Pow(m, 2) / 2); X -= Math.Sqrt(Math.Pow(m, 2) / 2); break;
                case 7: X -= m; break;
                case 8: X -= Math.Sqrt(Math.Pow(m, 2) / 2); Y += Math.Sqrt(Math.Pow(m, 2) / 2); break;
            }
        }
    }
}