using CSharpLib1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var turtle = OOTurtle.RunTests<OOTurtle>();
            //turtle.drawBox();

            //var fpTurtle = FPTurtle.RunTests<FPTurtle>();
            //fpTurtle.drawBox();


            var apiTurtle = Api_OO_Core.RunTests<Api_OO_Core>();
            apiTurtle.drawBox();

            Console.ReadKey();
        }
    }
}
