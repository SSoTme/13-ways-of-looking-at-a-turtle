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
            <xsl:for-each select="//WayOfLookingAtATurtle">
                <FileSetFile>
                    <RelativePath>
                        <xsl:value-of select="WayNumber" /><xsl:text>/CreateBaseClass.xslt</xsl:text>
                    </RelativePath>
                    <OverwriteMode>Never</OverwriteMode>
                    <xsl:element name="FileContents" xml:space="preserve">&lt;?xml version="1.0" encoding="utf-8"?>
&lt;xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    &lt;xsl:output method="xml" indent="yes"/>

    &lt;xsl:param name="output-filename" select="'output.txt'" />

    &lt;xsl:template match="@* | node()">
        &lt;xsl:copy>
            &lt;xsl:apply-templates select="@* | node()"/>
        &lt;/xsl:copy>
    &lt;/xsl:template>

    &lt;xsl:template match="/*">
        &lt;FileSet>
            &lt;FileSetFiles>
                &lt;FileSetFile>
                    &lt;RelativePath>
                        &lt;xsl:text>../<xsl:value-of select="WayNumber" />Base.fsx&lt;/xsl:text>
                    &lt;/RelativePath>
                    &lt;xsl:element name="FileContents" xml:space="preserve">(* ======================================
<xsl:value-of select="MainFileName"/>

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

<xsl:value-of select="DisplayWayNumber"/>: <xsl:value-of select="Description" />

<xsl:value-of select="Notes" />
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
// <xsl:value-of select="DisplayWayNumber"/> Helper Classes
// ======================================

module <xsl:value-of select="WayNumber" />Base = 

    /// Function to log a message
    let log message =
        printfn "%s" message 

    &lt;xsl:for-each select="//PredefinedScripts/PredefinedScript">
    &lt;xsl:variable name="pds-name" select="Name" />
    let draw&lt;xsl:value-of select="$pds-name" />() = 
        printfn "PRINTING &lt;xsl:value-of select="$pds-name" />!"
        // let turtle = Turtle(log)
        &lt;xsl:for-each select="//PredefinedScriptStep[normalize-space(PredefinedScript) = $pds-name]">&lt;xsl:if test="normalize-space(Description) != ''">
        // &lt;xsl:value-of select="Description" />&lt;/xsl:if>&lt;xsl:text>
        // turtle.&lt;/xsl:text>&lt;xsl:value-of select="Command" /> &lt;xsl:value-of select="Argument" />&lt;xsl:choose>
            &lt;xsl:when test="ArgumentType = 'Degrees'">.0&amp;lt;Degrees>&lt;/xsl:when>
            &lt;xsl:when test="ArgumentType = 'Distance'">.0&lt;/xsl:when>
            &lt;xsl:when test="normalize-space(ArgumentType) = ''">()&lt;/xsl:when>
        &lt;/xsl:choose>&lt;/xsl:for-each>
    &lt;/xsl:for-each>
    

&lt;/xsl:element>
                &lt;/FileSetFile>
            &lt;/FileSetFiles>
        &lt;/FileSet>
    &lt;/xsl:template>
&lt;/xsl:stylesheet>

</xsl:element>
                </FileSetFile>
                </xsl:for-each>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
