using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Leaders.Common
{
    /// <summary>
    /// Custom file validator to check for presence of file returning a red
    /// brush is missing and a light gray brush if present
    /// </summary>
    [ValueConversion(typeof(string), typeof(bool))]
    class ValidPathHighlighter : IValueConverter
    {
        /// <summary>
        /// Convert the input in this case the file path into a brush
        /// This brush is used to control border color of the file input
        /// </summary>
        /// <param name="value">The file path</param>
        /// <param name="targetType">The desired type</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush result = new SolidColorBrush(Colors.Red);
            if (value.GetType() == typeof(String))
            {
                if(Utilities.ValidateFile(value as String))
                {
                    result = new SolidColorBrush(Colors.LightGray);
                }
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
