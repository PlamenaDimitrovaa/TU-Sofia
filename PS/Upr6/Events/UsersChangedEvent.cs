using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr6.Events
{
    public static class UsersChangedEvent
    {
        public static event EventHandler UsersChanged;

        public static void OnUsersChanged(EventArgs e)
        {
            UsersChanged?.Invoke(null, e);
        }
    }
}
