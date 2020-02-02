package com.universai.main;

import org.gnome.gtk.Builder;
import org.gnome.gtk.Gtk;
import org.gnome.gtk.Window;

public class Main {
    public static void main(String[] args) {
        Gtk.init(args);
        final var b = new Builder();
        try {
            var in = Main.class.getResourceAsStream("/ui/Main.ui");
            byte[] res = new byte[in.available()];
            in.read(res);
            in.close();
            b.addFromString(new String(res, "UTF-8"));
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        final var w = (Window)b.getObject("Main_w");
        w.showAll();
        Gtk.main();
    }
}