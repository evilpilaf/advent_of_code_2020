// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
open System
open System.IO

let loadedNumbers = seq{
    use sr = new StreamReader ("./day01/input.txt")
    while not sr.EndOfStream do
        yield sr.ReadLine () |> int
}

let sumWithRest (num:int) (others: int list) =
    others |> Seq.tryFind (fun other -> num+other = 2020)

let find (nums: int list) (action)  =
    nums
    |> Seq.mapi (fun i num ->
        match action num nums.[i+1..] with
        | Some x -> Some (num*x)
        | None -> None)


let numbers = [1; 21; 32; 2012; 8 ]


[<EntryPoint>]
let main argv =
    let numList = Seq.toList loadedNumbers
    let mapped = find numList (find (numList) sumWithRest)
    let a = mapped |> Seq.find (fun opt ->
        match opt with
        | Some _ -> true
        | None   -> false
        )
    printfn "%A" a
    0 // return an integer exit code