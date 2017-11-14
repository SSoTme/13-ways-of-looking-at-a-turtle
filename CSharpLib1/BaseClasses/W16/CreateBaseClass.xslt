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
                        <xsl:text>../W16TurtleCanvasBase.cs</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">/* ======================================


Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 16: Turtle Canvas

This is a design which monitors the main `turtle` - and then runns the another turtle's tests.  

Each test is saved to a .png with the path traced by the turtle.
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // Way 16 Helper Classes
    // ======================================
    public abstract class W16TurtleCanvasBase : TurtleBase
    {

        protected abstract void ListenToTurtle();
        protected abstract void StopListeningToTurtle(string pngFileName);

        <xsl:for-each select="//PredefinedScripts/PredefinedScript">
        <xsl:variable name="pds-name" select="Name" />
        public<xsl:if test="Version = 1"> override</xsl:if> void draw<xsl:value-of select="$pds-name" />()
        {
            this.log("PRINTING <xsl:value-of select="$pds-name" />!");

            this.ListenToTurtle();
            var turtle = new Turtle(log);
            <xsl:for-each select="//PredefinedScriptStep[normalize-space(PredefinedScript) = $pds-name]"><xsl:if test="normalize-space(Description) != ''">
            // <xsl:value-of select="Description" /></xsl:if><xsl:text>
            turtle.</xsl:text><xsl:value-of select="Command" />(<xsl:if test="ArgumentType = 'Color'">PenColor.</xsl:if><xsl:value-of select="Argument" />);</xsl:for-each>

            this.StopListeningToTurtle("<xsl:value-of select="$pds-name" />.png");

        }</xsl:for-each>
    }
}


    

</xsl:element>
                </FileSetFile>
                   <FileSetFile>
                    <RelativePath>
                        <xsl:text>../../W16TurtleCanvas.cs</xsl:text>
                    </RelativePath>
                    <OvewriteMode>Never</OvewriteMode>
                    <xsl:element name="FileContents" xml:space="preserve">/* ======================================


Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 16: Turtle Canvas

This is a design which monitors the main `turtle` - and then runns the another turtle's tests.  

Each test is saved to a .png with the path traced by the turtle.
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
    // Way 16 Class
    // ======================================
    public class TurtleCanvas : W16TurtleCanvasBase
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

