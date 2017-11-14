/*
Common.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/

*/

using System;
using System.Drawing;


// ======================================
// Common types and helper functions
// ======================================

/// Enumeration of available pen states
public enum PenState { Down, Up }

/// Enumeration of available pen colors
public enum PenColor { Black, Red, Blue }

public static class CommonExtensions
{

    // ======================================
    // Common helper functions
    // ======================================

    // round a float to two places to make it easier to read
    public static double round2(double flt)
    {
        return Math.Round(flt, 2);
    }

    /// calculate a new position from the current position given an angle and a distance
    public static PointF calcNewPosition(this PointF currentPos, double angle, double distance)
    {
        // Convert degrees to radians with 180.0 degrees = 1 pi radian
        var angleInRads = angle * (Math.PI / 180.0);
        // new pos
        var x1 = (float)(currentPos.X + (distance * Math.Cos(angleInRads)));
        var y1 = (float)(currentPos.Y + (distance * Math.Sin(angleInRads)));
        // return a new Position
        return new PointF(x1, y1);
    }

    public static PointF initialPosition { get; set; }
    public static PenColor initialColor { get; set; }
    public static PenState initialPenState { get; set; }
    public delegate void log(String format, params object[] args);

    /// Emulating a real implementation for drawing a line
    public static void dummyDrawLine(log logMethod, PointF oldPos, PointF newPos, PenColor color)
    {
        // for now just log it
        logMethod("...Draw line from ({0:#.##},{1:#.##}) to ({2:#.##},{3:#.##}) using {4}",
                oldPos.X, oldPos.Y, newPos.X, newPos.Y, color);
    }
}



