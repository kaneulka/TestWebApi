using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.StudioService
{
    public interface IStudioService
    {
        List<StudioViewModel> GetStudios();
        StudioViewModel GetStudio(long id);
        void InsertStudio(StudioViewModel model);
        void UpdateStudio(StudioViewModel model);
        void DeleteStudio(long id);
    }
}
