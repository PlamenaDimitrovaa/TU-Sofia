using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr4.Loggers;

namespace Upr4.Helpers;
internal static class LoggerHelper
{
    public static ILogger GetDbLogger(string categoryName)
    {
        var loggerFactory = new LoggerFactory();
        loggerFactory.AddProvider(new DbLoggerProvider());

        return loggerFactory.CreateLogger(categoryName);
    }
}
