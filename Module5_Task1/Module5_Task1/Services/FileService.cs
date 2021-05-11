using System.IO;
using Module5_Task1.Services.Interfaces;

namespace Module5_Task1.Services
{
    public class FileService : IFileService
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
