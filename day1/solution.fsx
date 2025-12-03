open System.IO

let mutable lines = File.ReadLines "input.txt"

let mutable total = 50
let mutable count = 0

for l in lines do
    let value =
        match System.Int32.TryParse(l.Replace("R", "+").Replace("L", "-")) with
        | true, v -> v
        | false, _ -> 0

    total <- (total + value) % 100

    if total = 0 then
        count <- count + 1

printfn "Final total: %d" total
printfn "Zero count: %d" count


total <- 50
count <- 0
lines <- File.ReadLines "input.txt"

for l in lines do
    let value =
        match System.Int32.TryParse(l.Replace("R", "+").Replace("L", "-")) with
        | true, v -> v
        | false, _ -> 0

    let wraps =
        if value >= 0 then
            (total + value) / 100
        else
            (-(total + value) + 100) / 100

    let shiftedWraps = if total = 0 && value < 0 then wraps - 1 else wraps

    count <- count + shiftedWraps

    total <-
        if total + value >= 0 then
            (total + value) % 100
        else
            ((total + value) % 100 + 100) % 100

printfn "Final total: %d" total
printfn "Zero count: %d" count
