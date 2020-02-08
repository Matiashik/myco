namespace practic_13
{
    class Point3D
    {
        int x;
        int y;
        int z;
        public Point3D() => x = y = z = 0;
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
                case 'x': this.x += a; break;
                case 'y': this.y += a; break;
                case 'z': this.z += a; break;
                default: System.Console.WriteLine("Error"); break;
            }
        }
        public void Print()
        {
            System.Console.WriteLine($"x: {this.x}, y: {this.y}, z: {this.z}");
        }
    }
}