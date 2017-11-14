(* ======================================
07-DependencyInjection_Functions-1.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 07: Dependency injection using functions (v1: pass in all functions)

In this design, an API layer communicates via one or more functions that are passed in as parameters to the API call.
These functions are typically partially applied so that the call site is decoupled from the `injection`

No interface is passed to the constructor.
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
// Way 07 Helper Classes
// ======================================

module W07Base = 

    /// Function to log a message
    let log message =
        printfn "%s" message 

    
    
    let drawTriangle() = 
        printfn "PRINTING Triangle!"
        // let turtle = Turtle(log)
        
        // turtle.Move 275.0
        // turtle.Turn 120.0<Degrees>
        // turtle.Move 275.0
        // turtle.Turn 120.0<Degrees>
        // turtle.Move 275.0
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
    
    

