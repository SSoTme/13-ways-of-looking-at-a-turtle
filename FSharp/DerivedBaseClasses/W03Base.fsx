(* ======================================
03-Api_OO_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 03: API (OO Approach) -- OO API calling stateful core class

In this design, an API layer communicates with a turtle class
and the client talks to the API layer.

The input to the API are strings, and so the API validates the
input and returns a Result containing any errors.
====================================== *)

#load "../Common.fsx"

open Common

// ======================================
// OO Turtle
// ======================================

// see code in this file
#load "../OOTurtleLib.fsx"
open OOTurtleLib


// ======================================
// Turtle Api Layer
// ======================================

module TurtleApiLayer = 
    open OOTurtleLib

    /// Define the exception for API errors
    exception TurtleApiException of string

    /// Function to log a message
    let log message =
        printfn "%s" message 



// ======================================
// Way 03 Helper Classes
// ======================================

module W03Base = 
    open TurtleApiLayer

    /// Function to log a message
    let log message =
        printfn "%s" message 



    type TurtleApi() =

        let turtle = Turtle(log)

        // convert the distance parameter to a float, or throw an exception
        let validateDistance distanceStr =
            try
                float distanceStr 
            with
            | ex -> 
                let msg = sprintf "Invalid distance '%s' [%s]" distanceStr  ex.Message
                raise (TurtleApiException msg)

        // convert the angle parameter to a float<Degrees>, or throw an exception
        let validateAngle angleStr =
            try
                (float angleStr) * 1.0<Degrees> 
            with
            | ex -> 
                let msg = sprintf "Invalid angle '%s' [%s]" angleStr ex.Message
                raise (TurtleApiException msg)

        // convert the color parameter to a PenColor, or throw an exception
        let validateColor colorStr =
            match colorStr with
            | "Black" -> Black
            | "Blue" -> Blue
            | "Red" -> Red
            | _ -> 
                let msg = sprintf "Color '%s' is not recognized" colorStr
                raise (TurtleApiException msg)
                
        /// Execute the command string, or throw an exception
        /// (Exec : commandStr:string -> unit)
        member this.Exec (commandStr:string) = 
            let tokens = commandStr.Split(' ') |> List.ofArray |> List.map trimString
            match tokens with
            | [ "Move"; distanceStr ] -> 
                let distance = validateDistance distanceStr 
                turtle.Move distance 
            | [ "Turn"; angleStr ] -> 
                let angle = validateAngle angleStr
                turtle.Turn angle  
            | [ "Pen"; "Up" ] -> 
                turtle.PenUp()
            | [ "Pen"; "Down" ] -> 
                turtle.PenDown()
            | [ "SetColor"; colorStr ] -> 
                let color = validateColor colorStr 
                turtle.SetColor color
            | _ -> 
                let msg = sprintf "Instruction '%s' is not recognized" commandStr
                raise (TurtleApiException msg)

    
    
    
    let drawTriangle() = 
        printfn "PRINTING Triangle!"
        let api = TurtleApi()

        
        api.Exec "Move 275"
        api.Exec "Turn 120"
        api.Exec "Move 275"
        api.Exec "Turn 120"
        api.Exec "Move 275"
        api.Exec "Turn 120"
    
    
    let drawThreeLines() = 
        printfn "PRINTING ThreeLines!"
        let api = TurtleApi()

        
        // Draw black line
        api.Exec "Pen Down"
        api.Exec "SetColor Black"
        api.Exec "Move 100"
        // Move without Drawing
        api.Exec "Pen Up"
        api.Exec "Turn 90"
        api.Exec "Move 100"
        api.Exec "Turn 90"
        // Draw red line
        api.Exec "Pen Down"
        api.Exec "SetColor Red"
        api.Exec "Move 100"
        // Move without Drawing
        api.Exec "Pen Up"
        api.Exec "Turn 90"
        api.Exec "Move 100"
        api.Exec "Turn 90"
        // Back home at (0,0) with angle 0, Draw diagonal blue line
        api.Exec "Pen Down"
        api.Exec "SetColor Blue"
        api.Exec "Turn 45"
        api.Exec "Move 100"
    
    
    let drawBox() = 
        printfn "PRINTING Box!"
        let api = TurtleApi()

        
        api.Exec "Move 100"
        api.Exec "Turn 90"
        api.Exec "Move 100"
        api.Exec "Turn 90"
        api.Exec "Move 100"
        api.Exec "Turn 90"
        api.Exec "Move 100"
        api.Exec "Turn 90"
    
    

