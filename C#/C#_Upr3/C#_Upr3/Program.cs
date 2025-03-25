using HtmlAgilityPack;
using System.Text;

namespace C__Upr3
{
    class Program
    {
        static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Проверка на IP адрес");
                Console.WriteLine("2. Извличане на текущо локално време");
                Console.WriteLine("3. Извличане на новини от новинарски сайт");
                Console.WriteLine("4. Изход");
                Console.Write("Изберете опция: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await GetIpInfo();
                        break;
                    case "2":
                        await GetLocalTime();
                        break;
                    case "3":
                        await ScrapeNews();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Невалиден избор!");
                        break;
                }
            }
        }

        static async Task GetIpInfo()
        {
            Console.WriteLine("Enter IP Address:");
            string ip = Console.ReadLine();

            string url = $"https://ipapi.co/{ip}/country/";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36");

                try
                {
                    string country = await client.GetStringAsync(url);
                    Console.WriteLine($"IP Address {ip} is from: {country}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching data: {ex.Message}");
                }
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static async Task GetLocalTime()
        {
            string url = "https://www.timeanddate.com/worldclock/bulgaria/sofia";
            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var dateNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@id='ctdat']");
            var timeNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@id='ct']");

            Console.WriteLine($"Дата: {dateNode?.InnerText}, Час: {timeNode?.InnerText}");
        }

        static async Task ScrapeNews()
        {
            string url = "https://www.mediapool.bg/";
            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var articles = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'article')]//h3");
            var dates = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'article')]//time");

            using StreamWriter writer = new StreamWriter("news_output.txt");

            if (articles != null && dates != null)
            {
                for (int i = 0; i < articles.Count && i < dates.Count; i++)
                {
                    string title = articles[i].InnerText.Trim();
                    string date = dates[i].InnerText.Trim();

                    if (!title.Contains("Covid") && !title.Contains("пандемия") && !title.Contains("корона вирус"))
                    {
                        string newsEntry = $"Дата: {date} | Заглавие: {title}";
                        writer.WriteLine(newsEntry);
                        Console.WriteLine(newsEntry);
                    }
                }
            }
            Console.WriteLine("Новините са записани в news_output.txt");
        }
    }
}