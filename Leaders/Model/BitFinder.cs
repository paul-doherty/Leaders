using Leaders.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leaders.Model
{
    /// <summary>
    /// Create an array of bits to cover the alphabet. 
    /// Every character we process we set the appropriate bit to 1
    /// Count how many bits are one to find unique characters
    /// </summary>
    class BitFinder : ResultFinder
    {
        public BitFinder(String filePath) : base(filePath)
        {
        }

        /// <summary>
        /// Create a bit array and store character presence in it 
        /// count set bits
        /// </summary>
        /// <returns>The winner from every country as and when they are discovered</returns>
        public override IEnumerable<string> GetWinner()
        {
            foreach (List<String> population in this.GetTest())
            {
                ResetLeader();
                int size = Constants.Z_CHAR - Constants.A_CHAR + 1;
                foreach (String citizen in population)
                {
                    //optimization, only citizens starting out with more 
                    //characters can end up with more characters
                    if (citizen.Length > LeaderLength)
                    {
                        BitArray citizenBits = new BitArray(size);
                        foreach (char character in citizen.ToCharArray())
                        {
                            if (character != Constants.SPACE_CHAR)
                            {
                                int position = character - Constants.A_CHAR;
                                citizenBits.Set(position, true);
                            }
                        }
                        String uniqueCharacters = GetUniqueString(citizenBits);
                        UpdateLeader(citizen, uniqueCharacters);
                    }
                }
                yield return Leader;
            }
        }

        /// <summary>
        /// Recreate the unique string
        /// </summary>
        /// <param name="citizenBits">The bit array for this citizen</param>
        /// <returns>The unique characters in the name</returns>
        private String GetUniqueString(BitArray citizenBits)
        {
            StringBuilder uniqueCharacters = new StringBuilder();
            char currentLetter = Constants.A_CHAR;
            while(currentLetter <= Constants.Z_CHAR)
            {
                if (citizenBits.Get(currentLetter - Constants.A_CHAR))
                {
                    uniqueCharacters.Append(currentLetter);
                }
                currentLetter++;
            }
            return uniqueCharacters.ToString();
        }
    }
}
