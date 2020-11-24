using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Logger
{
    public class AppLoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public AppLoggerAdapter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<T>();
        }

        public void LogInformation(string msg, params object[] args)
        {
            this._logger.LogInformation(message:msg, args:args);
        }

        public void LogWarning(string msg, params object[] args)
        {
            this._logger.LogWarning(message:msg, args:args);
        }
    }
}