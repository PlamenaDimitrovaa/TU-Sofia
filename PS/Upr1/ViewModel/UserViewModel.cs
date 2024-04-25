using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr1.Model;
using Upr1.Others;

namespace Upr1.ViewModel;
public class UserViewModel
{
    private User _user;

    public string Names { get { return _user.Name; } set { _user.Name = value; } }
    public string Password { get { return _user.Password; } set { _user.Password = value; } }
    public string FakNum { get { return _user.FakNum; } set { _user.FakNum = value; } }
    public string Mail { get { return _user.Mail; } set { _user.FakNum = value; } }
    public UserRolesEnum Role { get { return _user.Role; } set { _user.Role = value; } }

    public UserViewModel(User user)
    {
        _user = user;
    }
}
