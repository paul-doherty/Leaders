using Leaders.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Leaders
{
    /// <summary>
    /// An abstract class for result finders
    /// </summary>
    abstract class ResultFinder
    {
        /// <summary>
        /// Input file stream
        /// </summary>
        private StreamReader InputReader { get; set; }

        /// <summary>
        /// The total number of test cases
        /// </summary>
        public int NumberOfTotalTestCases { get; set; }

        /// <summary>
        /// The number of the current test case we are on
        /// </summary>
        public int NumberOfCurrentTestCase { get; set; }

        /// <summary>
        /// The population of this test case
        /// </summary>
        public int PopulationOfCurrentTestCase { get; set; }

        /// <summary>
        /// The leader of the country for the current test case
        /// </summary>
        protected String Leader { get; set; }

        /// <summary>
        /// THe unique length of the leader of the current country
        /// </summary>
        protected int LeaderLength { get; set; }

        /// <summary>
        /// Find the winners of the test cases
        /// </summary>
        /// <returns></returns>
        abstract public IEnumerable<String> GetWinner();

        /// <summary>
        /// Create a new result finder to load the input file
        /// </summary>
        /// <param name="filePath"></param>
        public ResultFinder(String filePath)
        {
            Leader = String.Empty;
            LeaderLength = 0;
            InputReader = null;
            LoadInputFile(filePath);
        }

        /// <summary>
        /// Get the next test case. Yield after every citizen of the country is read
        /// </summary>
        /// <returns>The next line</returns>
        public IEnumerable<List<String>> GetTest()
        {
            while (NumberOfCurrentTestCase < NumberOfTotalTestCases)
            {
                NumberOfCurrentTestCase++;
                String line = InputReader.ReadLine();
                PopulationOfCurrentTestCase = Int32.Parse(line);
                List<String> population = new List<string>(PopulationOfCurrentTestCase);
                for (int index = 0; index < PopulationOfCurrentTestCase; index++)
                {
                    population.Add(InputReader.ReadLine());
                }
                yield return population;
            }
        }

        /// <summary>
        /// Load the input file ready for reading
        /// </summary>
        /// <param name="filePath">The full file path</param>
        private void LoadInputFile(String filePath)
        {
            if (Utilities.ValidateFile(filePath))
            {
                InputReader = new StreamReader(filePath);
                NumberOfTotalTestCases = Int32.Parse(InputReader.ReadLine());
                NumberOfCurrentTestCase = 0;
                PopulationOfCurrentTestCase = 0;
            }
        }

        /// <summary>
        /// Update the leader of the country if the current citizen either contains 
        /// more unique characters or he/she contains the same number of characters 
        /// but comes before the current leader alphabetically
        /// </summary>
        /// <param name="citizen">The potential new leader</param>
        /// <param name="uniqueCharacters">The number of unique characters in that citizens name</param>
        protected void UpdateLeader(String citizen, String uniqueCharacters)
        {
            bool newLeader = false;
            //same number of characters as the current leader but come before in alphabetical order
            if ((uniqueCharacters.Length == LeaderLength) && (citizen.CompareTo(Leader) < 0))
            {
                newLeader = true;
            }
            //contains more characters
            else if (uniqueCharacters.Length > LeaderLength)
            {
                newLeader = true;
            }

            if (newLeader)
            {
                LeaderLength = uniqueCharacters.Length;
                Leader = citizen;
            }
        }

        /// <summary>
        /// Reset the leader attributes
        /// </summary>
        protected void ResetLeader()
        {
            Leader = String.Empty;
            LeaderLength = 0;
        }
    }
}
