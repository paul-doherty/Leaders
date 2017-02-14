using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Leaders.Common
{
    /// <summary>
    /// Custom file validator to check for presence of file returning a true if 
    /// present and false otherwise
    /// </summary>
    [ValueConversion(typeof(string), typeof(bool))]
    class ValidPathConverter : IValueConverter
    {
        /// <summary>
        /// Convert the input in this case the file path into a boolean
        /// This boolean is used to control enabling/disabling of the Go button
        /// </summary>
        /// <param name="value">The file path</param>
        /// <param name="targetType">The desired type</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = false;
            if (value.GetType() == typeof(String))
            {
                result = Utilities.ValidateFile(value as String);
            }
            return result;
        }

        /// <summary>
        /// Perform the opposite conversion. This is unused in this case
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw null;
        }
    }
}
