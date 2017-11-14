/* ======================================
15-CapabilityBasedTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 15: API with capabilities

In this design, the turtle exposes a list of functions (capabilities) after each action.
These are the ONLY actions available to the client

More on capability-based security at http://fsharpforfunandprofit.com/posts/capability-based-security/
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // Way 15 Helper Classes
    // ======================================
    public abstract class W15CapabilityBasedTurtleBase : TurtleBase
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


    

