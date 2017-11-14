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
                        &lt;xsl:text>../<xsl:value-of select="WayNumber" /><xsl:value-of select="Name"  />Base.cs&lt;/xsl:text>
                    &lt;/RelativePath>
                    &lt;xsl:element name="FileContents" xml:space="preserve">/* ======================================
<xsl:value-of select="MainFileName"/>

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

<xsl:value-of select="DisplayWayNumber"/>: <xsl:value-of select="Description" />

<xsl:value-of select="Notes" />
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // <xsl:value-of select="DisplayWayNumber"/> Helper Classes
    // ======================================
    public abstract class <xsl:value-of select="WayNumber" /><xsl:value-of select="Name"  />Base : TurtleBase
    {
        &lt;xsl:for-each select="//PredefinedScripts/PredefinedScript">
        &lt;xsl:variable name="pds-name" select="Name" />
        public&lt;xsl:if test="Version = 1"> override&lt;/xsl:if> void draw&lt;xsl:value-of select="$pds-name" />()
        {
            this.log("PRINTING &lt;xsl:value-of select="$pds-name" />!");
            var turtle = new Turtle(log);

            &lt;xsl:for-each select="//PredefinedScriptStep[normalize-space(PredefinedScript) = $pds-name]">&lt;xsl:if test="normalize-space(Description) != ''">
            // &lt;xsl:value-of select="Description" />&lt;/xsl:if>&lt;xsl:text>
            turtle.&lt;/xsl:text>&lt;xsl:value-of select="Command" />(&lt;xsl:if test="ArgumentType = 'Color'">PenColor.&lt;/xsl:if>&lt;xsl:value-of select="Argument" />);&lt;/xsl:for-each>
        }&lt;/xsl:for-each>
    }
}


    

&lt;/xsl:element>
                &lt;/FileSetFile>
                   &lt;FileSetFile>
                    &lt;RelativePath>
                        &lt;xsl:text>../../<xsl:value-of select="WayNumber" /><xsl:value-of select="Name"  />.cs&lt;/xsl:text>
                    &lt;/RelativePath>
                    &lt;OvewriteMode>Never&lt;/OvewriteMode>
                    &lt;xsl:element name="FileContents" xml:space="preserve">/* ======================================
<xsl:value-of select="MainFileName"/>

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

<xsl:value-of select="DisplayWayNumber"/>: <xsl:value-of select="Description" />

<xsl:value-of select="Notes" />
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
    // <xsl:value-of select="DisplayWayNumber"/> Class
    // ======================================
    public class <xsl:value-of select="Name"  /> : <xsl:value-of select="WayNumber" /><xsl:value-of select="Name"  />Base
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
            for (var i = 0; i &amp;lt; n; i++)
                this.drawOneSide(turtle, (float)angleDegrees);
        }

    }
}
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
