using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.GameGenreRepository
{
    public class GameGenreRepository : IGameGenreRepository
    {
        private readonly ApplicationContext context;
        private DbSet<GameGenre> gameGenres;
        public GameGenreRepository(ApplicationContext context)
        {
            this.context = context;
            gameGenres = context.Set<GameGenre>();
        }
        public List<GameGenreViewModel> GetAll()
        {
            List<GameGenre> entities = gameGenres.ToList();
            List<GameGenreViewModel> entitiesVM = new List<GameGenreViewModel>();
            foreach(var entity in entities)
            {
                GameGenreViewModel entityVM = new GameGenreViewModel
                {
                    GenreId = entity.GenreId,
                    GameId = entity.GameId
                };
                if (entity == null) continue;
                entitiesVM.Add(entityVM);
            }
            return entitiesVM;
        }
        public void InsertArray(List<GameGenreViewModel> entitiesViewModel)
        {
            foreach (var entityViewModel in entitiesViewModel)
            {
                GameGenre entity = new GameGenre
                {
                    GameId = entityViewModel.GameId,
                    GenreId = entityViewModel.GenreId
                };
                if (entity == null) continue;
                gameGenres.Add(entity);
            }
            context.SaveChanges();
        }
        public void DeleteArray(List<GameGenreViewModel> entitiesViewModel)
        {
            foreach(var entityViewModel in entitiesViewModel)
            {
                GameGenre entity = new GameGenre
                {
                    GameId = entityViewModel.GameId,
                    GenreId = entityViewModel.GenreId
                };
                if (entity == null) continue;
                gameGenres.Remove(entity);
            }
            context.SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
