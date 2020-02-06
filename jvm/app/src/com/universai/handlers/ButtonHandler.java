package com.universai.handlers;

import org.gnome.gtk.*;

public class ButtonHandler implements Button.Clicked {
    private Label l;
    private Button b;
    public ButtonHandler(Label l, Button b) {
        this.l = l;
        this.b = b;
    }
    public void onClicked(Button source) {
        if(b.getLabel().equals("Тык не делать!")) Gtk.mainQuit();
        l.setLabel("Ты молодец!");
        b.setLabel("Тык не делать!");
    }
}
