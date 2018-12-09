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

type PuzzleState = {
    Boxes: string list
    Result: string * string
}

let initialPuzzleState = {
    Boxes = input
    Result = String.Empty, String.Empty
}

let findBoxSimilarOffByOne (boxTuple: string * string) = 
    let line, boxId = boxTuple
    let lineCharArray = line.ToCharArray() |> Array.toList
    let boxIdCharArray = boxId.ToCharArray() |> Array.toList
    let matches = List.fold2 (fun acc x y -> 
                if x = y then acc + 1 else acc) 0 lineCharArray boxIdCharArray
    let removeMatchingCharacter = List.filter (fun (x, y) -> x = y) (List.zip lineCharArray boxIdCharArray) |> List.map (fun (x, _) -> x) |> Array.ofList |> String
    if matches = line.Length - 1 then
        Some(removeMatchingCharacter);
    else
        None
let findSimilarBoxId state =
    let compareBoxWithBoxes line = 
        let lines = seq { for _ in 1 .. state.Boxes.Length -> line} |> Seq.toList
        let linesAndInputZip = List.zip lines input |> List.filter (fun (x, y) -> x <> y)
        let result = List.map findBoxSimilarOffByOne linesAndInputZip |> List.choose id
        if result.Length > 0 then
            Some(result.Head)
        else
            None
    List.map compareBoxWithBoxes state.Boxes |> List.choose id |> List.distinct |> List.item 0

[<EntryPoint>]
let main argv =
    let arr = List.map (fun x -> [for c in x -> c]) input |> List.map (List.countBy id) |> List.map findTwosAndThrees
    let sumTwo = List.sumBy (fun elem -> if elem.Two then 1 else 0) arr
    let sumThrees = List.sumBy (fun elem -> if elem.Three then 1 else 0) arr
    let checksum = (*) sumTwo sumThrees
    printfn "%A" checksum
    printfn "%A" (findSimilarBoxId initialPuzzleState)
    0