using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Upr5.Database;
using Upr5.Model;

namespace Upr5.Windows;
/// <summary>
/// Interaction logic for AddUserWindow.xaml
/// </summary>
public partial class AddUserWindow : Window
{
    public AddUserWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (DatabaseContext ctx = new DatabaseContext())
        {
            ctx.Users.Add(new DatabaseUser()
            {
                Name = tbU.Text,
                Password = tbP.Text,
            });
            ctx.Logs.Add(new DatabaseLog()
            {
                Message = $"{tbU.Text} Created!",
            });
            ctx.SaveChanges();
        }
    }
}
