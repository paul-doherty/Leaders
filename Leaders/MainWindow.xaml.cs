using System.Windows;
using Leaders.ViewModel;
using Microsoft.Win32;
using System;
using Leaders.Common;

namespace Leaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// An MVVM application for the seperation of the application layers
    /// View <-> View Model <-> Model
    /// This view layer goes through the view model layer for all
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        /// <summary>
        /// Present the user with an open file dialog to pick the inout file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFilePicker_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog inputDialog = new OpenFileDialog();
            inputDialog.CheckFileExists = true;
            inputDialog.CheckPathExists = true;
            inputDialog.Multiselect = false;
            inputDialog.InitialDirectory = Environment.CurrentDirectory;
            inputDialog.DefaultExt = Constants.INPUT_EXTENSION;
            bool? inputResult = inputDialog.ShowDialog();
            if (inputResult.HasValue && inputResult.Value)
            {
                //update the view model with the selected file
                (this.DataContext as MainViewModel).FilePath = inputDialog.FileName;
            }
        }
    }
}