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

namespace CSharpLib1.BaseClasses
{
    // ======================================
    // Way 03 Helper Classes
    // ======================================
    public abstract class W03Api_OO_CoreBase : TurtleBase
    {
        
        
        public override void drawTriangle()
        {
            this.log("PRINTING Triangle!");
            var api = new ApiTurtle(log);

            
            api.Exec("Move 275");
            api.Exec("Turn 120");
            api.Exec("Move 275");
            api.Exec("Turn 120");
            api.Exec("Move 275");
            api.Exec("Turn 120");
        }
        
        public override void drawThreeLines()
        {
            this.log("PRINTING ThreeLines!");
            var api = new ApiTurtle(log);

            
            // Draw black line
            api.Exec("PenDown ");
            api.Exec("SetColor Black");
            api.Exec("Move 100");
            // Move without Drawing
            api.Exec("PenUp ");
            api.Exec("Turn 90");
            api.Exec("Move 100");
            api.Exec("Turn 90");
            // Draw red line
            api.Exec("PenDown ");
            api.Exec("SetColor Red");
            api.Exec("Move 100");
            // Move without Drawing
            api.Exec("PenUp ");
            api.Exec("Turn 90");
            api.Exec("Move 100");
            api.Exec("Turn 90");
            // Back home at (0,0) with angle 0, Draw diagonal blue line
            api.Exec("PenDown ");
            api.Exec("SetColor Blue");
            api.Exec("Turn 45");
            api.Exec("Move 100");
        }
        
        public void drawBox()
        {
            this.log("PRINTING Box!");
            var api = new ApiTurtle(log);

            
            api.Exec("Move 100");
            api.Exec("Turn 90");
            api.Exec("Move 100");
            api.Exec("Turn 90");
            api.Exec("Move 100");
            api.Exec("Turn 90");
            api.Exec("Move 100");
            api.Exec("Turn 90");
        }
    }

    
    public abstract class ApiTurtleBase
    {
        public Action<string, object[]> log;

        public ApiTurtleBase(Action<string, object[]> log)
        {
            this.log = log;
        }

        internal abstract void Exec(string command);
    }
}


    

