using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.CSharp.Excercise4.AnonymousTypesAndLambdas.Model
{
    /// <summary>
    /// Represents a data source providing instances of Person class
    /// </summary>
    class PeopleSource : IEnumerable<Person>
    {
        // internal list of people        
        private IEnumerable<Person> mPeople;

        /// <summary>
        /// Creates new instance of PeopleSource class
        /// </summary>
        public PeopleSource()
        {
            // get CSV file contents from resources
            var csvData = Resources.Resources.SomePeople;
            
            // split file by end of line characters, ommit empty entries
            var rows = csvData.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            // transform each line from CSB file into Person class instance using lambda expression 
            mPeople = rows.Select(o => 
            {
                // split line by "|" character
                var splittedRow = o.Split('|');
                
                int numberOfVowels = 0;

                for (int i = 0; i < splittedRow[0].Length; i++)
                {
                    if (splittedRow[0][i] == 'a' || splittedRow[0][i] == 'e' || splittedRow[0][i] == 'i' || splittedRow[0][i] == 'o' || splittedRow[0][i] == 'u')
                    {
                        numberOfVowels++;
                    }
                }

                // return new instance of Person
                return new Person
                {
                    Name = splittedRow[0],
                    City = splittedRow[1],
                    SignInDate = splittedRow[2],
                    Company = splittedRow[3],
                    NumberOfVowels = numberOfVowels,
                };
            });
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return mPeople.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
