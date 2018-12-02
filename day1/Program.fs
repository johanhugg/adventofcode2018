open System
open Frequencies

[<EntryPoint>]
let main argv =
    let result = detectRepetitionOfFrequencies initialState
    printfn "%i" result.Result
    0 
