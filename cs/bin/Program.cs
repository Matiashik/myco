using System;
using Gtk;

namespace bin
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var builder = new Gtk.Builder();
            builder.AddFromFile("Main.ui");
            var window = (Gtk.Window)(builder.GetObject("window_main"));
            window.ShowAll();
            Application.Run();
        }
    }
}
