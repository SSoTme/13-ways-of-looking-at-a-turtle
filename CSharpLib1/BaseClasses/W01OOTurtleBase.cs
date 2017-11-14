/* ======================================
01-OOTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 01: Simple OO -- a class with mutable state

In this design, a simple OO class represents the turtle,
and the client talks to the turtle directly.
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // Way 01 Helper Classes
    // ======================================
    public abstract class W01OOTurtleBase : TurtleBase
    {
        
        
        public override void drawTriangle()
        {
            this.log("PRINTING Triangle!");
            var turtle = new Turtle(log);

            
            turtle.Move(275);
            turtle.Turn(120);
            turtle.Move(275);
            turtle.Turn(120);
            turtle.Move(275);
            turtle.Turn(120);
        }
        
        public override void drawThreeLines()
        {
            this.log("PRINTING ThreeLines!");
            var turtle = new Turtle(log);

            
            // Draw black line
            turtle.PenDown();
            turtle.SetColor(PenColor.Black);
            turtle.Move(100);
            // Move without Drawing
            turtle.PenUp();
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            // Draw red line
            turtle.PenDown();
            turtle.SetColor(PenColor.Red);
            turtle.Move(100);
            // Move without Drawing
            turtle.PenUp();
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            // Back home at (0,0) with angle 0, Draw diagonal blue line
            turtle.PenDown();
            turtle.SetColor(PenColor.Blue);
            turtle.Turn(45);
            turtle.Move(100);
        }
        
        public void drawBox()
        {
            this.log("PRINTING Box!");
            var turtle = new Turtle(log);

            
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
        }
    }
}


    

