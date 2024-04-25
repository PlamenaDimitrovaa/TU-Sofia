using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr2.Helpers;

namespace Upr2.Others;
internal class Delegates
{
    public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");
    public static readonly ILogger fileLogger = LoggerHelper.GetFileLogger("Hello File");

    public static void Log(string error)
    {
        logger.LogError(error);
    }
    public static void LogFile(string error)
    {
        fileLogger.LogError(error);
    }
    public static void Log2(string error)
    {
        Console.WriteLine("- DELEGATES -");
        Console.WriteLine($"{error}");
        Console.WriteLine("- DELEGATES -");
    }


}
