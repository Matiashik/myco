using System;

namespace practic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(3, 2, 5);
            Point3D point2 = new Point3D(5, 4, 1);
            (point1 + point2).Print();
        }
    }
    class Point3D
    {
        int x;
        int y;
        int z;
        public Point3D() {x = y = z = 0;}
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Move(char b, int a)
        {
            switch(b) 
            {
                case 'x': x += a; break;
                case 'y': y += a; break;
                case 'z': z += a; break;
                default: System.Console.WriteLine("Error"); break;
            }
        }
        public void Print()
        {
            System.Console.WriteLine($"x: {x}, y: {y}, z: {z}");
        }
        public double RadVec()
        {
            return Math.Sqrt((double)(x*x + y*y + z*z));
        }
        public void Sum(Point3D a)
        {
            this.x += a.x;
            this.y += a.y;
            this.z += a.z;
        }
        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }
    }
}
