using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transliteration.Data.Models;

namespace Transliteration.Data.Configurations
{
    public class NameEntryConfiguration : IEntityTypeConfiguration<NameEntry>
    {
        public void Configure(EntityTypeBuilder<NameEntry> builder)
        {
            builder.HasData(this.GenerateNames());
        }

        private NameEntry[] GenerateNames()
        {
            ICollection<NameEntry> names = new HashSet<NameEntry>();

            NameEntry name;

            name = new NameEntry()
            {
                Id = 1,
                NameOriginal = "Иван",
                NameTransliterated = "Ivan"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 2,
                NameOriginal = "Мария",
                NameTransliterated = "Maria"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 3,
                NameOriginal = "Петя",
                NameTransliterated = "Petya"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 4,
                NameOriginal = "ПламенА",
                NameTransliterated = "Plamena"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 5,
                NameOriginal = "PLAMENA",
                NameTransliterated = "Plamena"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 6,
                NameOriginal = "PetyA",
                NameTransliterated = "Petya"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 7,
                NameOriginal = "Георги",
                NameTransliterated = "Georgi"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 8,
                NameOriginal = "Georgi",
                NameTransliterated = "Georgi"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 9,
                NameOriginal = "Daniel",
                NameTransliterated = "Daniel"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 10,
                NameOriginal = "Даниел",
                NameTransliterated = "Daniel"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 11,
                NameOriginal = "Yoana",
                NameTransliterated = "Yoana"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 12,
                NameOriginal = "Йоана",
                NameTransliterated = "Yoana"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 13,
                NameOriginal = "Кристиян",
                NameTransliterated = "Kristiyan"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 14,
                NameOriginal = "Martin",
                NameTransliterated = "Martin"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 15,
                NameOriginal = "Мартин",
                NameTransliterated = "Martin"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 16,
                NameOriginal = "пЛамЕна",
                NameTransliterated = "Plamena"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 17,
                NameOriginal = "Kristian",
                NameTransliterated = "Kristian"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 18,
                NameOriginal = "Кристиан",
                NameTransliterated = "Kristian"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 19,
                NameOriginal = "SimeoN",
                NameTransliterated = "Simeon"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 20,
                NameOriginal = "Симеон",
                NameTransliterated = "Simeon"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 21,
                NameOriginal = "Александър",
                NameTransliterated = "Aleksandar"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 22,
                NameOriginal = "Aleksandar",
                NameTransliterated = "Aleksandar"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 23,
                NameOriginal = "София",
                NameTransliterated = "Sofia"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 24,
                NameOriginal = "Sofia",
                NameTransliterated = "Sofia"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 25,
                NameOriginal = "НикоЛ",
                NameTransliterated = "Nikol"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 26,
                NameOriginal = "Илия",
                NameTransliterated = "Ilia"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 27,
                NameOriginal = "Ilia",
                NameTransliterated = "Ilia"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 28,
                NameOriginal = "Виктория",
                NameTransliterated = "Viktoria"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 29,
                NameOriginal = "Viktoria",
                NameTransliterated = "Viktoria"
            };

            names.Add(name);

            name = new NameEntry()
            {
                Id = 30,
                NameOriginal = "IvaylA",
                NameTransliterated = "Ivayla"
            };

            names.Add(name);

            return names.ToArray();
        }
    }
}
