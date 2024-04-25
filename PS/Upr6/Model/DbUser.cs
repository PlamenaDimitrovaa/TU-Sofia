using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr6.Helpers;

namespace Upr6.Model;
public class DbUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public UserRolesEnum Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return Name;
    }
}
