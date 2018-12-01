// Learn more about F# at http://fsharp.org

open System
open Frequencies

[<EntryPoint>]
let main argv =
    let result = frequencies.Split("\n") |> Array.toList |> List.map matchStringWithFrequency |> List.choose id |> List.sum
    printfn "%i" result 
    0 // return an integer exit code
