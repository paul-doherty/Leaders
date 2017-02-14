using Leaders.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leaders.Model
{
    /// <summary>
    /// Create a hash table for each character in a string
    /// If the character it already present or it is a space we ignore it
    /// </summary>
    class HashFinder : ResultFinder
    {
        public HashFinder(String filePath) : base(filePath)
        {
        }

        /// <summary>
        /// Add each unique character to a hash. 
        /// Turn keys into string to determine unique characters
        /// </summary>
        /// <returns>The winner from every country as and when they are discovered</returns>
        public override IEnumerable<string> GetWinner()
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
                        Hashtable citizenHash = new Hashtable();
                        foreach (char character in citizen.ToCharArray())
                        {
                            if ((character != Constants.SPACE_CHAR) &&
                                !citizenHash.ContainsKey(character))
                            {
                                citizenHash.Add(character, true);
                            }
                        }
                        String uniqueCharacters = String.Join("", citizenHash.Keys.Cast<char>().ToList());
                        UpdateLeader(citizen, uniqueCharacters);
                    }
                }
                yield return Leader;
            }
        }
    }
}
