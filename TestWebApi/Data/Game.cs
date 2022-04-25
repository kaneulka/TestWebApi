using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Game
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StudioId { get; set; }
        public Studio Studio { get; set; }
        public List<GameGenre> GameGenreList { get; set; }
        public Game()
        {
            GameGenreList = new List<GameGenre>();
        }
    }
    public class GameMap
    {
        public GameMap(EntityTypeBuilder<Game> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.HasMany(e => e.GameGenreList).WithOne(e => e.Game);
            entityBuilder.HasOne(e => e.Studio).WithMany(e => e.Games);
        }
    }
}
