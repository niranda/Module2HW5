using System;
using ShopApp.Models;
using ShopApp.Services.Abstractions;

namespace ShopApp.Services
{
    public class LoggerService : ILoggerService
    {
        private int _arrayCounter;

        public LoggerService()
        {
            _arrayCounter = 0;
            LogArray = new string[1000];
        }

        public string[] LogArray { get; set; }

        public void AddInfo(LogTypes logType, string msg)
        {
            var log = $"{DateTime.UtcNow.ToLongTimeString()}: {logType}: {msg}";
            LogArray[_arrayCounter] = log;
            _arrayCounter++;
        }
    }
}
