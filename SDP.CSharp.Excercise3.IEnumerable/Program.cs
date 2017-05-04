using SDP.CSharp.Excercise3.IEnumerable.Model;
using System;
using System.Collections.Generic;

namespace SDP.CSharp.Excercise3.IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = CreateStudents();

            // --------------------------------------------------------------------------

            Console.WriteLine("Iterate over students with for loop:");
            Console.WriteLine();

            // classic collection iteration
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine("Name: {0}, Age: {1}, IQ: {2}", students[i].Name, students[i].Age, students[i].Iq);
            }

            Console.WriteLine();
            Console.WriteLine();

            // --------------------------------------------------------------------------

            Console.WriteLine("Iterate over students using foreach loop:");
            Console.WriteLine();

            // fore each s in the collection of students (IEnumerable loop)
            foreach (var s in students)
            {
                // output "s" information to console
                Console.WriteLine("Name: {0}, Age: {1}, IQ: {2}", s.Name, s.Age, s.Iq);
            }

            Console.WriteLine();
            Console.WriteLine();

            // --------------------------------------------------------------------------

            Console.WriteLine("Sort students and iterate over sorted students using foreach loop:");
            Console.WriteLine();

            // use built-in Sort method on List<T> which will use IComparable<T> implementation from Student class
            students.Sort();

            // fore each s in the collection of students (IEnumerable loop)
            foreach (var s in students)
            {
                // output "s" information to console
                Console.WriteLine("Name: {0}, Age: {1}, IQ: {2}", s.Name, s.Age, s.Iq);
            }

            Console.WriteLine();
            Console.WriteLine();

            // --------------------------------------------------------------------------

            Console.WriteLine("Iterate over sorted students using while loop and enumerator \"manually\":");
            Console.WriteLine();

            var enumarator = students.GetEnumerator();

            // proceed to next item until enumerator is completed
            while (enumarator.MoveNext())
            {
                // acquire current item
                var s = enumarator.Current;

                // output "s" information to console
                Console.WriteLine("Name: {0}, Age: {1}, IQ: {2}", s.Name, s.Age, s.Iq);
            }

            Console.WriteLine();
            Console.WriteLine();

            // --------------------------------------------------------------------------

            try
            {
                // create custom students collection class instance
                var collection = new StudentsCollection(students);

                Console.WriteLine("Iterate over custom collection of students using custom iterator:");
                Console.WriteLine();

                // fore each item in the collection of students
                foreach (var item in collection)
                {
                    // output "item" information to console
                    Console.WriteLine("Name: {0}, Age: {1}, IQ: {2}", item.Name, item.Age, item.Iq);
                }
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Iterating over StudensCollection is not supported yet.");
            }

            Console.ReadLine();
        }

        private static List<Student> CreateStudents()
        {
            // create built-in CLR List<T> collection instance
            var students = new List<Student>
            { // collection initialization syntax
                new Student { Name = "Brajan Kowalski", Age = 21, Iq = 130 },
                new Student { Name = "Dżesika Nowak", Age = 22, Iq = 130 },
                new Student { Name = "Xavier Duda", Age = 23, Iq = 105 }
            };

            // add another student to the collection
            students.Add(new Student
            { // object initialization syntax
                Name = "Grażyna Jawowska",
                Age = 19,
                Iq = 125
            });

            // create single student instance with standard constructor
            var student = new Student();

            // assign information using standard property accessors
            student.Name = "Roman Dotnetowski";
            student.Age = 24;
            student.Iq = 75;

            // add to the collection
            students.Add(student);
            return students;
        }
    }
}
