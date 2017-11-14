(* ======================================
12-BranchingOnResponse.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 12: Monadic control flow -- Making decisions in the turtle computation expression

In this design, the turtle can reply to certain commands with errors.

The code demonstrates how the client can make decisions inside the turtle computation expression
while the state is being passed around behind the scenes.
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
// Way 12 Helper Classes
// ======================================

module W12Base = 

    /// Function to log a message
    let log message =
        printfn "%s" message 

    
    
    let drawTriangle() = 
        printfn "PRINTING Triangle!"
        // let turtle = Turtle(log)
        
        // turtle.Move 100.0
        // turtle.Turn 120.0<Degrees>
        // turtle.Move 100.0
        // turtle.Turn 120.0<Degrees>
        // turtle.Move 100.0
        // turtle.Turn 120.0<Degrees>
    
    
    let drawThreeLines() = 
        printfn "PRINTING ThreeLines!"
        // let turtle = Turtle(log)
        
        // Draw black line
        // turtle.PenDown ()
        // turtle.SetColor Black
        // turtle.Move 100.0
        // Move without Drawing
        // turtle.PenUp ()
        // turtle.Turn 90.0<Degrees>
        // turtle.Move 100.0
        // turtle.Turn 90.0<Degrees>
        // Draw red line
        // turtle.PenDown ()
        // turtle.SetColor Red
        // turtle.Move 100.0
        // Move without Drawing
        // turtle.PenUp ()
        // turtle.Turn 90.0<Degrees>
        // turtle.Move 100.0
        // turtle.Turn 90.0<Degrees>
        // Back home at (0,0) with angle 0, Draw diagonal blue line
        // turtle.PenDown ()
        // turtle.SetColor Blue
        // turtle.Turn 45.0<Degrees>
        // turtle.Move 100.0
    
    
    let drawBox() = 
        printfn "PRINTING Box!"
        // let turtle = Turtle(log)
        
        // turtle.Move 100.0
        // turtle.Turn 90.0<Degrees>
        // turtle.Move 100.0
        // turtle.Turn 90.0<Degrees>
        // turtle.Move 100.0
        // turtle.Turn 90.0<Degrees>
        // turtle.Move 100.0
        // turtle.Turn 90.0<Degrees>
    
    

