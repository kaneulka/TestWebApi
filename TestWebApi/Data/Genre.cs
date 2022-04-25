using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Genre
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<GameGenre> GameGenreList { get; set; }
        public Genre()
        {
            GameGenreList = new List<GameGenre>();
        }
    }
    public class GenreMap
    {
        public GenreMap(EntityTypeBuilder<Genre> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.HasMany(e => e.GameGenreList).WithOne(e => e.Genre);
        }
    }
}
