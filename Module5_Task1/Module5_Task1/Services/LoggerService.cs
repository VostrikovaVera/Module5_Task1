using System;
using System.Threading.Tasks;
using Module5_Task1.Services.Interfaces;

namespace Module5_Task1.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
