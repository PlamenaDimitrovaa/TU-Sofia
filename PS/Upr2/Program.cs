using Upr1.Model;
using Upr1.Others;
using Upr1.View;
using Upr1.ViewModel;
using Upr2.Others;

class Program
{
    public static void Main()
    {
        try
        {
            var user = new User
            {
                Name = "John Smith",
                Password = "password",
                Role = UserRolesEnum.STUDENT
            };

            var viewModel = new UserViewModel(user);
            var view = new UserView(viewModel);

            view.Display();

            view.DisplayError();
        }
        catch (Exception ex)
        {
            var log = new ActionOnError(Delegates.Log);
            var logF = new ActionOnError(Delegates.LogFile);
            log(ex.Message);
            logF(ex.Message);
        }
        finally
        {
            Console.WriteLine("Executed in any case");
        }
    }
}