using System;
using ShopApp.Models;
using ShopApp.Services.Abstractions;
using ShopApp.Helpers;

namespace StyleCop.Main
{
    public class Starter
    {
        private readonly IActionsService _actionsService;
        private readonly ILoggerService _loggerService;
        private readonly IFileService _fileService;

        public Starter(IActionsService actionsService, ILoggerService loggerService, IFileService fileService)
        {
            _actionsService = actionsService;
            _loggerService = loggerService;
            _fileService = fileService;
        }

        public void Run()
        {
            _fileService.InitFileSystem();
            for (int i = 0; i < 100; i++)
            {
                var randomNum = new Random();
                var value = randomNum.Next(0, 3);
                try
                {
                    bool result;
                    switch (value)
                    {
                        case 0:
                            result = _actionsService.CreateInfoLog();
                            break;
                        case 1:
                            result = _actionsService.CreateWarningLog();
                            break;
                        case 2:
                            result = _actionsService.CreateErrorLog();
                            break;
                    }
                }
                catch (BusinessException businessExeption)
                {
                    _loggerService.AddInfo(LogTypes.Warning, $"Action got this custom Exception: {businessExeption}");
                }
                catch (Exception generalException)
                {
                    _loggerService.AddInfo(LogTypes.Error, $"Action failed by reason: {generalException}");
                }
            }

            _fileService.WriteToFile(_loggerService.GetLogArray());
            _fileService.OddFilesCollector();
        }
    }
}
