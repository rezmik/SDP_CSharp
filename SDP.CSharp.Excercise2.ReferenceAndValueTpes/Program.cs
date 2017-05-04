using SDP.CSharp.Excercise2.ReferenceAndValueTypes.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SDP.CSharp.Excercise2.ReferenceAndValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // test procedure - show types with reflection
            ShowTypesWithReflection();

            Console.WriteLine();

            // test procedure - whow boxing example
            ShowBoxingExample();

            Console.WriteLine();

            // test procedure - show boxing performance comparison
            ShowBoxingPerformanceExample();

            Console.ReadLine();
        }

        /// <summary>
        /// Gets type of Student class using reflection and prints type name and 2 base types of this type name to console
        /// </summary>
        private static void ShowTypesWithReflection()
        {
            // get type of Student using simple reflection
            var type = typeof(Student);

            // type name of Student class
            Console.WriteLine("Type name of \"Student\" class: {0}", type.Name);

            // type name of Person class
            Console.WriteLine("Type name of \"Student\" class' base type: {0}", type.BaseType.Name);

            // type name of Object class
            Console.WriteLine("Type name of \"Student\" class' base type's base type: {0}", type.BaseType.BaseType.Name);

            Console.WriteLine();
        }

        /// <summary>
        /// Addds various types to the same list to ilustrate boxing
        /// then prints all added instances to console with single loop
        /// </summary>
        private static void ShowBoxingExample()
        {
            // non-generic list implementation
            ArrayList list = new ArrayList();

            // adding object
            list.Add(new object());

            // adding reference type string
            list.Add("Some string");

            // adding value type Int32 which is boxed on-the-fly
            list.Add(1);

            // adding value type DateTime which is boxed on-the-fly
            list.Add(DateTime.Now);

            // adding a reference type array of strings
            list.Add(new[] { "String1", "String2" });

            // adding reference type Exception
            list.Add(new Exception("Some exception description"));

            // adding reference type ArrayList itself!
            list.Add(list);

            // Thought experiment: 
            // What will be the result of the following loop?
            // Why is it possible to add different instances and types to the same collection?

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Adds integers to various types of collection using various methods to ilustrate boxing performance
        /// </summary>
        private static void ShowBoxingPerformanceExample()
        {
            const int MAX_ITEMS = 10000000;

            // built-in time measurement helper
            Stopwatch watch = new Stopwatch();

            // --------------------------------------------------------------------------

            // reset and start time
            watch.Reset();
            watch.Start();

            // create array of ints
            int[] intArray = new int[MAX_ITEMS];

            // fill array
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                intArray[i] = i;
            }

            // stop time
            watch.Stop();

            Console.WriteLine("Time used for int[] array creation [ms]: {0}", watch.ElapsedMilliseconds);

            // --------------------------------------------------------------------------

            // reset and start time
            watch.Reset();
            watch.Start();

            // create generic list of ints (using initialization size to reduce memory allocation time)
            List<int> genericIntList = new List<int>(MAX_ITEMS);

            // fill generic list of ints
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                genericIntList.Add(i);
            }

            // stop time
            watch.Stop();

            Console.WriteLine("Time used for generic List<int> creation [ms]: {0}", watch.ElapsedMilliseconds);

            // --------------------------------------------------------------------------

            // reset and start time
            watch.Reset();
            watch.Start();

            // create generic list of objects (using initialization size to reduce memory allocation time)
            List<object> genericObjectList = new List<object>(MAX_ITEMS);

            // fill generic list of ints boxed to objects
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                genericObjectList.Add(i);
            }

            // stop time
            watch.Stop();

            Console.WriteLine("Time used for generic List<object> creation [ms]: {0}", watch.ElapsedMilliseconds);

            // --------------------------------------------------------------------------

            // reset and start time
            watch.Reset();
            watch.Start();

            // create non-generic list (using initialization size to reduce memory allocation time)
            ArrayList nonGenericList = new ArrayList(MAX_ITEMS);

            // fill generic list of ints boxed to objects
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                nonGenericList.Add(i);
            }

            // stop time
            watch.Stop();

            Console.WriteLine("Time used for non generic ArrayList creation [ms]: {0}", watch.ElapsedMilliseconds);
        }
    }
}
