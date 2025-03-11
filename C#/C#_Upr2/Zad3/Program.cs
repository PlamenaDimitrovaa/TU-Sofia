using System.Text.Json;
using System.Xml.Linq;

namespace Zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input-03.dae";
            string outputFile = "dae_data.json";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"File {inputFile} not found!");
                return;
            }

            try
            {
                XDocument doc = XDocument.Load(inputFile);
                Dictionary<string, TagData> tags = new Dictionary<string, TagData>();

                // Четем всички елементи в XML
                foreach (var element in doc.Descendants())
                {
                    string id = element.Attribute("id")?.Value;
                    string connection = null;

                    // Проверяваме за атрибути, които започват с #
                    foreach (var attr in element.Attributes())
                    {
                        if (attr.Value.StartsWith("#"))
                        {
                            connection = attr.Value.TrimStart('#');
                            break;
                        }
                    }

                    // Добавяме таг в речника
                    if (!string.IsNullOrEmpty(id))
                    {
                        tags[id] = new TagData { Tag = element.Name.LocalName, Connection = connection };
                    }
                }

                // Конвертираме в JSON и записваме във файл
                string json = JsonSerializer.Serialize(tags.Values, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputFile, json);
                Console.WriteLine($"JSON saved successfully at {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file: {ex.Message}");
            }
        }
    }
}
