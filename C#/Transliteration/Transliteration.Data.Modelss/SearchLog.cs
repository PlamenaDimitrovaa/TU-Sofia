using System.ComponentModel.DataAnnotations;

namespace Transliteration.Data.Models
{
    public class SearchLog
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Query { get; set; }

        public DateTime SearchDate { get; set; } = DateTime.UtcNow;
    }
}
