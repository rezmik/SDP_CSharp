using SDP.CSharp.Excercise1.GarbageCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.CSharp.Excercise1.GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var pointMarshaling = new PointMarshaling())
            {
                // Create a point struct.
                var p1 = new Point
                {
                    x = 1,
                    y = 1
                };

                Console.WriteLine("The value of first point is " + p1.x + " and " + p1.y + ".");

                pointMarshaling.MarshalPoint(p1);
                var p2 = pointMarshaling.UnmarshalPoint();

                Console.WriteLine("The value of new point is " + p2.x + " and " + p2.y + ".");

                // TODO: Excercise 1
                // Are p1 and p2 the same by reference? Why?
                if (Object.ReferenceEquals(p1, p2))
                {
                    Console.WriteLine("p1 and p2 are the same");
                } else
                {
                    Console.WriteLine("p1 and p2 aren't the same");
                }
                // p1 and p2 aren't the same
            }

            /*using (var fileResource = new FileResource())
            {
                fileResource.WriteToFile("Some string");
            }*/

            // TODO: Excercise 2
            // Transform code above in such way that "using" statement is not used but objects are still properly disposed.

            FileResource fileResource = new FileResource();
            fileResource.WriteToFile("SomeString");
            fileResource.Dispose();

            Console.ReadLine();
        }
    }
}
