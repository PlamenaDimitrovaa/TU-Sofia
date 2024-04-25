using Upr1.Model;
using Upr1.Others;
using Upr1.View;
using Upr1.ViewModel;

class Program
{
    public static void Main()
    {
        User user = new User()
        {
            Name = "Mitko",
            FakNum = "121221",
            Mail = "@gg.gg",
            Password = "123",
            Role = UserRolesEnum.STUDENT
        };

        UserViewModel uvm = new UserViewModel(user);
        UserView uv = new UserView(uvm);

        uv.Display();
        uv.DisplayColor();

        Console.ReadKey();
    }
}