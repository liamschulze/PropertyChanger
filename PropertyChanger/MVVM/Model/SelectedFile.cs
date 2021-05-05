using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.MVVM.Model
{
    /// <summary>
    /// The file that gets selected
    /// </summary>
    public class SelectedFile
    {
        #region Public Properties

        public string FullPath { get; set; }

        public DateTime CreationTime
        {
            get
            {
                return File.GetCreationTime(FullPath);
            }
        }

        public DateTime ModificationTime
        {
            get
            {
                return File.GetLastWriteTime(FullPath);
            }
        }

        public DateTime LastAccessTime
        {
            get
            {
                return File.GetLastAccessTime(FullPath);
            }
        }

        #endregion
    }
}
