(* ======================================
03-Api_OO_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way #3: API (OO Approach) -- OO API calling stateful core class

In this design, an API layer communicates with a turtle class
and the client talks to the API layer.

The input to the API are strings, and so the API validates the
input and returns a Result containing any errors. 

====================================== *)

#load "DerivedBaseClasses/W03Base.fsx"

#load "Common.fsx"
#load "OOTurtleLib.fsx"


open System
open Common


// ======================================
// Turtle Api Client
// ======================================

module TurtleApiClient = 
    open W03Base

    let drawTriangle() = 
        W03Base.drawTriangle()
            
    let drawThreeLines() = 
        W03Base.drawThreeLines()

    let drawBox() =
        W03Base.drawBox()

    let drawPolygon n = 
        let angle = 180.0 - (360.0/float n) 
        let api = W03Base.TurtleApi()

        // define a function that draws one side
        let drawOneSide() = 
            api.Exec "Move 100.0"
            api.Exec (sprintf "Turn %f" angle)

        // repeat for all sides
        for i in [1..n] do
            drawOneSide()

    let triggerError() = 
        let api = W03Base.TurtleApi()
        api.Exec "Move bad"

// ======================================
// Turtle API tests
// ======================================

TurtleApiClient.drawTriangle() 
TurtleApiClient.drawThreeLines() 
TurtleApiClient.drawPolygon 4 

// test errors
TurtleApiClient.triggerError()
// Exception of type 'TurtleApiException' was thrown.

