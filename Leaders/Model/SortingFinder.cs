using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leaders.Model
{
    /// <summary>
    /// Use LINQ to sort the string and remove duplicates.
    /// </summary>
    class SortingFinder : ResultFinder
    {
        public SortingFinder(String filePath) : base(filePath)
        {
        }

        /// <summary>
        /// Remove duplicates and spaces
        /// If distinct was not present sorting the string would be useful as duplicate 
        /// characters would be next to each other
        /// </summary>
        /// <returns>The winner from every country as and when they are discovered</returns>
        public override IEnumerable<String> GetWinner()
        {
            foreach (List<String> population in this.GetTest())
            {
                ResetLeader();
                foreach (String citizen in population)
                {
                    //optimization, only citizens starting out with more 
                    //characters can end up with more characters
                    if (citizen.Length > LeaderLength) 
                    {
                        //Find the unique characters in the string and sort so whitespace chars are pushed outside
                        String uniqueCharacters = String.Concat(citizen.Distinct().OrderBy(c => c));
                        //Trim whitespace characters
                        uniqueCharacters = uniqueCharacters.Trim();
                        UpdateLeader(citizen, uniqueCharacters);
                    }
                }
                yield return Leader;
            }
        }
    }
}
