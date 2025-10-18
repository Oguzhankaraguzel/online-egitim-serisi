using System;
using System.Collections.Generic;
using System.IO;

namespace swissknife.Services.FileServices
{
    public struct FileService
    {
        public void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public string[] GetAllFilesInDirectory(string directory, string extensionFilter)
        {
            List<string> filteredFiles = new List<string>();

            string[] allFiles = Directory.GetFiles(directory);

            foreach (string file in allFiles) 
            {
                if (extensionFilter != null) 
                {
                    string fileExtension = Path.GetExtension(file);
                    if (fileExtension.Equals(extensionFilter,StringComparison.OrdinalIgnoreCase)) 
                    {
                        filteredFiles.Add(file);
                    }
                }
                else
                {
                    filteredFiles.Add(file);
                }
            }
            return filteredFiles.ToArray();
        }
    }
}
