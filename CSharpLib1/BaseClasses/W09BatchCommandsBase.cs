/* ======================================
09-BatchCommands.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 09: Batch oriented -- Using a list of commands

In this design, the client creates a list of `Command`s that will be intepreted later.
These commands are then run in sequence using the Turtle library functions.

This approach means that there is no state that needs to be persisted between calls by the client.
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // Way 09 Helper Classes
    // ======================================
    public abstract class W09BatchCommandsBase : TurtleBase
    {
        
        
        public override void drawTriangle()
        {
            this.log("PRINTING Triangle!");
            var turtle = new Turtle(log);

            
            turtle.Move(100);
            turtle.Turn(120);
            turtle.Move(100);
            turtle.Turn(120);
            turtle.Move(100);
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


    

