using HtmlAgilityPack;
using System.Net.Http;
using System.Windows;

namespace PP_2_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                ResultLabel.Content = "Please enter a valid URL.";
                return;
            }

            FetchButton.IsEnabled = false;

            ResultLabel.Content = "Fetching data...";

            await FetchAndCountImages(url);

            FetchButton.IsEnabled = true;
        }

        private async Task FetchAndCountImages(string url)
        {
            try
            {
                client.Timeout = TimeSpan.FromSeconds(5);

                string htmlContent = await client.GetStringAsync(url);

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlContent);

                var images = htmlDoc.DocumentNode.SelectNodes("//img");

                if (images != null)
                {
                    ResultLabel.Content = $"Number of images: {images.Count}";
                }
                else
                {
                    ResultLabel.Content = "No images found on the page.";
                }
            }
            catch (HttpRequestException)
            {
                ResultLabel.Content = "Error: Unable to reach the website.";
            }
            catch (TaskCanceledException)
            {
                ResultLabel.Content = "Error: The request timed out.";
            }
            catch (Exception ex)
            {
                ResultLabel.Content = $"Error: {ex.Message}";
            }
        }
    }
}