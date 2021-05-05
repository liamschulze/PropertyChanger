using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        public Visibility FileErrorMessage { get; set; } = Visibility.Hidden;

        public bool IsEnabled { get; set; } = false;

        #endregion

        #region Constructor

        public SelectedFileViewModel()
        {
            SelectCommand = new RelayCommand(SelectFile);
        }

        #endregion

        #region Commands

        public ICommand SelectCommand { get; set; }

        #endregion

        #region Command Methods

        /// <summary>
        /// Gets the times from a file and sets them in the view model
        /// </summary>
        private void SelectFile()
        {
            // Replace all forward slahes with backslashes
            FullPath.Replace('/', '\\');

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

        #endregion
    }
}
