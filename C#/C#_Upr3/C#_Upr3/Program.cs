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
            Console.Write("Въведете IP адрес: ");
            string ip = Console.ReadLine();

            string url1 = $"https://progress.razorlabs.com/ip-detect/?ip={ip}";
            string url2 = $"https://ipapi.co/{ip}/country/";

            using HttpClient client = new HttpClient();

            try
            {
                string response = await client.GetStringAsync(url2);
                Console.WriteLine($"Държава: {response.Trim()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Грешка при извличане на информация: " + ex.Message);
            }
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