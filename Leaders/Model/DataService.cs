using Leaders.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace Leaders.Model
{
    /// <summary>
    /// This the runtime model for the application. It processes the input 
    /// file and makes the results available to the view model when 
    /// requested.
    /// </summary>
    public class DataService : IDataService
    {
        /// <summary>
        /// Event handler used when a property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This property contains all result data from the processing 
        /// of the file
        /// </summary>
        public ICollection<String> LeaderData { get; private set; }

        /// <summary>
        /// The duration taken to process the input file
        /// </summary>
        public String StopwatchDuration { get; private set; }

        /// <summary>
        /// Create the data service
        /// </summary>
        public DataService()
        {
            LeaderData = new List<String>();
            StopwatchDuration = String.Empty;
        }

        /// <summary>
        /// The method available to process the file at runtime are set
        /// here
        /// </summary>
        /// <returns>The available methods</returns>
        public List<String> GetMethods()
        {
            List<String> items = new List<String> 
            { 
                Constants.METHOD_SORTING, 
                Constants.METHOD_HASHING, 
                Constants.METHOD_BIT_ARRAY 
            };
            return items;
        }

        /// <summary>
        /// Start the thread to process the input file results
        /// </summary>
        /// <param name="selectedMethod">The method the user selected</param>
        /// <param name="filePath">The path to the input file</param>
        public void GetResultsAsync(String selectedMethod, String filePath)
        {
            StopwatchDuration = String.Empty;
            PropertyChangedEventArgs stopwatchArgs = new PropertyChangedEventArgs(Constants.METHOD_STOPWATCH_DURATION);
            PropertyChanged(this, stopwatchArgs);

            Task.Run(() => ProcessResults(selectedMethod, filePath));
        }

        /// <summary>
        /// Perform the analysis of the input file. Raise an event when 
        /// data is available for consumption by the viewmodel
        /// Also track how long it took to process the file for 
        /// comparitive purposes
        /// </summary>
        /// <param name="selectedMethod">The method the user selected</param>
        /// <param name="filePath">The path to the input file</param>
        private void ProcessResults(String selectedMethod, String filePath)
        {
            LeaderData.Clear();
            //Use a factory to get the correct analysis method 
            ResultFinder finder = ResultFactory.GetResultFinder(selectedMethod, filePath);

            //Create the stopwatch to time the run
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int index = 1;
            foreach (String winner in finder.GetWinner())
            {
                String msg = String.Format(Constants.RUNTIME_RESULT, index++, winner);
                LeaderData.Add(msg);
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(Constants.METHOD_LEADER_DATA);
                PropertyChanged(this, args);
            }
            stopwatch.Stop();
            StopwatchDuration = stopwatch.Elapsed.ToString();
            PropertyChangedEventArgs stopwatchArgs = new PropertyChangedEventArgs(Constants.METHOD_STOPWATCH_DURATION);
            PropertyChanged(this, stopwatchArgs);
        }
    }
}