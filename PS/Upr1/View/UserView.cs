using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr1.ViewModel;

namespace Upr1.View;
public class UserView
{
    private UserViewModel _viewModel;

    public UserView(UserViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void Display()
    {
        Console.WriteLine("Welcome");
        Console.WriteLine($"User: {_viewModel.Names}");
        Console.WriteLine($"FakNum: {_viewModel.FakNum}");
        Console.WriteLine($"Mail: {_viewModel.Mail}");
        Console.WriteLine($"Role: {_viewModel.Role}");
    }

    public void DisplayColor()
    {

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"Role: {_viewModel.Role}");
        Console.WriteLine($"Mail: {_viewModel.Mail}");
        Console.WriteLine($"FakNum: {_viewModel.FakNum}");
        Console.WriteLine($"User: {_viewModel.Names}");
        Console.WriteLine("Bye.");

        Console.ResetColor();
    }

    public void DisplayError()
    {
        throw new Exception("RANDOM ERROR");
    }

}
