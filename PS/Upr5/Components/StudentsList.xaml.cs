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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Upr5.Database;
using Upr5.Model;

namespace Upr5.Components;
/// <summary>
/// Interaction logic for StudentsList.xaml
/// </summary>
public partial class StudentsList : UserControl
{
    public StudentsList()
    {
        InitializeComponent();
        DisplayUsers();

        students.ContextMenu = new ContextMenu();
        Button delBtn = new Button();
        delBtn.Content = "Изтрий";
        students.ContextMenu.Items.Add(delBtn);
    }

    public void DisplayUsers()
    {
        using (var ctx = new DatabaseContext())
        {
            ctx.Database.EnsureCreated();
            var records = ctx.Users.ToList();
            students.DataContext = records;
        }
    }

    private void students_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        using (DatabaseContext ctx = new DatabaseContext())
        {
            ctx.Users.Remove((DatabaseUser)students.SelectedItem);
            ctx.SaveChanges();
        }
        DisplayUsers();
    }
}
