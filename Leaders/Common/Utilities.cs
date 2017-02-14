using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaders.Common
{
    /// <summary>
    /// Helper class to contain common ulitities
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Validate the file passed exists
        /// </summary>
        /// <param name="filePath">The full file path</param>
        /// <returns>If the file is valid or not</returns>
        internal static bool ValidateFile(String filePath)
        {
            bool validInputFile = !String.IsNullOrWhiteSpace(filePath);
            if (validInputFile)
            {
                validInputFile = File.Exists(filePath);
            }

            return validInputFile;
        }
    }
}
