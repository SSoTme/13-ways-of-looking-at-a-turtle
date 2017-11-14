(* ======================================
01-OOTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way #1: Simple OO -- a class with mutable state

In this design, a simple OO class represents the turtle,
and the client talks to the turtle directly.

====================================== *)

#load "DerivedBaseClasses/W01Base.fsx"

open Common
open W01Base

// ======================================
// OO Turtle Client
// ======================================

module OOTurtleClient = 
    open OOTurtleLib


    /// Function to log a message
    let log message =
        printfn "%s" message 

    let drawTriangle() = 
        W01Base.drawTriangle()
            
    let drawThreeLines() = 
        W01Base.drawThreeLines()

    let drawBox() = 
        W01Base.drawBox()


    let drawPolygon n = 
        let angle = 180.0 - (360.0/float n) 
        let angleDegrees = angle * 1.0<Degrees>
        let turtle = Turtle(log)

        // define a function that draws one side
        let drawOneSide() = 
            turtle.Move 100.0 
            turtle.Turn angleDegrees 

        // repeat for all sides
        for i in [1..n] do
            drawOneSide()

// ======================================
// OO Turtle tests
// ======================================

OOTurtleClient.drawTriangle() 
OOTurtleClient.drawThreeLines() 
OOTurtleClient.drawBox() 
OOTurtleClient.drawPolygon 4 

