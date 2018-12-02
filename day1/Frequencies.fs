module Frequencies

let frequencies path = List.ofSeq(System.IO.File.ReadLines(path)) |> List.map int

let input = frequencies "frequencies.txt"

type FrequencyState = {
    Frequencies: int list
    Previous: Map<int, int>
    ResultFromPrevious: int
    Result: int
    Iteration: int
}
let initialState = {
    Frequencies = input
    Previous = Map.empty.Add(0, 0)
    ResultFromPrevious = 0
    Result = 0
    Iteration = 0
}

let rec detectRepetitionOfFrequencies state:FrequencyState =
    let res = 
        state.Frequencies.Head + state.ResultFromPrevious
    if Map.containsKey res state.Previous then
        {state with Result = res}
    else if state.Frequencies.Length = 1 then
        printfn "%i" state.Iteration 
        let newPrevFreqs = {state with Previous = state.Previous.Add(res, res); ResultFromPrevious = res; Frequencies = input; Iteration = state.Iteration + 1}
        detectRepetitionOfFrequencies newPrevFreqs
    else 
        let newPrevFreqsAndFreqs = {state with Previous = state.Previous.Add(res, res); Frequencies = List.skip 1 state.Frequencies; ResultFromPrevious = res}
        detectRepetitionOfFrequencies newPrevFreqsAndFreqs
