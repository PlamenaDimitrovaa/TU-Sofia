using System.ComponentModel.DataAnnotations;

namespace Transliteration.Data.Models
{
    public class NameEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameOriginal { get; set; } // Може да е на кирилица, латиница или смесено

        [Required]
        [MaxLength(100)]
        public string NameTransliterated { get; set; } // Винаги на латиница (унифицирана форма)
    }
}
