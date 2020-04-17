using System;

namespace practic_14
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoPoint a =  new DemoPoint(15, 72);
            a.show();
            DemoLine b = new DemoLine(48, 45, 30000, 327);
            b.show();
        }
    }
    class DemoPoint
    {
        protected int x;
        protected int y;
        public DemoPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public DemoPoint()
        {
            x = 0;
            y = 0;
        }
        public void show()
        {
            System.Console.WriteLine($"x = {x}, y = {y}");
        }
    }
    class DemoLine : DemoPoint
    {
        int x1;
        int y1;
        public DemoLine(int x, int y, int x1, int y1) : base(x, y)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        public DemoLine() : base(0, 0)
        {
            this.x1 = 0;
            this.y1 = 0;
        }
        new public void show()
        {
            base.show();
            System.Console.WriteLine($"x1 = {x1}, yt = {y1}");
        }
    }
}
