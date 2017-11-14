/* ======================================
02-FPTurtle.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 02: Simple FP - a module of functions with immutable state

In this design, the turtle state is immutable. A module contains functions that return a new turtle state,
and the client uses these turtle functions directly.

The client must keep track of the current state and pass it into the next function call.
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommonExtensions;

namespace CSharpLib1.BaseClasses
{
    public static class TurtleExtensions {
        public static Turtle CreateTurtle(log log) {
            return new Turtle(log);
        }

        
        public static Turtle DoMove(this Turtle turtle, float Distance) {
            turtle.Move(Distance);
            return turtle;
        }
        
        public static Turtle DoTurn(this Turtle turtle, float Degrees) {
            turtle.Turn(Degrees);
            return turtle;
        }
        
        public static Turtle DoPenUp(this Turtle turtle) {
            turtle.PenUp();
            return turtle;
        }
        
        public static Turtle DoPenDown(this Turtle turtle) {
            turtle.PenDown();
            return turtle;
        }
        
        public static Turtle DoSetColor(this Turtle turtle, PenColor Color) {
            turtle.SetColor(Color);
            return turtle;
        }
        
        public static Turtle DoDrawPolygon(this Turtle turtle, int Sides) {
            turtle.DrawPolygon(Sides);
            return turtle;
        }
        
        public static Turtle DoDrawLine(this Turtle turtle, float Distance) {
            turtle.DrawLine(Distance);
            return turtle;
        }
        
        public static Turtle DoTurnSide(this Turtle turtle, int Sides) {
            turtle.TurnSide(Sides);
            return turtle;
        }
        
        public static Turtle DoRepeat(this Turtle turtle, int Repeat) {
            turtle.Repeat(Repeat);
            return turtle;
        }
        
        public static Turtle DoExec(this Turtle turtle, string Command) {
            turtle.Exec(Command);
            return turtle;
        }
        
    }

    // ======================================
    // Way 02 Helper Classes
    // ======================================
    public abstract class W02FPTurtleBase : TurtleBase
    {
        
        
        public override void drawTriangle()
        {
            this.log("PRINTING Triangle!");
            TurtleExtensions.CreateTurtle(log)
                .DoMove(275)
                .DoTurn(120)
                .DoMove(275)
                .DoTurn(120)
                .DoMove(275)
                .DoTurn(120);
        }
        
        public override void drawThreeLines()
        {
            this.log("PRINTING ThreeLines!");
            TurtleExtensions.CreateTurtle(log)
                // Draw black line
                .DoPenDown()
                .DoSetColor(PenColor.Black)
                .DoMove(100)
                // Move without Drawing
                .DoPenUp()
                .DoTurn(90)
                .DoMove(100)
                .DoTurn(90)
                // Draw red line
                .DoPenDown()
                .DoSetColor(PenColor.Red)
                .DoMove(100)
                // Move without Drawing
                .DoPenUp()
                .DoTurn(90)
                .DoMove(100)
                .DoTurn(90)
                // Back home at (0,0) with angle 0, Draw diagonal blue line
                .DoPenDown()
                .DoSetColor(PenColor.Blue)
                .DoTurn(45)
                .DoMove(100);
        }
        
        public void drawBox()
        {
            this.log("PRINTING Box!");
            TurtleExtensions.CreateTurtle(log)
                .DoMove(100)
                .DoTurn(90)
                .DoMove(100)
                .DoTurn(90)
                .DoMove(100)
                .DoTurn(90)
                .DoMove(100)
                .DoTurn(90);
        }
    }
}


    

