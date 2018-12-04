open System
let input = System.IO.File.ReadAllLines("input.txt") |> Array.toList

type Box = {
    Two: bool
    Three: bool
}

let initialState = {
    Two = false
    Three = false
}

let findTwosAndThrees line = 
    List.fold (fun acc (chr, num) ->
        match (chr, num) with
        |   (_, 3) -> {acc with Three = true}
        |   (_, 2) -> {acc with Two = true}
        |   (_, _) -> acc) initialState line

[<EntryPoint>]
let main argv =
    let line = "aabbccddd"
    let arr = List.map (fun x -> [for c in x -> c]) input |> List.map (List.countBy id) |> List.map findTwosAndThrees


    let sumTwo = List.sumBy (fun elem -> if elem.Two then 1 else 0) arr
    let sumThrees = List.sumBy (fun elem -> if elem.Three then 1 else 0) arr
    let checksum = (*) sumTwo sumThrees
    printfn "%A" checksum
    0