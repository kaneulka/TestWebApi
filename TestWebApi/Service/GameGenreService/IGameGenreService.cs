using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.GameGenreService
{
    public interface IGameGenreService
    {
        List<GameGenreViewModel> GetGameGenre();
        void InsertArrayGameGenre(GameViewModel game, List<long> genreids);
        void DeleteArrayGameGenre(GameViewModel game, List<long> genreIds);
    }
}
