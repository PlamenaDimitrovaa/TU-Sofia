using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Upr6.Database;
using Upr6.View;

namespace Upr6;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        using (DatabaseContext ctx = new DatabaseContext())
        {
            ctx.Database.EnsureCreated();
        }
        new MainWindow().Show();
    }
}
