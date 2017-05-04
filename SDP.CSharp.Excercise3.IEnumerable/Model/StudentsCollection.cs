using System;
using System.Collections;
using System.Collections.Generic;

namespace SDP.CSharp.Excercise3.IEnumerable.Model
{
    /// <summary>
    /// Represents a collection of Students
    /// </summary>
    class StudentsCollection : IEnumerable<Student>
    {
        // internal list of students
        private List<Student> mStudenty;

        /// <summary>
        /// Creates new instance of StudentsCollection class
        /// </summary>
        /// <param name="source">original students list</param>
        public StudentsCollection(IEnumerable<Student> source)
        {
            mStudenty = new List<Student>(source);
        }

        /// <summary>
        /// Returns generci enumerator for this instance
        /// </summary>
        public IEnumerator<Student> GetEnumerator()
        {
            // TODO: excercise 1
            // TODO: Method 1: use List<T> enumerator

            // TODO: excercise 2
            // TODO: Method 2: implement your own enumerator using "yield return"

            // TODO: excercise 3
            // TODO: Method 3: implement your own enumerator class with simple for loop inside and return instances in reverse order
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns non-generic enumerator for this instance
        /// </summary>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
