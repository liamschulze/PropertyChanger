using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
