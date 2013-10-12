namespace SystemDotDb.Infrastructure.Files
{
    public interface IFileSystem
    {
        bool FileExists(string path);
    }
}