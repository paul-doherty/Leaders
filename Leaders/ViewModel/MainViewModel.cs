using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Leaders.Common;
using Leaders.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Leaders.ViewModel
{
    /// <summary>
    /// This is the viewmodel for the application. The UI is bound to the 
    /// properties it presents. It retrives the data from the model presented 
    /// at runtime using inversion of control
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Properties bound to the view

        private String _filePath = String.Empty;
        /// <summary>
        /// The property for the filepath to which the UI is bound
        /// </summary>
        public String FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                
                Set(ref _filePath, value);
            }
        }

        private String _duration = String.Empty;
        /// <summary>
        /// The property for the duration to which the UI is bound
        /// </summary>
        public String Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                Set(ref _duration, value);
            }
        }

        public IList<String> _methods;

        /// <summary>
        /// The property for the available methods to which the UI is bound
        /// </summary>
        public IList<String> Methods
        {
            get
            {
                return _methods;
            }
            set
            {
                Set(ref _methods, value);
            }
        }

        private String _selectedMethod;
        /// <summary>
        /// The property for the method selected by the user
        /// </summary>
        public String SelectedMethod
        {
            get
            {
                return _selectedMethod;
            }
            set
            {
                Set(ref _selectedMethod, value);
            }
        }

        public ObservableCollection<String> _results;
        /// <summary>
        /// The results of the analysis fo the specified file.
        /// The UI list is bound here 
        /// </summary>
        public ObservableCollection<String> Results
        {
            get
            {
                return _results;
            }
            set
            {
                Set(ref _results, value);
            }
        }
        #endregion

        /// <summary>
        /// The data service/model from which data is bound
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// Property triggered by the UI on pressing "Go"
        /// </summary>
        public RelayCommand GoCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// <param name="dataService">The data service to use</param>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.PropertyChanged += _dataService_PropertyChanged;
            Methods = _dataService.GetMethods();
            GoCommand = new RelayCommand(Go);
            Results = new ObservableCollection<String>(_dataService.LeaderData);
            FilePath = String.Empty;
            Duration = _dataService.StopwatchDuration;
            SelectedMethod = DefaultMethodSelection();
        }

        /// <summary>
        /// The model has updated itself. Update the viewmodel accordingly
        /// </summary>
        /// <param name="sender">The model data service</param>
        /// <param name="e">The name of the property which changed</param>
        void _dataService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.CompareTo(Constants.METHOD_LEADER_DATA) == 0)
            {
                Results = new ObservableCollection<String>(_dataService.LeaderData);
            }
            else if (e.PropertyName.CompareTo(Constants.METHOD_STOPWATCH_DURATION) == 0)
            {
                Duration = _dataService.StopwatchDuration;
            }
        }

        /// <summary>
        /// Command the model to process the input file and update the results
        /// The is done asyncronously with each result displayed when available
        /// to both move the work off the UI thread and to provide the user 
        /// with the results as soon as possible
        /// </summary>
        public void Go()
        {
            _dataService.GetResultsAsync(SelectedMethod, FilePath);
        }

        /// <summary>
        /// Get the default selection for the method combo box
        /// </summary>
        /// <returns></returns>
        private String DefaultMethodSelection()
        {
            String result = String.Empty;
            if((Methods != null) && (Methods.Count > 0))
            {
                result = Methods[0];
            }
            return result;
        }
    }
}