using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upr6.Helpers;

namespace Upr6.Model;
public class DbLog
{
    public int Id { get; set; }
    public LogPriorityEnum Priority { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
