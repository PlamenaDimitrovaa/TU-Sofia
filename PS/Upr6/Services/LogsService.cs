using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr6.Database;
using Upr6.Helpers;
using Upr6.Model;

namespace Upr6.Services;
public static class LogsService
{
    public static List<DbLog> GetAllLogs()
    {
        using (DatabaseContext ctx = new DatabaseContext())
        {
            return ctx.Logs.ToList();
        }
    }
    public static void AddLog(string message, LogPriorityEnum priority)
    {
        using (DatabaseContext ctx = new DatabaseContext())
        {
            ctx.Logs.Add(new DbLog() { Message = message, Priority = priority });
            ctx.SaveChanges();
        }
    }
}
