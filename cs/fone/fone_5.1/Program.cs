using System;

namespace fone_5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TC();
            var b = new LightA();
            a.Print();
            b.Print();
        }
    }
    class TC
    {
        protected string name;
        protected int rt;
        protected int etb;
        public string Name
        {
            get {return name;}
        }
        public double Length
        {
            get {return etb/rt;}
        }
        public TC()
        {
            name = "a";
            rt = 1;
            etb = 1;
        }
        public TC(string name, int rt, int etb)
        {
            this.name = name;
            this.rt = rt;
            this.etb = etb;
        }
        public double Toplivo(double l)
        {
            return l * rt / 100;
        }
        public void Print()
        {
            System.Console.WriteLine($"Название: {name}, расход топлива: {rt}, емкость бака: {etb}, максимальная длина поездки: {Length}");
        }
    }
    class LightA : TC
    {
        public enum type {sedan, kupe, hachback, universal, kabriolet}
        type tip;
        int kolvo = 1;
        public int Kolvo
        {
            get {return kolvo;}
            set {if(value > 0) kolvo = value;}
        }
        public LightA() : base()
        {
            tip = type.sedan;
            kolvo = 5;
        }
        public LightA(string name, int rt, int etb, type tip, int kolvo) : base(name, rt, etb)
        {
            this.tip = tip;
            if(kolvo > 0) this.kolvo = kolvo;
        }
        new public double Toplivo(double l)
        {
            return base.Toplivo(l) * kolvo;
        }
        public int Percent(int k)
        {
            if(k < kolvo) return k/kolvo*100;
            else return -1;
        }
        new public void Print()
        {
            base.Print();
            System.Console.WriteLine($"Количество человек в машине: {kolvo}, тип кузова: {(new string[]{"sedan", "kupe", "hachback", "universal", "kabriolet"})[(int)tip]}");
        }
    }
    class HeavyA : TC
    {
        double h;
        double m = 0;
        public double M
        {
            get {return m;}
            set {if(value > 0 && value < h) m = value;}
        }
        public double Percent
        {
            get {return m/h * 100;}
        }
        public HeavyA(string name, int rt, int etb, double h, double m) : base(name, rt, etb)
        {
            if(h > 0) this.h = h; else this.h = 1;
            if(m >= 0) M = m; else this.m = 0;
        }
        public HeavyA() : base() {h = 1; m = 0;}
        new public double Toplivo(double l)
        {
            return base.Toplivo(l) * (m+1);
        }
    }
}
