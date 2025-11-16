using System;
using System.Collections.Generic;
using System.IO;

namespace swissknife.Services.FileServices
{
    public struct FileService
    {
        /// <summary>
        /// Verilen dizinin var olup olmadığını kontrol eder.
        /// Yoksa dizini oluşturur.
        /// </summary>
        public void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Belirtilen dizindeki tüm dosyaları listeler. 
        /// Eğer bir uzantı filtresi verilmişse sadece o uzantıya sahip dosyaları döner.
        /// Filtre null ise dizindeki tüm dosyaları döner.
        /// </summary>
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
