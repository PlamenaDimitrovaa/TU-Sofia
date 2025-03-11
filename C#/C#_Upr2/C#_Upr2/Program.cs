using System.Globalization;
using System.Text.Json;

namespace C__Upr2
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Processing geographic coordinates");
                Console.WriteLine("2. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ProcessGeographicCoordinates();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ProcessGeographicCoordinates()
        {
            string inputFile = "input-01.txt";
            string outputFile = "geo_data.json";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("File input-01.txt is not find.");
                return;
            }

            List<GeoPoint> points = ReadGeoData(inputFile);
            SaveToJson(points, outputFile);
        }

        static List<GeoPoint> ReadGeoData(string filePath)
        {
            List<GeoPoint> points = new List<GeoPoint>();

            try
            {
                string content = File.ReadAllText(filePath); 
                string[] pairs = content.Split(';');

                foreach (var pair in pairs)
                {
                    string[] parts = pair.Split(',');
                    if (parts.Length == 2 &&
                        float.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float lat) &&
                        float.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float lng))
                    {
                        points.Add(new GeoPoint(lat, lng));
                    }
                }

                Console.WriteLine($"Successfully read {points.Count} coordinates.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return points;
        }


        static void SaveToJson(List<GeoPoint> points, string outputFile)
        {
            try
            {
                string json = JsonSerializer.Serialize(points, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputFile, json);
                Console.WriteLine($"Data saved in {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
