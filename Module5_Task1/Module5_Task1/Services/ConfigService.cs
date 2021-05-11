using Module5_Task1.Configs;
using Module5_Task1.Services.Interfaces;
using Newtonsoft.Json;

namespace Module5_Task1.Services
{
    public class ConfigService : IConfigService
    {
        private readonly string _filePath = "config.json";
        private readonly ApiConfig _apiConfig;
        private readonly IFileService _fileService;

        public ConfigService()
        {
            _fileService = LocatorService.FileService;

            var config = GetConfig();
            _apiConfig = config.Api;
        }

        public ApiConfig ApiConfig => _apiConfig;

        private Config GetConfig()
        {
            var json = _fileService.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
