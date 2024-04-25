using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr6.Events;
using Upr6.Model;
using Upr6.Services;

namespace Upr6.ViewModel;
public class LogsViewModel
{
    public ObservableCollection<DbLog> Logs { get; set; } = new ObservableCollection<DbLog>();

    public LogsViewModel()
    {
        Logs = new ObservableCollection<DbLog>(LogsService.GetAllLogs());
    }
}
