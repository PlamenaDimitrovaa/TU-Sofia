using System.Text;
using System.Text.RegularExpressions;
using Transliteration.Services.Data.Interfaces;

namespace Transliteration.Services.Data.Services
{
    public class TransliterationService : ITransliterationService
    {
        private static readonly Dictionary<char, string> transliterationMap = new Dictionary<char, string>
    {
        {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"}, {'е', "e"}, {'ж', "j"}, {'з', "z"}, {'и', "i"}, {'й', "y"},
        {'к', "k"}, {'л', "l"}, {'м', "m"}, {'н', "n"}, {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"}, {'у', "u"},
        {'ф', "f"}, {'х', "h"}, {'ц', "ts"}, {'ч', "ch"}, {'ш', "sh"}, {'щ', "sht"}, {'ъ', "a"}, {'ь', "y"}, {'ю', "yu"}, {'я', "ya"}
    };

        public string TransliterateCyrToLat(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = SanitizeStringCustom(input);
            var result = new StringBuilder();

            foreach (char c in input)
            {
                bool isUpper = char.IsUpper(c);
                char lowerChar = char.ToLower(c);

                if (transliterationMap.TryGetValue(lowerChar, out string match))
                {
                    result.Append(isUpper ? Capitalize(match) : match);
                }
                else
                {
                    result.Append(c); // Non-Cyrillic characters remain unchanged
                }
            }

            return result.ToString();
        }

        private static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        private static string SanitizeStringCustom(string input)
        {
            // Replace "ия"/"ИЯ" at word endings with "иа" (legal rule)
            string pattern = @"\b\w*(ия|ИЯ)\b";
            return Regex.Replace(input, pattern, m => m.Value.Remove(m.Value.Length - 1) + 'a');
        }
    }
}
