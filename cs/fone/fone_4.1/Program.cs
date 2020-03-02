using System;

namespace fone_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pp = new PP();
            var pp1 = new PP(0, 2, 2, 6, 1);
            System.Console.WriteLine(pp.Peres(pp1));
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
            get { return h; }
            set
            {
                try
                {
                    if (value > 0) h = value;
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
            get { return h; }
            set
            {
                try
                {
                    if (value > 0) h = value;
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