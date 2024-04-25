using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr2.Loggers;

namespace Upr2.Loggers;
internal class FileLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(categoryName);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
