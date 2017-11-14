(* ======================================
02-FPTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 02: Simple FP - a module of functions with immutable state

In this design, the turtle state is immutable. A module contains functions that return a new turtle state,
and the client uses these turtle functions directly.

The client must keep track of the current state and pass it into the next function call.
====================================== *)

#load "../Common.fsx"

open Common

// ======================================
// FP Turtle
// ======================================

// see code in this file
#load "../FPTurtleLib.fsx"
open FPTurtleLib

// ======================================
// Way 02 Helper Classes
// ======================================

module W02Base = 

    /// Function to log a message
    let log message =
        printfn "%s" message 

    
    let move = Turtle.move log
    let turn = Turtle.turn log
    let penUp = Turtle.penUp log
    let penDown = Turtle.penDown log
    let setColor = Turtle.setColor log

    
    
    let drawTriangle() = 
        printfn "PRINTING Triangle!"
        
        Turtle.initialTurtleState
        |> move 275.0
        |> turn 120.0<Degrees>
        |> move 275.0
        |> turn 120.0<Degrees>
        |> move 275.0
        |> turn 120.0<Degrees>
    
    
    let drawThreeLines() = 
        printfn "PRINTING ThreeLines!"
        
        Turtle.initialTurtleState
        // Draw black line
        |> penDown 
        |> setColor Black
        |> move 100.0
        // Move without Drawing
        |> penUp 
        |> turn 90.0<Degrees>
        |> move 100.0
        |> turn 90.0<Degrees>
        // Draw red line
        |> penDown 
        |> setColor Red
        |> move 100.0
        // Move without Drawing
        |> penUp 
        |> turn 90.0<Degrees>
        |> move 100.0
        |> turn 90.0<Degrees>
        // Back home at (0,0) with angle 0, Draw diagonal blue line
        |> penDown 
        |> setColor Blue
        |> turn 45.0<Degrees>
        |> move 100.0
    
    
    let drawBox() = 
        printfn "PRINTING Box!"
        
        Turtle.initialTurtleState
        |> move 100.0
        |> turn 90.0<Degrees>
        |> move 100.0
        |> turn 90.0<Degrees>
        |> move 100.0
        |> turn 90.0<Degrees>
        |> move 100.0
        |> turn 90.0<Degrees>
    
    

