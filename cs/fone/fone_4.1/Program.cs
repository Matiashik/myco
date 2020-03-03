using System;

namespace fone_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Do you want to input?[y/n] ");
            PP pp = new PP();
            if(Console.ReadLine() == "y") pp = new PP(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
            pp.Print();
            System.Console.WriteLine("H="+pp.H);
            System.Console.WriteLine("Sh="+pp.Sh);
            System.Console.WriteLine("G="+pp.G);
            System.Console.WriteLine("S osnivania="+pp.OsnS);
            System.Console.WriteLine("S bokovoi storoni="+pp.RLSideS);
            System.Console.WriteLine("S pered storoni="+pp.FBSideS);
            System.Console.WriteLine("V="+pp.V);
            System.Console.WriteLine("Diagonal="+pp.Diag);
            System.Console.WriteLine("Perimetr="+pp.P);
            System.Console.WriteLine("Radius="+pp.Rad);
            System.Console.WriteLine("Is it cube?"+pp.IsCube);
            pp.H = 3;
            pp.Print();
            pp.H = 0;
        }
    }
    class PP
    {
        private double h;
        public double H
        {
            get { return h; }
            set
            {
                try
                {
                    if (value > 0) h = value;
                    else throw new Exception("Incorrect h");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
        private double sh;
        public double Sh
        {
            get { return sh; }
            set
            {
                try
                {
                    if (value > 0) sh = value;
                    else throw new Exception("Incorrect sh");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
        private double g;
        public double G
        {
            get { return g; }
            set
            {
                try
                {
                    if (value > 0) g = value;
                    else throw new Exception("Incorrect g");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }
        private double x;
        private double y;
        public bool IsCube
        {
            get
            {
                if (h == sh && h == g) return true;
                else return false;
            }
        }
        public double RLSideS
        {
            get { return h * sh; }
        }
        public double FBSideS
        {
            get { return h * g; }
        }
        public double OsnS
        {
            get { return g * sh; }
        }
        public double V
        {
            get { return g * h * sh; }
        }
        public double Diag
        {
            get { return Math.Sqrt(g * g + h * h + sh * sh); }
        }
        public double P
        {
            get{return h*4 + g*4 + sh*4;}
        }
        public double RLSideP
        {
            get { return 2 * (h + sh); }
        }
        public double FBSideP
        {
            get { return 2 * (h + g); }
        }
        public double OsnP
        {
            get { return 2 * (g + sh); }
        }
        public double Rad
        {
            get { return Diag / 2; }
        }
        public PP(double h, double sh, double g, double x, double y)
        {
            this.h = h;
            this.sh = sh;
            this.g = g;
            this.x = x;
            this.y = y;
        }
        public PP()
        {
            h = 5;
            sh = 6;
            g = 7;
            x = 0;
            y = 0;
        }
        public void Print()
        {
            System.Console.WriteLine($"x, y: {x}, {y};\nh, sh, g: {h}, {sh}, {g};");
        }
        public void PrintS(string chr)
        {
            switch (chr)
            {
                case "h":
                    System.Console.Write(h);
                    break;
                case "sh":
                    System.Console.WriteLine(sh);
                    break;
                case "g":
                    System.Console.WriteLine(g);
                    break;
                default:
                    System.Console.WriteLine("h, sh or g");
                    break;
            }
        }
        public void Move(double x, double y)
        {
            this.x += x;
            this.y += y;
        }
        public (double, double) Peres(PP pp)
        {
            double l = this.x > pp.x ? this.x : pp.x;
            double v = this.y + this.sh < pp.y + pp.sh ? this.y + this.sh : pp.y + pp.sh;
            double r = this.x + this.g < pp.x + pp.g ? this.x + this.g : pp.x + pp.g;
            double n = this.y > pp.y ? this.y : pp.y;
            double g = r - l;
            double sh = v - n;
            if (g > 0 && sh > 0) return (g, sh);
            else return (0, 0);
        }
    }
}