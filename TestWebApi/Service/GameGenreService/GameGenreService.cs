using Repository.GameGenreRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.GameGenreService
{
    public class GameGenreService : IGameGenreService
    {
        private IGameGenreRepository gameGenreRepository;
        public GameGenreService(IGameGenreRepository gameGenreRepository)
        {
            this.gameGenreRepository = gameGenreRepository;
        }
        public List<GameGenreViewModel> GetGameGenre()
        {
            return gameGenreRepository.GetAll();
        }
        public void InsertArrayGameGenre(GameViewModel game, List<long> genreIds)
        {
            List<GameGenreViewModel> entities = new List<GameGenreViewModel>();
            foreach(var genreId in genreIds)
            {
                GameGenreViewModel entity = new GameGenreViewModel
                {
                    GameId = game.Id,
                    GenreId = genreId
                };
                entities.Add(entity);
            }
            gameGenreRepository.InsertArray(entities);
        }
        public void DeleteArrayGameGenre(GameViewModel game, List<long> genreIds)
        {
            List<GameGenreViewModel> entities = new List<GameGenreViewModel>();
            foreach (var genreId in genreIds)
            {
                GameGenreViewModel entity = new GameGenreViewModel
                {
                    GameId = game.Id,
                    GenreId = genreId
                };
                entities.Add(entity);
            }
            gameGenreRepository.DeleteArray(entities);
        }
    }
}
