/* ======================================
03-Api_OO_Core.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================

Way 03: API (OO Approach) -- OO API calling stateful core class

In this design, an API layer communicates with a turtle class
and the client talks to the API layer.

The input to the API are strings, and so the API validates the
input and returns a Result containing any errors.
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
    // Way 03 Class
    // ======================================
    public class Api_OO_Core : W03Api_OO_CoreBase
    {
        // define a function that draws one side
        private void drawOneSide(ApiTurtle turtle, float angleDegrees)
        {
            turtle.Exec("Move 100");
            turtle.Exec(String.Format("Turn {0}", angleDegrees));
        }

        public override void drawPolygon(int sides)
        {
            Console.WriteLine("DRAWING POLYGON: {0}", sides);
            var angle = 180.0 - (360.0 / (float)sides);
            var angleDegrees = angle * 1.0f;
            var turtle = new ApiTurtle(log);


            // repeat for all sides
            for (var i = 0; i < sides; i++)
                this.drawOneSide(turtle, (float)angleDegrees);
        }

    }

    public class ApiTurtle : ApiTurtleBase
    {
        public ApiTurtle(Action<string, object[]> log) : base(log)
        {
        }

        internal override void Exec(string command)
        {
            Console.WriteLine("EXECUTING: {0}", command);
        }
    }
}
