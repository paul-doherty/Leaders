using System;
using Leaders.Model;
using Leaders.Common;
using System.Collections.Generic;
using System.ComponentModel;

namespace Leaders.Design
{
    /// <summary>
    /// Design service used during design/layout mode
    /// </summary>
    public class DesignDataService : IDataService
    {
        /// <summary>
        /// Event handler used when a property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Property used to contain leader data
        /// </summary>
        public ICollection<String> LeaderData { get; private set; }

        /// <summary>
        /// The duration taken to process the input file
        /// </summary>
        public String StopwatchDuration { get; private set; }

        public DesignDataService()
        {
            LeaderData = new List<String> 
            { 
                Constants.DESIGN_RESULT_A, 
                Constants.DESIGN_RESULT_B,
                Constants.DESIGN_RESULT_C
            };
            StopwatchDuration = Constants.DESIGN_DURATION;
        }
        
        /// <summary>
        /// Add sample method data
        /// </summary>
        /// <returns>Sample method data</returns>
        public List<String> GetMethods()
        {
            List<String> items = new List<String> 
            { 
                Constants.DESIGN_METHOD_A, 
                Constants.DESIGN_METHOD_B 
            };
            return items;
        }

        /// <summary>
        /// Add sample result data
        /// </summary>
        /// <param name="selectedMethod">The method selected</param>
        /// <param name="filePath">The path to the inout file</param>
        public void GetResultsAsync(String selectedMethod, String filePath)
        {
            PropertyChangedEventArgs args = new PropertyChangedEventArgs(Constants.METHOD_LEADER_DATA);
            PropertyChanged(this, args);
        }
    }
}