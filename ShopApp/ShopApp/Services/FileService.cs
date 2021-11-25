using System;
using System.IO;
using ShopApp.Services.Abstractions;
using ShopApp.Configs;

namespace ShopApp.Services
{
    public class FileService : IFileService
    {
        private readonly FileServiceConfig _fileServiceConfig;
        private readonly Config _config;
        private readonly string _directoryPath;
        private string[] _filesArray;

        public FileService(IConfigService config)
        {
            _config = config.DeserializeConfig();
            _fileServiceConfig = _config.FileService;
            _directoryPath = _fileServiceConfig.DirectoryPath;
            _filesArray = new string[100];
        }

        public void InitFileSystem()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
                return;
            }

            _filesArray = Directory.GetFiles(_directoryPath);
            if (_filesArray.Length > 3)
            {
                for (var i = _filesArray.Length - 4; i >= 0; i--)
                {
                    File.Delete(_filesArray[i]);
                }
            }
        }

        public void WriteToFile(string[] logArray)
        {
            var currentTime = DateTime.UtcNow;
            File.WriteAllText($"{_directoryPath}/{currentTime.ToString("HH.mm.ss")} {currentTime.ToString("dd.MM.yyyy")}.txt", string.Join(string.Empty, logArray));
        }
    }
}
