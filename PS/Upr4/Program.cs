using Microsoft.Extensions.Logging;
using System.Text;
using Upr1.Others;
using Upr4.Database;
using Upr4.Helpers;
using Upr4.Model;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        using (var context = new DatabaseContext())
        {
            ILogger logger = LoggerHelper.GetDbLogger("db");
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Add<DatabaseUser>(new DatabaseUser()
            {
                Name = "user",
                Password = "password",
                Expires = DateTime.Now,
                Role = UserRolesEnum.STUDENT,
                FakNum = "121221",
                Mail = "ff@ff"
            });
            context.SaveChanges();
            var users = context.Users.ToList();
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();

            var usss = context.Users.Where(x => x.Name == username).Where(x => x.Password == password).FirstOrDefault();

            if (usss != null)
            {
                Console.WriteLine("Валиден потребител");
            }
            else
            {
                Console.WriteLine("Невалидни данни");
                Environment.Exit(0);
            }

            while (true)
            {
                Console.WriteLine("Chose:");
                Console.WriteLine("1: All");
                Console.WriteLine("2: Add");
                Console.WriteLine("3: Del");
                Console.WriteLine("4: Logs");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        var allUsers = context.Users.ToList();
                        Console.WriteLine();
                        Console.WriteLine("- - - -");
                        foreach (var sUser in allUsers)
                        {
                            Console.WriteLine(sUser.Name);
                        }
                        Console.WriteLine("- - - -");
                        Console.WriteLine();
                        logger.LogInformation("listed users");
                        break;

                    case 2:
                        Console.WriteLine("Username:");
                        string addUname = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string addPass = Console.ReadLine();

                        context.Add<DatabaseUser>(new DatabaseUser()
                        {
                            Name = addUname,
                            Password = addPass,
                            Expires = DateTime.Now,
                            Role = UserRolesEnum.STUDENT,
                            FakNum = "@",
                            Mail = "@"
                        });
                        context.SaveChanges();
                        logger.LogInformation("added user");
                        break;
                    case 3:
                        Console.WriteLine("Username:");
                        string rUname = Console.ReadLine();
                        context.Remove<DatabaseUser>(context.Users.Where(x => x.Name == rUname).First());
                        context.SaveChanges();
                        logger.LogInformation("deleted user");
                        break;
                    case 4:
                        var allLogs = context.Logs.ToList();
                        foreach (var log in allLogs)
                        {
                            Console.WriteLine(log.Message);
                        }
                        logger.LogInformation("listed logs");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}