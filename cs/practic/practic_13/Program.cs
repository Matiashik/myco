using System;

namespace practic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point3D(3, 2, 5);
            point.Print();
            point.Move('z', 3);
            point.Print();
        }
    }
}
