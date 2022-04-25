using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GameGenre
    {
        public long GenreId { get; set; }
        public Genre Genre { get; set; }
        public long GameId { get; set; }
        public Game Game { get; set; }
    }

    public class GameGenreMap
    {
        public GameGenreMap(EntityTypeBuilder<GameGenre> entityBuilder)
        {
            entityBuilder.HasKey(e => e.GenreId);
            entityBuilder.HasKey(e => e.GameId);
        }
    }
}
