using ShopApp.Models;

namespace ShopApp.Services.Abstractions
{
    public interface ILoggerService
    {
        void AddInfo(LogTypes logType, string msg);
        string[] GetLogArray();
    }
}
