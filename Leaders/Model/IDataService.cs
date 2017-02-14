using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Leaders.Model
{
    /// <summary>
    /// The data service interface
    /// </summary>
    public interface IDataService : INotifyPropertyChanged
    {
        /// <summary>
        /// This property contains all result data from the processing 
        /// of the file
        /// </summary>
        ICollection<String> LeaderData { get; }

        /// <summary>
        /// The duration taken to process the input file
        /// </summary>
        String StopwatchDuration { get; }

        /// <summary>
        /// The method available to process the file at runtime are set
        /// here
        /// </summary>
        /// <returns>The available methods</returns>
        List<String> GetMethods();

        /// <summary>
        /// Start the thread to process the input file results
        /// </summary>
        /// <param name="selectedMethod">The method the user selected</param>
        /// <param name="filePath">The path to the input file</param>
        void GetResultsAsync(String selectedMethod, String filePath);
    }
}
