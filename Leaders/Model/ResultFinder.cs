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
        private StreamReader InputReader { get; set; }
        public int NumberOfTotalTestCases { get; set; }
        public int NumberOfCurrentTestCase { get; set; }
        public int PopulationOfCurrentTestCase { get; set; }

        protected String Leader { get; set; }
        protected int LeaderLength { get; set; }

        public ResultFinder(String filePath)
        {
            Leader = String.Empty;
            LeaderLength = 0;
            InputReader = null;
            LoadInputFile(filePath);
        }

        /// <summary>
        /// Read the next line from the input file
        /// </summary>
        /// <returns>The next line</returns>
        public IEnumerable<List<String>> GetTest()
        {
            while (NumberOfCurrentTestCase < NumberOfTotalTestCases)
            {
                NumberOfCurrentTestCase++;
                String line = InputReader.ReadLine();
                Console.WriteLine(NumberOfCurrentTestCase+ " of " + NumberOfTotalTestCases + " " + line);
                PopulationOfCurrentTestCase = Int32.Parse(line);
                List<String> population = new List<string>(PopulationOfCurrentTestCase);
                for (int index = 0; index < PopulationOfCurrentTestCase; index++)
                {
                    population.Add(InputReader.ReadLine());
                }
                yield return population;
            }
        }

        abstract public IEnumerable<String> GetWinner();

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

        protected void ResetLeader()
        {
            Leader = String.Empty;
            LeaderLength = 0;
        }
    }
}
