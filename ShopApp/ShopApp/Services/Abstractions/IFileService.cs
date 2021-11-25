namespace ShopApp.Services.Abstractions
{
    public interface IFileService
    {
        void InitFileSystem();
        void OddFilesCollector();
        void WriteToFile(string[] logArray);
    }
}
