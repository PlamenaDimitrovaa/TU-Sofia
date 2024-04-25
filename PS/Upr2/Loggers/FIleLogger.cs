using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Upr2.Loggers;
internal class FileLogger : ILogger
{
    private readonly ConcurrentDictionary<int, string> _logMessages;
    private readonly string _name;

    public FileLogger(string name)
    {
        _name = name;
        _logMessages = new ConcurrentDictionary<int, string>();
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);

        File.AppendAllText("log.txt", "== Logger ==");
        File.AppendAllText("log.txt", Environment.NewLine);
        var messageToBeLogged = new StringBuilder();
        messageToBeLogged.Append($"[{logLevel}]");
        messageToBeLogged.AppendFormat(" [{0}]", _name);
        File.AppendAllText("log.txt", messageToBeLogged.ToString());
        File.AppendAllText("log.txt", Environment.NewLine);
        File.AppendAllText("log.txt", $"{formatter(state, exception)}");
        File.AppendAllText("log.txt", Environment.NewLine);
        File.AppendAllText("log.txt", "== Logger ==");
        File.AppendAllText("log.txt", Environment.NewLine);

        _logMessages[eventId.Id] = message;
    }
}
