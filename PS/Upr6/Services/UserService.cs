using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr6.Database;
using Upr6.Helpers;
using Upr6.Model;

namespace Upr6.Services
{
    public static class UserService
    {
        public static List<DbUser> GetAllUsers()
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
              return ctx.Users.ToList();
            }
        }
        public static void AddUser(string username, string password)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Users.Add(new DbUser() { Name = username, Password = password });
                ctx.SaveChanges();
            }
            LogsService.AddLog($"{username} Added!", LogPriorityEnum.Debug);
        }
        public static void RemoveUser(DbUser user)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Users.Remove(user);
                ctx.SaveChanges();
            }
            LogsService.AddLog($"{user.Name} Removed!", LogPriorityEnum.Critical);
        }
    }
}
