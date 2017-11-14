using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLib1.BaseClasses
{
    public abstract class TurtleBase
    {
        public void log(String format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public abstract void drawTriangle();
        public abstract void drawThreeLines();
        public abstract void drawPolygon(int sides);

        public static T RunTests<T>()
            where T : TurtleBase, new()
        {
            var ooTurtle = new T();
            ooTurtle.drawTriangle();
            ooTurtle.drawThreeLines();
            ooTurtle.drawPolygon(5);
            return ooTurtle;
        }
    }
}
