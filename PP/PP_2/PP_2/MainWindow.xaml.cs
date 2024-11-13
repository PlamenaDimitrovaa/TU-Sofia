using System.Text;
using System.Windows;

namespace PP_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;

            TimeLabel.Text = "Start Time: " + DateTime.Now.ToString("HH:mm:ss.fff");

            await SlowWork();

            TimeLabel.Text += "\nEnd Time: " + DateTime.Now.ToString("HH:mm:ss.fff");

            StartButton.IsEnabled = true;
        }

        private async Task SlowWork()
        {
            var random = new Random();
            var output = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                int randomNumber = random.Next(1, 101);
                output.AppendLine(randomNumber.ToString());

                OutputLabel.Content = output.ToString();

                int delay = random.Next(100, 201);
                await Task.Delay(delay);
            }
        }
    }
}