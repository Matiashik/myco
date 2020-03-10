﻿using System;

namespace practic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D point1 = Point3D.New(2, 3, 4);
            Point3D point2 = Point3D.New(4, 5, 6);
            point1.Print();
            point2.Print();
            point1.Sum(point2);
            point1.Print();
            point2.Sum(3);
            point2.Print();
            System.Console.WriteLine(point1.RadVec);
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
            get { return Math.Sqrt((double)(x * x + y * y + z * z)); }
        }
        public int Mult
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
            get { return x; }
            set
            {
                try
                {
                    if (value >= 0) x = value;
                    else throw new Exception("Incorrect x");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                try
                {
                    if (value >= 0 && value <= 100) y = value;
                    else { y = 100; throw new Exception("Incorrect y"); }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
        public int Z
        {
            get { return z; }
            set
            {
                try
                {
                    if (value <= x + y) z = value;
                    else throw new Exception("incorrect z");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        public Point3D() { x = y = z = 0; }
        private Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Point3D New(int x, int y, int z)
        {
            try
            {
                if (x % 5 == 0 || y % 5 == 0 || z % 5 == 0) return new Point3D(x, y, z);
                else throw new Exception("Can't create point because ни одна из координат не кратна 5");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return new Point3D(5, 5, 5);
            }
        }
        public void Move(char b, int a)
        {
            switch (b)
            {
                case 'x':
                    x += a;
                    break;
                case 'y':
                    y += a;
                    break;
                case 'z':
                    z += a;
                    break;
                default:
                    System.Console.WriteLine("Error");
                    break;
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