<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
    <xsl:include href="../CommonXsltTemplates.xslt" />

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
                        <xsl:text>../W02Base.fsx</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">(* ======================================
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

    <xsl:for-each select="//TurtleCommand[Version = 1]"><xsl:variable name="lowerName"><xsl:value-of select="substring(translate(Name, $ucletters, $lcletters), 1, 1)"/><xsl:value-of select="substring(Name, 2, string-length(Name))"/></xsl:variable>
    let <xsl:value-of select="$lowerName" /> = Turtle.<xsl:value-of select="$lowerName" /> log</xsl:for-each>

    <xsl:for-each select="//PredefinedScripts/PredefinedScript">
    <xsl:variable name="pds-name" select="Name" />
    let draw<xsl:value-of select="$pds-name" />() = 
        printfn "PRINTING <xsl:value-of select="$pds-name" />!"
        
        Turtle.initialTurtleState<xsl:for-each select="//PredefinedScriptStep[normalize-space(PredefinedScript) = $pds-name]"><xsl:if test="normalize-space(Description) != ''">
        // <xsl:value-of select="Description" /></xsl:if><xsl:variable name="lowerCommand"><xsl:value-of select="substring(translate(Command, $ucletters, $lcletters), 1, 1)"/><xsl:value-of select="substring(Command, 2, string-length(Command))"/></xsl:variable><xsl:text>
        |> </xsl:text><xsl:value-of select="$lowerCommand" /> <xsl:value-of select="Argument" /><xsl:choose>
            <xsl:when test="ArgumentType = 'Degrees'">.0&lt;Degrees></xsl:when>
            <xsl:when test="ArgumentType = 'Distance'">.0</xsl:when>
        </xsl:choose></xsl:for-each>
    </xsl:for-each>
    

</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>

