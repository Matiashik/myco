using System;

namespace practic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(3, 2, 5);
            Point3D point2 = new Point3D(5, 4, 1);
            point1.Print(); point2.Print();
            point1,Sum(point2); point1.Print();
            point2.Sum(3); point2.Print();
            System.Console.WriteLine(RadVec);
            point1.X = 3;
            point1.Print();
            point1.Move('z', 3);
            point1.Print();
        }
    }
    class Point3D
    {
        int x;
        int y;
        int z;
        public double RadVec
        {
            get {return Math.Sqrt((double)(x*x + y*y + z*z));}
        }
        public void Mult
        {
            set
            {
                x *= value;
                y *= value;
                z *= value;
            }
        }
        public int X
        {
            get {return x;}
            set {if(value >= 0) x = value;}
        }
        public int Y
        {
            get {return y;}
            set 
            {
                if(value >= 0 && value <= 100) y = value;
                else y = 100;
            }
        }
        public int Z
        {
            get {return z;}
            set 
            {
                if(value <= x + y) z = value;
                else System.Console.WriteLine("Can't set z");
            }
        }

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
        public void Sum(Point3D a)
        {
            this.x += a.x;
            this.y += a.y;
            this.z += a.z;
        }
        public void Sum(int a)
        {
            x += a;
            y += a;
            z += a;
        }
    }
}
