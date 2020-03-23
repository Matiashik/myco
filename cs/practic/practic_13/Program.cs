using System;

namespace practic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D point1 = Point3D.New(2, 3, 4);
            Point3D point2 = Point3D.New(4, 5, 6);
            System.Console.WriteLine("Точка 1");
            point1.Print();
            System.Console.WriteLine("Точка 2");
            point2.Print();
            System.Console.WriteLine("Радуис-вектор 1 точки");
            System.Console.WriteLine(point1.RadVec);
            System.Console.WriteLine("Домножим координаты точки 2 на 6");
            point2.Mult = 6; point2.Print();
            System.Console.WriteLine("Сдвинем точку 1 на 3 по Ox");
            point1.X += 3; point1.Print();
            System.Console.WriteLine("И на -1 по всем осям");
            point1--; point1.Print();
            System.Console.WriteLine("Точку 2 также на -1 по всем осям");
            point2--; point2.Print();
            System.Console.WriteLine("Точка 1 больше или равна точке 2? " + (point1 >= point2));
            if(point1) System.Console.WriteLine("Трехмерная точка 1 лежит в четвертой четверти плоскости xy и имеет координату z, меньшую нуля");
            if(point2) System.Console.WriteLine("Трехмерная точка 2 лежит в четвертой четверти плоскости xy и имеет координату z, меньшую нуля");
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
        public void Print()
        {
            System.Console.WriteLine($"x: {x}, y: {y}, z: {z}");
        }
        public static Point3D operator +(Point3D a, Point3D b)
        {
            return new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Point3D operator -(Point3D a, Point3D b)
        {
            return new Point3D(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Point3D operator ++(Point3D a)
        {
            return new Point3D(a.x + 1, a.y + 1, a.z + 1);
        }
        public static Point3D operator --(Point3D a)
        {
            return new Point3D(a.x - 1, a.y - 1, a.z - 1);
        }
        public static bool operator >=(Point3D a, Point3D b)
        {
            if(a.x + a.y + a.z >= b.x + b.y + b.z) return true;
            else return false;
        }
        public static bool operator <=(Point3D a, Point3D b)
        {
            if(a.x + a.y + a.z <= b.x + b.y + b.z) return true;
            else return false;
        }
        public static Point3D operator &(Point3D a, Point3D b)
        {
            return new Point3D(a.x & b.x, a.y & b.y, a.z & b.z);
        }
        public static Point3D operator |(Point3D a, Point3D b)
        {
            return new Point3D(a.x | b.x, a.y | b.y, a.z | b.z);
        }
        public static bool operator true(Point3D a)
        {
            return (a.x > 0 && a.y < 0 && a.z < 0);
        }
        public static bool operator false(Point3D a)
        {
            return !(a.x > 0 && a.y < 0 && a.z < 0);
        }
    }
}