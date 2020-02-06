package com.universai.main;

import org.gnome.gtk.*;

public class Main {
    public static void main(String[] args) {
        Gtk.init(args);
        Main_w.init();
        Gtk.main();
    }
}