using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Upr5.Extras;
public class PasswordConverter : IValueConverter
{
    public string OGPass { get; set; }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var pass = new StringBuilder((string)value);
        OGPass = pass.ToString();
        for (int i = 0; i < pass.Length; i++)
        {
            pass[i] = '*';
        }

        return pass.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return OGPass;
    }
}
