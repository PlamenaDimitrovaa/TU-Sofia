using Microsoft.Extensions.Logging;
using System.Text;
using Upr3.Data;
using Upr3.Helpers;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        ILogger il = LoggerHelper.GetFileLogger("hi");
        try
        {
            UserData userData = new UserData();

            User studentUser = new User()
            {
                Name = "student",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            User u2 = new User()
            {
                Name = "Student2",
                Password = "123",
                Role = UserRolesEnum.STUDENT
            };
            User u3 = new User()
            {
                Name = "Teacher",
                Password = "1234",
                Role = UserRolesEnum.PROFESSOR
            };
            User u4 = new User()
            {
                Name = "Admin",
                Password = "12345",
                Role = UserRolesEnum.ADMIN
            };
            userData.AddUser(studentUser);
            userData.AddUser(u2);
            userData.AddUser(u3);
            userData.AddUser(u4);

            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Pass:");
            string pass = Console.ReadLine();

            userData.ValidateCredentials(name, pass);
            User gu = userData.GetUser(name, pass);

            Console.WriteLine(gu.ToString(true));


            il.LogInformation($"{gu.ToString(true)} - {DateTime.Now.ToString()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            il.LogError(ex.Message);
        }

    }
}