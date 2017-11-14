/* ======================================


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

        
        
        public override void drawTriangle()
        {
            this.log("PRINTING Triangle!");

            this.ListenToTurtle();
            var turtle = new Turtle(log);
            
            turtle.Move(100);
            turtle.Turn(120);
            turtle.Move(100);
            turtle.Turn(120);
            turtle.Move(100);
            turtle.Turn(120);

            this.StopListeningToTurtle("Triangle.png");

        }
        
        public override void drawThreeLines()
        {
            this.log("PRINTING ThreeLines!");

            this.ListenToTurtle();
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

            this.StopListeningToTurtle("ThreeLines.png");

        }
        
        public void drawBox()
        {
            this.log("PRINTING Box!");

            this.ListenToTurtle();
            var turtle = new Turtle(log);
            
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);
            turtle.Move(100);
            turtle.Turn(90);

            this.StopListeningToTurtle("Box.png");

        }
    }
}


    

