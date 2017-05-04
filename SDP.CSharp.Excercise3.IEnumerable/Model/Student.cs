using System;

namespace SDP.CSharp.Excercise3.IEnumerable.Model
{
    /// <summary>
    /// Represents a single Student
    /// </summary>
    class Student : Person, IComparable<Student>
    {
        /// <summary>
        /// Gets or sets an IQ of a student
        /// </summary>
        public int Iq
        {
            get;
            set;
        }

        /// <summary>
        /// Compares this student instance to instance provided as parameter
        /// </summary>
        /// <param name="other">other student instance to compare this student to</param>
        /// <returns>positive number if this student is "greater" than the other, negative if other student is "greater" than this one, and 0 if they are "equal"</returns>
        public int CompareTo(Student other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            return Iq - other.Iq;
        }
    }
}
