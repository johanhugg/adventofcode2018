module Frequencies

let frequencies path = List.ofSeq(System.IO.File.ReadLines(path))

let matchStringWithFrequency (freq:string) =
    if freq.StartsWith("-") then
        freq |> int
    else if freq.StartsWith("+") then
        freq |> int
    else
        0

let rec detectRepetitionOfFrequencies (prevFreqs:List<int>) (freqs:List<int>) (initialFreqs:List<int>) (resultFromPrevious:int) = 
    let res = 
        (List.take 1 freqs |> List.sum) + resultFromPrevious
    if List.contains res prevFreqs then
        res
    else if freqs.Length = 1 then
        detectRepetitionOfFrequencies (List.append prevFreqs [res]) initialFreqs initialFreqs res 
    else 
        detectRepetitionOfFrequencies (List.append prevFreqs [res]) (List.skip 1 freqs) initialFreqs res
