using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.GenreService
{
    public interface IGenreService
    {
        List<GenreViewModel> GetGenres();
        GenreViewModel GetGenre(long id);
        void InsertGenre(GenreViewModel model);
        void UpdateGenre(GenreViewModel model);
        void DeleteGenre(long id);
    }
}
