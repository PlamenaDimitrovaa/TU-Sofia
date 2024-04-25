using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Upr2.Loggers;
internal class HashLogger : ILogger
{
    private readonly ConcurrentDictionary<int, string> _logMessages;
    private readonly string _name;

    public HashLogger(string name)
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

        switch (logLevel)
        {
            case LogLevel.Critical:
                Console.ForegroundColor = ConsoleColor.Red; break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.DarkRed; break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow; break;
            default:
                Console.ForegroundColor = ConsoleColor.White; break;
        }

        Console.WriteLine("== Logger ==");
        var messageToBeLogged = new StringBuilder();
        messageToBeLogged.Append($"[{logLevel}]");
        messageToBeLogged.AppendFormat(" [{0}]", _name);
        Console.WriteLine(messageToBeLogged);
        Console.WriteLine($"{formatter(state, exception)}");
        Console.WriteLine("== Logger ==");
        Console.ResetColor();

        _logMessages[eventId.Id] = message;
        PrintErrorById(0);
        RemoveErrorById(0);
    }

    public void PrintErrors()
    {
        foreach (var err in _logMessages)
        {
            Console.WriteLine(err.Value);
        }
    }

    public void PrintErrorById(int id)
    {
        Console.WriteLine(_logMessages[id]);
    }
    public void RemoveErrorById(int id)
    {
        string txt = "";
        _logMessages.Remove(id, out txt);
    }
}
