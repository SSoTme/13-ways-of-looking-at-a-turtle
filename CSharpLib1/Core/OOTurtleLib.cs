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

    public class TurtleEventArgs : EventArgs
    {
        public TurtleEventArgs(Turtle turtle, float distance = 0, float angle = 0)
        {
            this.Turtle = turtle;
            this.Distance = distance;
            this.Angle = angle;
        }
        public TurtleEventArgs(Turtle turtle, PointF origin, float distance = 0, float angle = 0)
            : this(turtle, distance, angle)
        {
            this.Origin = origin;
        }

        public Turtle Turtle { get; private set; }
        public float Distance { get; }
        public float Angle { get; }
        public PenColor PrevColor { get; set; }
        public PointF Origin { get; set; }
    }

    public static event EventHandler<TurtleEventArgs> TrackMove;
    public static void FireMove(Turtle turtle, PointF origin)
    {
        if (!ReferenceEquals(TrackMove, null)) TrackMove(turtle, new TurtleEventArgs(turtle, origin));
    }

    public static event EventHandler<TurtleEventArgs> TrackTurn;
    public static void FireTurn(Turtle turtle, float angle)
    {
        if (!ReferenceEquals(TrackTurn, null)) TrackTurn(turtle, new TurtleEventArgs(turtle, angle: angle));
    }

    public static event EventHandler<TurtleEventArgs> TrackPenUp;
    public static void FireTrackPenUp(Turtle turtle)
    {
        if (!ReferenceEquals(TrackPenUp, null)) TrackPenUp(turtle, new TurtleEventArgs(turtle));
    }

    public static event EventHandler<TurtleEventArgs> TrackPenDown;
    public static void FireTrackPenDown(Turtle turtle)
    {
        if (!ReferenceEquals(TrackPenDown, null)) TrackPenDown(turtle, new TurtleEventArgs(turtle));
    }

    public static event EventHandler<TurtleEventArgs> TrackSetColor;
    public static void FireTrackSetColor(Turtle turtle, PenColor prevColor)
    {
        if (!ReferenceEquals(TrackSetColor, null)) TrackSetColor(turtle, new TurtleEventArgs(turtle)
        {
            PrevColor = prevColor
        });
    }



    public Turtle(log log)
    {
        this.log = log;
    }

    public void Move(float distance)
    {
        log("Move {0:#.#}", distance);
        // calculate new position 
        var prevPosition = currentPosition;
        var newPosition = currentPosition.calcNewPosition(currentAngle, distance);
        // draw line if needed
        if (currentPenState == PenState.Down)
        {
            // update the state
            currentPosition = newPosition;
            dummyDrawLine(log, prevPosition, newPosition, currentColor);
            FireMove(this, prevPosition);
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

    internal void DrawLine(float distance)
    {
        throw new NotImplementedException();
    }

    internal void DrawCircle(float radius)
    {
        throw new NotImplementedException();
    }

    internal void TurnSide(int sides)
    {
        throw new NotImplementedException();
    }

    internal void Repeat(int repeat)
    {
        throw new NotImplementedException();
    }

    public void SetColor(PenColor color)
    {
        log("SetColor {0}", color);
        currentColor = color;
    }

    internal void Exec(string command)
    {
        throw new NotImplementedException();
    }
}
