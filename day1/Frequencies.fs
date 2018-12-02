module Frequencies

let frequencies path = List.ofSeq(System.IO.File.ReadLines(path))

let matchStringWithFrequency (freq:string) =
    if freq.StartsWith("-") then
        freq |> int
    else if freq.StartsWith("+") then
        freq |> int
    else
        0

let rec detectRepetitionOfFrequencies (prevFreqs:List<int>) (freqs:List<int>) (initialFreqs:List<int>) = 
    printfn "Previous: %A" prevFreqs
    printfn "Current:  %A" freqs
    let res = 
        if freqs.Length >= 2 then
            List.take 2 freqs |> List.sum
        else 
            freqs |> List.sum

    if freqs.Length = 1 then
        detectRepetitionOfFrequencies prevFreqs initialFreqs initialFreqs
    else if List.contains res prevFreqs then
        printfn "%A" prevFreqs
        printfn "%A" freqs
        res
    else 
        detectRepetitionOfFrequencies (List.append prevFreqs [res]) (List.append [res] (List.skip 2 freqs)) initialFreqs
