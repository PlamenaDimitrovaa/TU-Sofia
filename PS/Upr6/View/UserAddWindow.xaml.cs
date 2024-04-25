using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Upr6.ViewModel;

namespace Upr6.View
{
    /// <summary>
    /// Interaction logic for UserAddWindow.xaml
    /// </summary>
    public partial class UserAddWindow : Window
    {
        public UserAddWindow()
        {
            InitializeComponent();
            this.DataContext = new UserAddViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new UserReverseViewModel();
        }
    }
}
