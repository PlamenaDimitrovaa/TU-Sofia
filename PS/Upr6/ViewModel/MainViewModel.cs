using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Upr6.Commands;
using Upr6.Database;
using Upr6.Events;
using Upr6.Model;
using Upr6.Services;
using Upr6.View;

namespace Upr6.ViewModel
{
    public class MainViewModel
    {
        public DbUser SelectedUser { get; set; }
        public ObservableCollection<DbUser> Users { get; set; } = new ObservableCollection<DbUser>();
        public ICommand ResetDatabaseCommand { get; set; } = new RelayCommand((o) =>
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
            UsersChangedEvent.OnUsersChanged(new EventArgs());
        });
        public ICommand OpenUserAddWindowCommand { get; set; } = new RelayCommand((o) =>
        {
            new UserAddWindow().Show();
        });
        public ICommand OpenUsersWindowCommand { get; set; } = new RelayCommand((o) =>
        {
            new UsersWindow().Show();
        });
        public ICommand OpenLogsWindowCommand { get; set; } = new RelayCommand((o) =>
        {
            new LogsWindow().Show();
        });
        public ICommand RemoveUserCommand { get; set; } = new RelayCommand((o) =>
        {
            MainViewModel vm = (MainViewModel)o;
            UserService.RemoveUser(vm.SelectedUser);
            UsersChangedEvent.OnUsersChanged(new EventArgs());
        });
        public MainViewModel()
        {
            Users = new ObservableCollection<DbUser>(UserService.GetAllUsers());
            UsersChangedEvent.UsersChanged += (s, e) =>
            {
                Users.Clear();
                foreach (DbUser user in UserService.GetAllUsers())
                {
                    Users.Add(user);
                }
            };
        }

    }
}
