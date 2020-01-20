module MainW

open Gtk

let Create =
    //Main.glade
    Application.Init()
    let builder = new Builder()
    builder.AddFromFile "/home/universai/myco/fs/app/src/env/Main.glade" |> ignore
    let obj = builder.GetObject "window_main"
    let window = obj :?> Window
    window.ShowAll()
    Application.Run()