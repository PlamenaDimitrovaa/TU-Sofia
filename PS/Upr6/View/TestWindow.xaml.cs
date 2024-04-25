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

namespace Upr6.View;
/// <summary>
/// Interaction logic for TestWindow.xaml
/// </summary>
public partial class TestWindow : Window
{
    public TestWindow()
    {
        InitializeComponent();
        pageFrame.Navigate(new Uri("Pages/Page1.xaml", UriKind.Relative));
    }

    private void swBtn_Click(object sender, RoutedEventArgs e)
    {
        if (pageFrame.Source.OriginalString == "Pages/Page1.xaml")
        {
            pageFrame.Navigate(new Uri("Pages/Page2.xaml", UriKind.Relative));
        }
        else
        {
            pageFrame.Navigate(new Uri("Pages/Page1.xaml", UriKind.Relative));
        }

    }
}
