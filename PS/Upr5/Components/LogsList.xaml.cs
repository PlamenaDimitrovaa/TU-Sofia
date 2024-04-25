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
/// Interaction logic for LogsList.xaml
/// </summary>
public partial class LogsList : UserControl
{
    public LogsList()
    {
        InitializeComponent();
        using (var ctx = new DatabaseContext())
        {
            var records = ctx.Logs.ToList();
            logs.DataContext = records;
        }
    }

    private void logs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(((DatabaseLog)logs.SelectedItem).Message);
    }
}
