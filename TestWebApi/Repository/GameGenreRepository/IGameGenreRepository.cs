using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.GameGenreRepository
{
    public interface IGameGenreRepository
    {
        List<GameGenreViewModel> GetAll();
        void InsertArray(List<GameGenreViewModel> entities);
        void DeleteArray(List<GameGenreViewModel> entities);
        void SaveChanges();
    }
}
