/* ======================================
03-Api_OO_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 04: API (OO/FP hybrid approach) -- OO API calling stateless functions

In this design, an API layer communicates with pure turtle functions
and the client talks to the API layer.

The API layer manages the state (rather than the client) by storing a mutable turtle state.

*This approach has been named \
====================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLib1.BaseClasses;

namespace CSharpLib1
{
    // ======================================
    // Way 04 Class
    // ======================================
    public class Api_FP_Core : W04Api_FP_CoreBase
    {
        // define a function that draws one side
        private void drawOneSide(FPApiTurtle turtle, float angleDegrees)
        {
            turtle.Exec("Move 100");
            turtle.Exec(String.Format("Turn {0}", angleDegrees));
        }

        public override void drawPolygon(int sides)
        {
            Console.WriteLine("DRAWING POLYGON: {0}", sides);
            var angle = 180.0 - (360.0 / (float)sides);
            var angleDegrees = angle * 1.0f;
            var turtle = new FPApiTurtle(log);


            // repeat for all sides
            for (var i = 0; i < sides; i++)
                this.drawOneSide(turtle, (float)angleDegrees);
        }

    }

    public class FPApiTurtle : ApiTurtleBase
    {
        public FPApiTurtle(Action<string, object[]> log) : base(log)
        {
        }

        internal override void Exec(string command)
        {
            Console.WriteLine("FP EXECUTING: {0}", command);
        }
    }
}
