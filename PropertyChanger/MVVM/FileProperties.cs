using PropertyChanger.MVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace PropertyChanger.MVVM
{
    /// <summary>
    /// A helper class to get and set the properties of the file
    /// </summary>
    public static class FileProperties
    {
        /// <summary>
        /// Gets the times of a file
        /// </summary>
        /// <param name="fullPath">the full path to the file</param>
        /// <returns>The times in a list</returns>
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

        /// <summary>
        /// Sets the times of a file
        /// </summary>
        /// <param name="creationTime">The creation time of the file</param>
        /// <param name="modificationTime">The modification time of a file</param>
        /// <param name="lastAccessTime">The last access time of a file</param>
        /// <param name="fullPath">The path to the file</param>
        public static bool SetTimes(DateTime creationTime, DateTime modificationTime, DateTime lastAccessTime, string fullPath)
        {
            // Check if the file exists
            if (File.Exists(fullPath) == false)
                return false;

            // Set the times of the file
            File.SetCreationTime(fullPath, creationTime);
            File.SetLastWriteTime(fullPath, modificationTime);
            File.SetLastAccessTime(fullPath, lastAccessTime);

            return true;
        }
    }
}
