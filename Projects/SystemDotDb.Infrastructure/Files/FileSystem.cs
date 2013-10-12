using System.IO;

namespace SystemDotDb.Infrastructure.Files
{
    public class FileSystem : IFileSystem
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
