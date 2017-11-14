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
                        <xsl:text>../W04Api_FP_CoreBase.cs</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">/* ======================================
04-Api_FP_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 04: API (OO/FP hybrid approach) -- OO API calling stateless functions

In this design, an API layer communicates with pure turtle functions
and the client talks to the API layer.

The API layer manages the state (rather than the client) by storing a mutable turtle state.

*This approach has been named \
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // Way 04 Helper Classes
    // ======================================
    public abstract class W04Api_FP_CoreBase : TurtleBase
    {
        <xsl:for-each select="//PredefinedScripts/PredefinedScript">
        <xsl:variable name="pds-name" select="Name" />
        public<xsl:if test="Version = 1"> override</xsl:if> void draw<xsl:value-of select="$pds-name" />()
        {
            this.log("PRINTING <xsl:value-of select="$pds-name" />!");
            var turtle = new Turtle(log);

            <xsl:for-each select="//PredefinedScriptStep[normalize-space(PredefinedScript) = $pds-name]"><xsl:if test="normalize-space(Description) != ''">
            // <xsl:value-of select="Description" /></xsl:if><xsl:text>
            turtle.</xsl:text><xsl:value-of select="Command" />(<xsl:if test="ArgumentType = 'Color'">PenColor.</xsl:if><xsl:value-of select="Argument" />);</xsl:for-each>
        }</xsl:for-each>
    }
}


    

</xsl:element>
                </FileSetFile>
                   <FileSetFile>
                    <RelativePath>
                        <xsl:text>../../W04Api_FP_Core.cs</xsl:text>
                    </RelativePath>
                    <OverwriteMode>Never</OverwriteMode>
                    <xsl:element name="FileContents" xml:space="preserve">/* ======================================
04-Api_FP_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 04: API (OO/FP hybrid approach) -- OO API calling stateless functions

In this design, an API layer communicates with pure turtle functions
and the client talks to the API layer.

The API layer manages the state (rather than the client) by storing a mutable turtle state.

*This approach has been named \
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLib1.BaseClasses;

namespace CSharpLib1
{
    // ======================================
    // Way 04 Class
    // ======================================
   public abstract class W03Api_OO_CoreBase : TurtleBase
    {
        <xsl:for-each select="//PredefinedScripts/PredefinedScript">
        <xsl:variable name="pds-name" select="Name" />
        public<xsl:if test="Version = 1"> override</xsl:if> void draw<xsl:value-of select="$pds-name" />()
        {
            this.log("PRINTING <xsl:value-of select="$pds-name" />!");
            var api = new ApiTurtle(log);

            <xsl:for-each select="//PredefinedScriptStep[normalize-space(PredefinedScript) = $pds-name]"><xsl:if test="normalize-space(Description) != ''">
            // <xsl:value-of select="Description" /></xsl:if><xsl:text>
            api.Exec("</xsl:text><xsl:value-of select="Command" /> <xsl:value-of select="Argument" />");</xsl:for-each>
        }</xsl:for-each>
    }

    
  

    public abstract class ApiTurtleBase
    {
        public Action&lt;string, object[]> log;

        public ApiTurtleBase(Action&lt;string, object[]> log)
        {
            this.log = log;
        }

        internal abstract void Exec(string command);
    }
}

</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>

