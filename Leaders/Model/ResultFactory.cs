using Leaders.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaders.Model
{
    /// <summary>
    /// Use the factory pattern to create the correct object
    /// </summary>
    static class ResultFactory
    {
        /// <summary>
        /// Create the appropriate result finder based on the users selection
        /// </summary>
        /// <param name="desiredType">The type of finder required</param>
        /// <param name="filePath">The path to the input file</param>
        /// <returns></returns>
        public static ResultFinder GetResultFinder(String desiredType, String filePath)
        {
            ResultFinder finder = null;
            if(desiredType.CompareTo(Constants.METHOD_SORTING) == 0)
            {
                finder = new SortingFinder(filePath);
            }
            else if (desiredType.CompareTo(Constants.METHOD_HASHING) == 0)
            {
                finder = new HashFinder(filePath);
            }
            else if (desiredType.CompareTo(Constants.METHOD_BIT_ARRAY) == 0)
            {
                finder = new BitFinder(filePath);
            }
            else
            {
                throw new ArgumentException(Constants.ERROR_UNKNOWN_METHOD);
            }
            return finder;
        }
    }
}
