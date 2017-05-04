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

        public class ReverseSort : IEnumerable<Student>
        {
            private List<Student> studentsList;
            public ReverseSort(List<Student> students)
            {
                this.studentsList = students;
            }

            public IEnumerator<Student> GetEnumerator()
            {
                for (int i = studentsList.Count; i > 0; i--)
                {
                    yield return studentsList[i - 1];
                }
                throw new NotImplementedException();
            }

            IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

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

            /* MOJE ROZWIĄZANIE
             
           
            List<Student> list = new List<Student>();

            foreach (var s in mStudenty)
            {
                list.Add(s);
            }

            return list.GetEnumerator();
            
             
             */

            // TODO: excercise 2
            // TODO: Method 2: implement your own enumerator using "yield return"

            /* MOJE ROZWIĄZANIE
            
            
            foreach (var s in mStudenty)
            {
                yield return s;
            }
            
             
             */

            // TODO: excercise 3
            // TODO: Method 3: implement your own enumerator class with simple for loop inside and return instances in reverse order

            /* MOJE ROZWIĄZANIE */
            ReverseSort reverseSort = new ReverseSort(mStudenty);
            return reverseSort.GetEnumerator();

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
