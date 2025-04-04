using Transliteration.Data.Models;

namespace Transliteration.Web.ViewModels
{
    public class NameSearchViewModel
    {
        public string SearchQuery { get; set; }
        public List<NameEntry> Results { get; set; }
    }
}
