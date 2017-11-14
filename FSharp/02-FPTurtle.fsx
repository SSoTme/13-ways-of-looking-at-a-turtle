(* ======================================
02-FPTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way #2: Simple FP - a module of functions with immutable state

In this design, the turtle state is immutable. A module contains functions that return a new turtle state,
and the client uses these turtle functions directly.

The client must keep track of the current state and pass it into the next function call.

====================================== *)


#load "DerivedBaseClasses/W02Base.fsx"

open System
open Common

// ======================================
// FP Turtle
// ======================================

// see code in this file
#load "FPTurtleLib.fsx"
open FPTurtleLib

// ======================================
// FP Turtle Client
// ======================================

module FPTurtleClient = 

    /// Function to log a message
    let log message =
        printfn "%s" message 

    // versions with log baked in (via partial application)
    let move = Turtle.move log
    let turn = Turtle.turn log
    let penDown = Turtle.penDown log
    let penUp = Turtle.penUp log
    let setColor = Turtle.setColor log

    let drawTriangle() = 
        W02Base.W02Base.drawTriangle()
            
    let drawThreeLines() = 
        W02Base.W02Base.drawThreeLines()

    let drawBox() =
        W02Base.W02Base.drawBox()

    let drawPolygon n = 
        let angle = 180.0 - (360.0/float n) 
        let angleDegrees = angle * 1.0<Degrees>

        // define a function that draws one side
        let oneSide state sideNumber = 
            state
            |> move 100.0 
            |> turn angleDegrees 

        // repeat for all sides
        [1..n] 
        |> List.fold oneSide Turtle.initialTurtleState

// ======================================
// FP Turtle tests
// ======================================

FPTurtleClient.drawTriangle() |> ignore
FPTurtleClient.drawThreeLines() |> ignore
FPTurtleClient.drawPolygon 4 |> ignore


