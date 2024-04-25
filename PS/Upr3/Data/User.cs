using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr3.Data;
internal class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int FakNum { get; set; }
    public UserRolesEnum Role { get; set; }

    public DateTime Expires { get; set; }
}
