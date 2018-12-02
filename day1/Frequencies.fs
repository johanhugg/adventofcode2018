module Frequencies

let frequencies path = List.ofSeq(System.IO.File.ReadLines(path))

let matchStringWithFrequency (freq:string) =
    if freq.StartsWith("-") then
        freq |> int
    else if freq.StartsWith("+") then
        freq |> int
    else
        0

let input = List.map matchStringWithFrequency (frequencies "frequencies.txt")

type FrequencyState = {
    Frequencies: int list
    Previous: int list
    ResultFromPrevious: int
    Result: int
    Iteration: int
}
let initialState = {
    Frequencies = input
    Previous = [0]
    ResultFromPrevious = 0
    Result = 0
    Iteration = 0
}

let rec detectRepetitionOfFrequencies state:FrequencyState =
    let res = 
        state.Frequencies.Head + state.ResultFromPrevious
    if List.contains res state.Previous then
        {state with Result = res}
    else if state.Frequencies.Length = 1 then
        printfn "%i" state.Iteration 
        let newPrevFreqs = {state with Previous = res :: state.Previous; ResultFromPrevious = res; Frequencies = input; Iteration = state.Iteration + 1}
        detectRepetitionOfFrequencies newPrevFreqs
    else 
        let newPrevFreqsAndFreqs = {state with Previous = res :: state.Previous; Frequencies = List.skip 1 state.Frequencies; ResultFromPrevious = res}
        detectRepetitionOfFrequencies newPrevFreqsAndFreqs
