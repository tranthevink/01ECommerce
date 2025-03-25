using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces;

namespace ECommerce.Infrastructure.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now}] {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now}] {message}");
        }
    }
}
