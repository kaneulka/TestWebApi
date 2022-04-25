using Repository.GenreRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.GenreService
{
    public class GenreService : IGenreService
    {
        private IGenreRepository genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public List<GenreViewModel> GetGenres()
        {
            return genreRepository.GetAll();
        }
        public GenreViewModel GetGenre(long id)
        {
            return genreRepository.Get(id);
        }
        public void InsertGenre(GenreViewModel model)
        {
            genreRepository.Insert(model);
        }
        public void UpdateGenre(GenreViewModel model)
        {
            genreRepository.Update(model);
        }
        public void DeleteGenre(long id)
        {
            genreRepository.Delete(id);
        }
    }
}
