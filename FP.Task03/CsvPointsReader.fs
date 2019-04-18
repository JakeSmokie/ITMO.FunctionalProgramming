module FP.Task03.CsvPointsReader
open System
open FSharp.Data

type Points =
  CsvProvider<Separators=";",
              Schema="x (float), y (float)",
              HasHeaders=false>

let rec readlines() = seq {
  let line = stdin.ReadLine()
  if line <> null then
    yield line
    yield! readlines()
}

let readPoints() =
  let rawCsv = String.Join("\n", readlines())
  let points = Points.ParseRows(rawCsv)

  points |> Seq.map (fun row -> (row.X, row.Y))

let printPoints points =
  let doc = new Points(List.map Points.Row points)
  printfn "%s" (doc.SaveToString())
