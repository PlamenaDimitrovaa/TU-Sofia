using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;

namespace Welcome
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "Plamena";
            user.Password = "pl123456";
            user.Role = UserRolesEnum.ADMIN;

            UserViewModel userViewModel = new UserViewModel(user);

            UserView userView = new UserView(userViewModel);

            userView.Display();
        }
    }
}