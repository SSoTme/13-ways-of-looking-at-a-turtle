/* ======================================
OOTurtleLib.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Common code for OO-style mutable turtle class

====================================== */

// requires Common.fsx to be loaded by parent file
// Uncomment to use this file standalone
// #load "Common.fsx"

using System;
using System.Drawing;
using static CommonExtensions;


// ======================================
// Turtle class
// ======================================

// inject a logging function
public class Turtle
{

    public PointF currentPosition = initialPosition;
    public float currentAngle = 0;
    public PenColor currentColor = initialColor;
    public PenState currentPenState = initialPenState;
    private log log;

    public Turtle(log log)
    {
        this.log = log;
    }

    public void Move(float distance)
    {
        log("Move {0:#.#}", distance);
        // calculate new position 
        var newPosition = currentPosition.calcNewPosition(currentAngle, distance);
        // draw line if needed
        if (currentPenState == PenState.Down)
        {
            dummyDrawLine(log, currentPosition, newPosition, currentColor);

            // update the state
            currentPosition = newPosition;
        }
    }

    public void Turn(float angle)
    {
        this.log("Turn {0}", angle);
        // calculate new angle
        var newAngle = (this.currentAngle + angle) % 360;
        // update the state
        this.currentAngle = newAngle;
    }

    public void PenUp()
    {
        log("Pen up");
        currentPenState = PenState.Up;
    }

    public void PenDown()
    {
        log("Pen down");
        currentPenState = PenState.Down;
    }

    internal virtual void DrawPolygon(int sides)
    {
        throw new NotImplementedException();
    }

    internal void DrawCircle(float radius)
    {
        throw new NotImplementedException();
    }

    public void SetColor(PenColor color)
    {
        log("SetColor {0}", color);
        currentColor = color;
    }
}
