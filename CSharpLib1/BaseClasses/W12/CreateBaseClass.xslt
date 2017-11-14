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
                        <xsl:text>../W12BranchingOnResponseBase.cs</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">/* ======================================
12-BranchingOnResponse.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 12: Monadic control flow -- Making decisions in the turtle computation expression

In this design, the turtle can reply to certain commands with errors.

The code demonstrates how the client can make decisions inside the turtle computation expression
while the state is being passed around behind the scenes.
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // Way 12 Helper Classes
    // ======================================
    public abstract class W12BranchingOnResponseBase : TurtleBase
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
                        <xsl:text>../../W12BranchingOnResponse.cs</xsl:text>
                    </RelativePath>
                    <OvewriteMode>Never</OvewriteMode>
                    <xsl:element name="FileContents" xml:space="preserve">/* ======================================
12-BranchingOnResponse.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 12: Monadic control flow -- Making decisions in the turtle computation expression

In this design, the turtle can reply to certain commands with errors.

The code demonstrates how the client can make decisions inside the turtle computation expression
while the state is being passed around behind the scenes.
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
    // Way 12 Class
    // ======================================
    public class BranchingOnResponse : W12BranchingOnResponseBase
    {
        // define a function that draws one side
        private void drawOneSide(Turtle turtle, float angleDegrees)
        {
            turtle.Move(100);
            turtle.Turn(angleDegrees);
        }

        public override void drawPolygon(int n)
        {
            var angle = 180.0 - (360.0 / (float)n);
            var angleDegrees = angle * 1.0f;
            var turtle = new Turtle(log);


            // repeat for all sides
            for (var i = 0; i &lt; n; i++)
                this.drawOneSide(turtle, (float)angleDegrees);
        }

    }
}
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>

