using Module5_Task1.Services.Interfaces;

namespace Module5_Task1.Services
{
    public class LocatorService
    {
        public static ILoggerService LoggerService => new LoggerService();

        public static IRequestService RequestService => new RequestService();

        public static IConfigService ConfigService => new ConfigService();

        public static IFileService FileService => new FileService();
    }
}
