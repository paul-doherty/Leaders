using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaders.Common
{
    /// <summary>
    /// Helper class to contain all constant strings
    /// </summary>
    internal static class Constants
    {
        #region File dialog

        internal const String INPUT_EXTENSION = ".in";
        internal const String INPUT_NOT_FOUND = "Failed to find the specified input file";

        #endregion

        #region Methods dropdown

        internal const String DESIGN_METHOD_A = "Method A";
        internal const String DESIGN_METHOD_B = "Method B";

        internal const String METHOD_SORTING = "Sorting";
        internal const String METHOD_HASHING = "Hashing";
        internal const String METHOD_BIT_ARRAY = "Bit Array";

        internal const String ERROR_UNKNOWN_METHOD = "An unknown method was selected";

        #endregion

        #region Results

        internal const String METHOD_LEADER_DATA = "LeaderData";
        internal const String DESIGN_RESULT_A = "Case #1: ABC";
        internal const String DESIGN_RESULT_B = "Case #2: DEF";
        internal const String DESIGN_RESULT_C = "Case #3: GHI";
        internal const String RUNTIME_RESULT = "Case #{0}: {1}";

        #endregion

        #region Duration

        internal const String METHOD_STOPWATCH_DURATION = "StopwatchDuration";
        internal const String DESIGN_DURATION = "0 ms";
        internal const String DURATION_UNIT = " ms";

        #endregion

        #region Miscellaneous

        internal const char SPACE_CHAR = ' ';
        internal const char Z_CHAR = 'Z';
        internal const char A_CHAR = 'A';

        #endregion
    }
}
