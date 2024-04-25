using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr4.Loggers;
internal class DbLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new DbLogger(categoryName);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
