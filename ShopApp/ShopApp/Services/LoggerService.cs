using System;
using ShopApp.Models;
using ShopApp.Services.Abstractions;
using ShopApp.Providers.Abstractions;

namespace ShopApp.Services
{
    public class LoggerService : ILoggerService
    {
        private int _arrayCounter;
        private ILoggerProvider _loggerProvider;

        public LoggerService(ILoggerProvider loggerProvider)
        {
            _loggerProvider = loggerProvider;
            _arrayCounter = 0;
        }

        public string[] GetLogArray()
        {
            return _loggerProvider.LogArray;
        }

        public void AddInfo(LogTypes logType, string msg)
        {
            var log = $"{DateTime.UtcNow.ToLongTimeString()}: {logType}: {msg}";
            Console.WriteLine(log);
            _loggerProvider.LogArray[_arrayCounter] = log;
            _arrayCounter++;
        }
    }
}
