using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PropertyChanger.MVVM.ViewModel
{
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

        #endregion

        #region Commands

        #region Constructor

        public SelectedFileViewModel()
        {
            SelectCommand = new RelayCommand(SelectFile);
        }

        #endregion

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
            }
            catch
            {
                // Otherwise set them to empty strings
                CreationTime = string.Empty;
                ModificationTime = string.Empty;
                LastAccessTime = string.Empty;
            }

        }

        #endregion
    }
}
