(* ======================================
11-FRP.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 11: Functional Retroactive Programming -- Business logic is based on reacting to earlier events

In this design, the `write-side` follows the same pattern as the event-sourcing example.
A client sends a Command to a CommandHandler, which converts that to a list of events and stores them in an EventStore.

However in this design, the CommandHandler only updates state and does NOT do any complex business logic.

The domain logic is done on the \
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
// Way 11 Helper Classes
// ======================================

module W11Base = 

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
    
    

