using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new GameMap(modelBuilder.Entity<Game>());
            new GameGenreMap(modelBuilder.Entity<GameGenre>());
            new GenreMap(modelBuilder.Entity<Genre>());
            new StudioMap(modelBuilder.Entity<Studio>());
        }
    }
}
