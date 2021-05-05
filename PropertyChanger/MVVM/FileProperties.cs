using PropertyChanger.MVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChanger.MVVM
{
    /// <summary>
    /// A helper class to get and set the properties of the file
    /// </summary>
    public static class FileProperties
    {
        public static List<string> GetTimes(string fullPath)
        {
            // If the file isn't valid return an empty string
            if (File.Exists(fullPath) == false)
                return new List<string>();

            var file = new SelectedFile(fullPath);

            var times = new List<string>();

            times.Add(file.CreationTime.ToString());
            times.Add(file.ModificationTime.ToString());
            times.Add(file.LastAccessTime.ToString());

            return times;
        }
    }
}
