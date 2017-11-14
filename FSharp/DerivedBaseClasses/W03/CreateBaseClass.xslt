<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>../W03Base.fsx</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">(* ======================================
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

        // convert the angle parameter to a float&lt;Degrees>, or throw an exception
        let validateAngle angleStr =
            try
                (float angleStr) * 1.0&lt;Degrees> 
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

    
    <xsl:for-each select="//PredefinedScripts/PredefinedScript">
    <xsl:variable name="pds-name" select="Name" />
    let draw<xsl:value-of select="$pds-name" />() = 
        printfn "PRINTING <xsl:value-of select="$pds-name" />!"
        let api = TurtleApi()

        <xsl:for-each select="//PredefinedScriptStep[normalize-space(PredefinedScript) = $pds-name]" xml:space="default">
            <xsl:variable name="command" select="//TurtleCommand[Name = current()/Command]" />
            <xsl:if test="normalize-space(Description) != ''">
            <xsl:text>
        // </xsl:text>
        <xsl:value-of select="Description" />
        </xsl:if><xsl:text>
        api.Exec "</xsl:text>
        <xsl:value-of select="$command/APIName" />&#32;<xsl:choose>
            <xsl:when test="normalize-space($command/APIArgument) != ''">
                <xsl:value-of select="$command/APIArgument" />
            </xsl:when>
            <xsl:otherwise>
                <xsl:value-of select="Argument" />
            </xsl:otherwise>
        </xsl:choose>"</xsl:for-each>
    </xsl:for-each>
    

</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>

