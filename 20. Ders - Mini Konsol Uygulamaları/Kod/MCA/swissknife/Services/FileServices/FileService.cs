using System.IO;

namespace swissknife.Services.FileServices
{
    public struct FileService
    {
        public void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
    }
}
