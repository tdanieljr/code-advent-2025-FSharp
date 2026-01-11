open System.IO

let data = (File.ReadAllText "example.txt").Split ","

for r in data do
    let start = Array.head (r.Split "-")
    let stop = (r.Split "-")[1]
    printf "%s\n" start
    printf "%s\n" stop
