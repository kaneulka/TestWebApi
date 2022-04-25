using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.StudioRepository
{
    public class StudioRepository : IStudioRepository
    {
        private readonly ApplicationContext context;
        private DbSet<Studio> studios;
        public StudioRepository(ApplicationContext context)
        {
            this.context = context;
            studios = context.Set<Studio>();
        }

        public StudioViewModel Get(long id)
        {
            var entity = studios.SingleOrDefault(g => g.Id == id);
            if (entity == null) return null;
            var entityViewModel = new StudioViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return entityViewModel;
        }
        public List<StudioViewModel> GetAll()
        {
            var entitiesList = studios.ToList();
            if (entitiesList == null) return null;
            List<StudioViewModel> entityViewModelList = new List<StudioViewModel>();
            foreach (var entity in entitiesList)
            {
                var entityViewModel = new StudioViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
                entityViewModelList.Add(entityViewModel);
            }
            return entityViewModelList;
        }
        public void Insert(StudioViewModel model)
        {
            Studio entity = new Studio
            {
                Id = model.Id,
                Name = model.Name
            };
            studios.Add(entity);
            context.SaveChanges();
        }
        public void Update(StudioViewModel model)
        {
            Studio entity = studios.SingleOrDefault(g => g.Id == model.Id);
            if (entity == null) return;
            entity.Id = model.Id;
            entity.Name = model.Name;
            context.SaveChanges();
        }
        public void Delete(long id)
        {
            Studio entity = studios.SingleOrDefault(g => g.Id == id);
            if (entity == null) return;
            studios.Remove(entity);
            context.SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
