package com.universai.handlers;

import org.gnome.gdk.Event;
import org.gnome.gtk.Gtk;
import org.gnome.gtk.Widget;
import org.gnome.gtk.Window;

public class WindowHandler implements Window.DeleteEvent {
    public boolean onDeleteEvent(Widget widget, Event event) {
        Gtk.mainQuit();
        return false;
    }
}
