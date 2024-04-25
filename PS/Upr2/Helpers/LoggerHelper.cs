using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr2.Loggers;

namespace Upr2.Helpers;
internal static class LoggerHelper
{
    public static ILogger GetLogger(string categoryName)
    {
        var loggerFactory = new LoggerFactory();
        loggerFactory.AddProvider(new LoggerProvider());

        return loggerFactory.CreateLogger(categoryName);
    }

    public static ILogger GetFileLogger(string categoryName)
    {
        var loggerFactory = new LoggerFactory();
        loggerFactory.AddProvider(new FileLoggerProvider());

        return loggerFactory.CreateLogger(categoryName);
    }
}
