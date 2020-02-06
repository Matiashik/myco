package com.universai.main;

import com.universai.handlers.ButtonHandler;
import com.universai.handlers.WindowHandler;
import org.gnome.gdk.Pixbuf;
import org.gnome.gtk.*;
import java.nio.charset.StandardCharsets;

public class Main_w {
    public static void init() {

        final var b = new Builder();

        try {
            var in = Main.class.getResourceAsStream("/ui/Main.ui");
            byte[] res = new byte[in.available()];
            in.read(res);
            in.close();
            b.addFromString(new String(res, StandardCharsets.UTF_8));
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }

        final var w = (Window)b.getObject("Main_w");
        final var but = (Button)b.getObject("Main_w_box_but");
        final var lab = (Label)b.getObject("Main_w_box_lab");

        but.connect(new ButtonHandler(lab, but));
        w.connect(new WindowHandler());

        w.showAll();
    }
}
