using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace PropertyChanger.MVVM.ViewModel
{
    /// <summary>
    /// The view model for the file
    /// </summary>
    class SelectedFileViewModel : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// The full path of the file
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The creation time of the file
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// The modification time of the file
        /// </summary>
        public string ModificationTime { get; set; }

        /// <summary>
        /// The last access time of the file
        /// </summary>
        public string LastAccessTime { get; set; }

        /// <summary>
        /// Determines if the error message is showen
        /// </summary>
        public Visibility FileErrorMessage { get; set; } = Visibility.Hidden;

        /// <summary>
        /// Enables the text boxed to enter the dates
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// The output if the action was successful or not
        /// </summary>
        public string ApplyOutput { get; set; }

        #endregion

        #region Constructor

        public SelectedFileViewModel()
        {
            SelectCommand = new RelayCommand(SelectFile);

            ApplyCommand = new RelayCommand(ChangeDates);
        }

        #endregion

        #region Commands

        public ICommand SelectCommand { get; set; }

        public ICommand ApplyCommand { get; set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Gets the times from a file and sets them in the view model
        /// </summary>
        private void SelectFile()
        {
            // I know this shouldn't be done this way but I don't know how to do it otherwise
            OpenFileDialog openFileDialog = new OpenFileDialog();

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                openFileDialog.Title = "Select a file";
                openFileDialog.Filter = "All files (*.*) | *.*";

                FullPath = openFileDialog.FileName;
            }

            // Get the times
            var times = FileProperties.GetTimes(FullPath);

            try
            {
                // Try to set the times
                CreationTime = times[0];
                ModificationTime = times[1];
                LastAccessTime = times[2];

                // Enable the text boxes
                IsEnabled = true;

                // Hide the error message
                FileErrorMessage = Visibility.Hidden;

                // Clear the output
                ApplyOutput = string.Empty;
            }
            catch
            {
                // Otherwise set them to empty strings
                CreationTime = string.Empty;
                ModificationTime = string.Empty;
                LastAccessTime = string.Empty;

                // Disable text boxes
                IsEnabled = false;

                // Show the error message
                FileErrorMessage = Visibility.Visible;
            }
        }

        private void ChangeDates()
        {
            // Create empty DateTimes
            DateTime creationTime;
            DateTime modificationTime;
            DateTime lastAccessTime;

            try
            {
                // Try to parse the inputs to DateTimes
                creationTime = DateTime.Parse(CreationTime);
                modificationTime = DateTime.Parse(ModificationTime);
                lastAccessTime = DateTime.Parse(LastAccessTime);
            }
            catch
            {
                // Otherwise set an errormessage to the output
                ApplyOutput = "Please enter a valid date";

                // And exit the function
                return;
            }

            // Set the times
            var isSuccess = FileProperties.SetTimes(creationTime, modificationTime, lastAccessTime, FullPath);

            // Set the output
            ApplyOutput = isSuccess ? "The times of the file have been changed successfully" : "Something went wrong. Please try again.";
        }

        #endregion
    }
}
