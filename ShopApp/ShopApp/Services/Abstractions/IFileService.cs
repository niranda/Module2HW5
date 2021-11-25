namespace ShopApp.Services.Abstractions
{
    public interface IFileService
    {
        void InitFileSystem();
        void WriteToFile(string[] logArray);
    }
}
