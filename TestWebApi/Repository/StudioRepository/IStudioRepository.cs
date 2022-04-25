using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.StudioRepository
{
    public interface IStudioRepository
    {
        StudioViewModel Get(long id);
        List<StudioViewModel> GetAll();
        void Insert(StudioViewModel model);
        void Update(StudioViewModel model);
        void Delete(long id);
        void SaveChanges();
    }
}
