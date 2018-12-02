open System
open Frequencies

[<EntryPoint>]
let main argv =
    let loadedFrequencies = frequencies "frequencies.txt"
    let freqs = List.map matchStringWithFrequency loadedFrequencies
    let result = detectRepetitionOfFrequencies [0] freqs freqs 0
    printfn "%i" result
    0 
