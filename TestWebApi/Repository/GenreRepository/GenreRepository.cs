using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationContext context;
        private DbSet<Genre> genres;
        public GenreRepository(ApplicationContext context)
        {
            this.context = context;
            genres = context.Set<Genre>();
        }

        public GenreViewModel Get(long id)
        {
            var entity = genres.SingleOrDefault(g => g.Id == id);
            if (entity == null) return null;
            var entityViewModel = new GenreViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return entityViewModel;
        }
        public List<GenreViewModel> GetAll()
        {
            var entitiesList = genres.ToList();
            if (entitiesList == null) return null;
            List<GenreViewModel> entityViewModelList = new List<GenreViewModel>();
            foreach (var entity in entitiesList)
            {
                var entityViewModel = new GenreViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
                entityViewModelList.Add(entityViewModel);
            }
            return entityViewModelList;
        }
        public void Insert(GenreViewModel model)
        {
            Genre entity = new Genre
            {
                Id = model.Id,
                Name = model.Name
            };
            genres.Add(entity);
            context.SaveChanges();
        }
        public void Update(GenreViewModel model)
        {
            Genre entity = genres.SingleOrDefault(g => g.Id == model.Id);
            if (entity == null) return;
            entity.Id = model.Id;
            entity.Name = model.Name;
            context.SaveChanges();
        }
        public void Delete(long id)
        {
            Genre entity = genres.SingleOrDefault(g => g.Id == id);
            if (entity == null) return;
            genres.Remove(entity);
            context.SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
