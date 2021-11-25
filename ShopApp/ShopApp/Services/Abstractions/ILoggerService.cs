using ShopApp.Models;

namespace ShopApp.Services.Abstractions
{
    public interface ILoggerService
    {
        string[] LogArray { get; set; }
        void AddInfo(LogTypes logType, string msg);
    }
}
