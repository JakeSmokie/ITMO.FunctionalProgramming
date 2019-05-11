module FP.Task03.Tests.GeneratorTests

open Xunit
open FsUnit.Xunit
open FP.Task03.FunctionValuesGenerator

let check (ax, ay) (bx, by) =
  abs (by - ay) |> should lessThan 0.0000000001
  abs (bx - ax) |> should lessThan 0.0000000001

[<Fact>]
let ``Linear function is generated correctly``() =
  let expected = [
    (0.0, 0.0); (1.0, 3.0); (2.0, 6.0); (3.0, 9.0); (4.0, 12.0); (5.0, 15.0);
    (6.0, 18.0); (7.0, 21.0); (8.0, 24.0); (9.0, 27.0); (10.0, 30.0)
  ]

  let actual = genValues ((*) 3.0) 0.0 10.0 1.0
  Seq.iter2 check actual expected

[<Fact>]
let ``Sin function is generated correctly``() =
  let expected = [
    (0.0, 0.0); (0.2, 0.1986693308); (0.4, 0.3894183423); (0.6, 0.5646424734);
    (0.8, 0.7173560909); (1.0, 0.8414709848); (1.2, 0.932039086);
    (1.4, 0.98544973); (1.6, 0.999573603); (1.8, 0.9738476309);
    (2.0, 0.9092974268); (2.2, 0.8084964038); (2.4, 0.6754631806);
    (2.6, 0.5155013718); (2.8, 0.3349881502); (3.0, 0.1411200081);
    (3.2, -0.05837414343); (3.4, -0.255541102); (3.6, -0.4425204433);
    (3.8, -0.6118578909); (4.0, -0.7568024953); (4.2, -0.8715757724);
    (4.4, -0.9516020739); (4.6, -0.9936910036); (4.8, -0.9961646088);
    (5.0, -0.9589242747); (5.2, -0.8834546557); (5.4, -0.7727644876);
    (5.6, -0.6312666379); (5.8, -0.4646021794); (6.0, -0.2794154982);
    (6.2, -0.08308940282); (6.4, 0.1165492049); (6.6, 0.3115413635);
    (6.8, 0.4941133511); (7.0, 0.6569865987); (7.2, 0.7936678638);
    (7.4, 0.8987080958); (7.6, 0.967919672); (7.8, 0.9985433454);
    (8.0, 0.9893582466); (8.2, 0.9407305567); (8.4, 0.8545989081);
    (8.6, 0.7343970979); (8.8, 0.5849171929); (9.0, 0.4121184852);
    (9.2, 0.2228899141); (9.4, 0.02477542545); (9.6, -0.1743267812);
    (9.8, -0.3664791293); (10.0, -0.5440211109)
  ]

  let actual = genValues sin 0.0 10.0 0.2
  Seq.iter2 check actual expected
