// Learn more about F# at http://fsharp.org

open System
open Frequencies

[<EntryPoint>]
let main argv =
    let loadedFrequencies = frequencies "frequencies.txt"
    let freqs = List.map matchStringWithFrequency loadedFrequencies
    let result = detectRepetitionOfFrequencies (List.append [0] (List.take 1 freqs)) freqs freqs
    printfn "%i" result
    0 // return an integer exit code
