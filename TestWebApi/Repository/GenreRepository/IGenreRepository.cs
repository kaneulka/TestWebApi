using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.GenreRepository
{
    public interface IGenreRepository
    {
        GenreViewModel Get(long id);
        List<GenreViewModel> GetAll();
        void Insert(GenreViewModel model);
        void Update(GenreViewModel model);
        void Delete(long id);
        void SaveChanges();
    }
}
