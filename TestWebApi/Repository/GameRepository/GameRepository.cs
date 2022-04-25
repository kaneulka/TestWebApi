using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.GameRepository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationContext context;
        private DbSet<Game> games;
        private DbSet<GameGenre> gameGenres;
        public GameRepository(ApplicationContext context)
        {
            this.context = context;
            games = context.Set<Game>();
        }

        public GameViewModel Get(long id)
        {
            var entity = games.Include(g => g.Studio)
                .Include(g=> g.GameGenreList).ThenInclude(g=> g.Genre)
                .SingleOrDefault(g=> g.Id == id);
            if (entity == null ) return null;
            var entityViewModel = new GameViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                StudioId = entity.StudioId
            };
            entityViewModel.Studio = new StudioViewModel
            {
                Id = entity.Studio.Id,
                Name = entity.Name
            };
            return entityViewModel;
        }
        public List<GameViewModel> GetAll()
        {
            var entitiesList = games.Include(g => g.Studio)
                .Include(g => g.GameGenreList).ThenInclude(g => g.Genre)
                .ToList();
            if (entitiesList == null) return null;
            List<GameViewModel> entityViewModelList = new List<GameViewModel>();
            foreach(var entity in entitiesList)
            {
                var entityViewModel = new GameViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    StudioId = entity.StudioId
                };
                entityViewModel.Studio = new StudioViewModel
                {
                    Id = entity.Studio.Id,
                    Name = entity.Name
                };
                entityViewModelList.Add(entityViewModel);
            }
            return entityViewModelList;
        }
        public void Insert(GameViewModel model)
        {
            Game entity = new Game
            {
                Id = model.Id,
                Name = model.Name,
                StudioId = model.StudioId
            };
            games.Add(entity);
            context.SaveChanges();
        }
        public void Update(GameViewModel model)
        {
            Game entity = games.Include(g => g.Studio).SingleOrDefault(g => g.Id == model.Id);
            if (entity == null) return;
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.StudioId = model.StudioId;
            context.SaveChanges();
        }
        public void Delete(long id)
        {
            Game entity = games.Include(g => g.Studio).SingleOrDefault(g => g.Id == id);
            if (entity == null) return;
            List<GameGenre> lgg = gameGenres.Where(g => g.GameId == entity.Id).ToList();
            gameGenres.RemoveRange(lgg);
            games.Remove(entity);
            context.SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
