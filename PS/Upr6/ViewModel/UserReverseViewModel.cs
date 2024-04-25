using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Upr6.Commands;
using Upr6.Events;
using Upr6.Services;

namespace Upr6.ViewModel;
public class UserReverseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _username;
    private string _password;
    public string Username
    {
        get { return _username; }
        set
        {
            _username = value;
            NotifyPropertyChanged();
        }
    }
    public string Password
    {
        get { return _password; }
        set
        {
            _password = value;
            NotifyPropertyChanged();
        }
    }

    public ICommand UserAddCommand { get; set; } = new RelayCommand((o) =>
    {
        UserReverseViewModel vm = o as UserReverseViewModel;

        UserService.AddUser(vm.Password, vm.Username);
        vm.Username = "";
        vm.Password = "";

        UsersChangedEvent.OnUsersChanged(new EventArgs());
    });

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}