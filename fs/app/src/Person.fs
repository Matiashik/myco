namespace App

type Person(age0: int option, name0: string option) =
    let mutable age = age0
    let mutable name = name0

    static let mutable number = 0

    static member Number = number

    member this.Name
        with get () =
            match name with
            | Some(name) -> name
            | _ -> "undefined"
        and set (value: string) = name <- Some(value)

    member this.Age
        with get () =
            match age with
            | Some(age) -> age
            | _ -> -1
        and set (value: int) = age <- Some(value)

    member this.Print () = printfn "Age = %d, name = %s, one of %d" this.Age this.Name Person.Number


    new(age0: int) =
        Person(Some(age0), None)
        then number <- number + 1

    new(age0: int, name0: string) =
        Person(Some(age0), Some(name0))
        then number <- number + 1
