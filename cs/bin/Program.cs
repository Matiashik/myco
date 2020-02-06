using System.Resources;
using Gtk;

namespace bin
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var builder = new Gtk.Builder();
            builder.AddFromFile("res/Main.ui");
            var window = (Gtk.Window)(builder.GetObject("Main_w"));
            window.ShowAll();
            Application.Run();
        }
    }
}