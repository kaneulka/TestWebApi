using Repository.StudioRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.StudioService
{
    public class StudioService : IStudioService
    {
        private IStudioRepository studioRepository;
        public StudioService(IStudioRepository studioRepository)
        {
            this.studioRepository = studioRepository;
        }
        public List<StudioViewModel> GetStudios()
        {
            return studioRepository.GetAll();
        }
        public StudioViewModel GetStudio(long id)
        {
            return studioRepository.Get(id);
        }
        public void InsertStudio(StudioViewModel model)
        {
            studioRepository.Insert(model);
        }
        public void UpdateStudio(StudioViewModel model)
        {
            studioRepository.Update(model);
        }
        public void DeleteStudio(long id)
        {
            studioRepository.Delete(id);
        }
    }
}
