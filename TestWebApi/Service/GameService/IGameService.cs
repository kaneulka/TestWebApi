using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.GameService
{
    public interface IGameService
    {
        List<GameViewModel> GetGames(List<long> genreIds);
        GameViewModel GetGame(long id);
        void InsertGame(GameViewModel model);
        void UpdateGame(GameViewModel model);
        void DeleteGame(long id);
    }
}
