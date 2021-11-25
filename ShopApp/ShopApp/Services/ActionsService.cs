using System;
using ShopApp.Helpers;
using ShopApp.Services.Abstractions;
using ShopApp.Models;

namespace ShopApp.Services
{
    public class ActionsService : IActionsService
    {
        private readonly ILoggerService _logger;

        public ActionsService(ILoggerService logger)
        {
            _logger = logger;
        }

        public bool CreateInfoLog()
        {
            _logger.AddInfo(LogTypes.Info, "Start method: CreateInfoLog");
            return true;
        }

        public bool CreateWarningLog()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public bool CreateErrorLog()
        {
            throw new Exception("I broke a logic");
        }
    }
}
