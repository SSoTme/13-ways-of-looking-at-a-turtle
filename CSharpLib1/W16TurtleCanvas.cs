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
using CSharpLib1.BaseClasses;
using System.Drawing;
using System.Drawing.Imaging;

namespace CSharpLib1
{
    // ======================================
    // Way 16 Class
    // ======================================
    public class TurtleCanvas : W16TurtleCanvasBase
    {
        public Image Image { get; private set; }
        public PointF LastLocation { get; private set; }
        public PointF CurrentLocation { get; private set; }

        public TurtleCanvas() {
            Turtle.TrackMove += Turtle_TrackMove;
        }

        private void Turtle_TrackMove(object sender, Turtle.TurtleEventArgs e)
        {
            var canvas = Graphics.FromImage(this.Image);
            this.LastLocation = e.Origin;
            this.CurrentLocation = e.Turtle.currentPosition;
            
            var pen = Pens.Black;
            if (e.Turtle.currentColor == PenColor.Black) pen = Pens.Blue;
            else if (e.Turtle.currentColor == PenColor.Red) pen = Pens.Red;

            canvas.DrawLine(pen, this.LastLocation.calcNewPosition(45, 500), this.CurrentLocation.calcNewPosition(45, 500));
        }

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
            for (var i = 0; i < n; i++)
                this.drawOneSide(turtle, (float)angleDegrees);
        }

        protected override void ListenToTurtle()
        {
            this.Image = new Bitmap(1000, 1000);
        }

        protected override void StopListeningToTurtle(string pngFileName)
        {
            this.Image.Save(pngFileName, ImageFormat.Png);
        }
    }
}
