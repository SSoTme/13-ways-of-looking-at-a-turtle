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
                        <xsl:text>Index.html</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve"><html>
    <head>
        <title>One way of Looking at 13 Ways of Looking At A Turtle</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous" />
    </head>
    <body style="padding: 1em; font-size: 0.9em;">
        <h1>One Way of Looking at</h1>
        <h2>13 ways of looking at a turtle</h2>
        <div>
            <p>
                This fork of <a href="https://github.com/swlaschin/13-ways-of-looking-at-a-turtle">13 Ways of looking at a Turtl</a>.  This
                Fantastic <a href="http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/">Article/Blog Post</a>
                inspired me to use it has the basis for demonstrating the power of having a
                Single Source of Truth (SSoT) when developing software.
            </p>
            <p>The code can be found on <a href="https://github.com/eejai42/13-ways-of-looking-at-a-turtle">GitHub</a>.</p>

            <p>
                The purpose of the original article, was to demonstrate 13 different ways
                to solve the same problem.  The reason this is such a great starting
                place to domonstrate the SSoT toolset, is that "the code" is what it is.
                In other words, the decision of what the code should be is already decided.
            </p>
            <p>
                The question asked by this fork of the repo is, what would be the best way to 
                Create/Manage that code in a "production" environment.
            </p>
            <p>
                The code in this branch have been created by following the following steps
                in an iterative fashion.  To begin with, I created an empty Single Source
                of Truth (<b>SSoT</b>) in the form of a <a href="https://docs.google.com/spreadsheets/d/1kjyb0JGswSufELAKuy5jtuhs6I0ZyvY9Zwa5Nei6aAo/edit#gid=1093073527" target="_13wgsheet">Google Spreadsheet</a>. 
                This SSoT serves as the place to put decisions.  Specifically, things that
                are true independantly of which language or context/environment that it's used.
            </p>
            <ol>
                <li>Copy information from the code into the <a href="https://docs.google.com/spreadsheets/d/1kjyb0JGswSufELAKuy5jtuhs6I0ZyvY9Zwa5Nei6aAo/edit#gid=1093073527" target="_13wgsheet">SSoT Google Spreadsheet</a></li>
                <li>Prototype a change in the code, which isolates the parts dealing with the new SSoT</li>
                <li>Create a tool (or use an existing tool) which can write that kind of code (for the full set).</li>
                <li>Update the "hand code" to call the "derived" version fo the code</li>
                <li>Delete the hand code version</li>
                <li>Rinse and Repeat</li>
            </ol>
            <p></p>
            <div>
            <p>
                Included next are examples of the kind of information which is usually embeeded in
                "source code" directly, but which are much better described outside of the code.
                Databases and Spreadsheets work well for SSoT - but there are many options for
                gathering SSoT data from. 
            </p>
            </div>
            <p>
                The kinds of data that were moved over to the SSoT are:
            </p>
            <ul>
                <li>First and foremost - the list of "ways" of looking at a turtle</li>
                <li>Valid Turtle Commands (like move/turn/...)</li>
                <li>Common Shapes (like Triangle and ThreeLines)</li>
                <li>The specific commands for those shapes</li>
                <li>See the <a href="https://docs.google.com/spreadsheets/d/1kjyb0JGswSufELAKuy5jtuhs6I0ZyvY9Zwa5Nei6aAo/edit#gid=1093073527" target="_13wgsheet">SSoT Google Spreadsheet</a> for more</li>
            </ul>
            <h3>Commands</h3>
            <p>
                The "basic" Turtle is able to perform these commands.
            </p>
            <ul>
                <xsl:for-each select="//TurtleCommand[Version = 1]">
                <b><xsl:value-of select="Name"/></b><br />
                <div style="font-size: 0.8em;"><xsl:value-of select="Description"/></div>
                </xsl:for-each>
            </ul>

            <p>
                Some of the tools developed after the first 13 ways, include the following 
                additional commands.
            </p>
            <ul>
                <xsl:for-each select="//TurtleCommand[Version > 1]">
                <b><xsl:value-of select="Name"/></b><br />
                <div style="font-size: 0.8em;"><xsl:value-of select="Description"/></div>
                </xsl:for-each>
            </ul>

            <h3>Predefined Scripts</h3>
            <p>
                The original article uses these simple commands to demonstrate 13 ways
                of looking at a turtlle.  In each example, he demonstrates the approach by
                drawing:
            </p>
            <ol>
                <li>A Triangle</li>
                <li>Three Lines</li>
                <li>A Polygon</li>
            </ol>
            <p></p>
            <div>

            <p>
                In Designing the single source of truth for this project, I call the first
                two examples "PredefinedScript".  This is a script which only uses the basic
                Turtle Commands to complete a certain sequence of steps (a "PredefinedScriptStep").
            </p>
            </div>
            <p>
                At this point in time, the SSoT for this project includes <xsl:value-of select="count(//PredefinedScripts/PredefinedScript)"/> Predefined
                Scripts.  They are:
            </p>
            <ul>
                <xsl:for-each select="//PredefinedScripts/PredefinedScript">
                <li>
                    <h5>Drawing a <xsl:value-of select="Name"/></h5>
                    <ol>
                        <xsl:for-each select="//PredefinedScriptStep[PredefinedScript = current()/Name]">
                            <li><b><xsl:value-of select="Command" /></b> <xsl:value-of select="Argument" /></li>
                        </xsl:for-each>
                    </ol>
                </li>
                </xsl:for-each>
           </ul>
           <h3>The Ways</h3>
            <p>
                The purpose of this code is demonstrate different ways to solve the same problem. 
                Variations on a theme.  These <xsl:value-of select="count(//WayOfLookingAtATurtle)" /> are listed below.
            </p>
            <xsl:for-each select="//WayOfLookingAtATurtle">
                <div style="font-size: 0.8em; margin-top: 1em;">
                    <h5><xsl:value-of select="DisplayWayNumber"/> - <xsl:value-of select="Name"/></h5>
                    <div style="whitespace: pre-wrap">
                        <xsl:value-of select="Description"/>
                    </div>
                </div>
            </xsl:for-each>
        </div>
    </body>
</html>
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
