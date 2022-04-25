using Repository.GameGenreRepository;
using Repository.GameRepository;
using Repository.GenreRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.GameService
{
    public class GameService : IGameService
    {
        private IGameRepository gameRepository;
        private IGameGenreRepository gameGenreRepository;
        private IGenreRepository genreRepository;
        public GameService(IGameRepository gameRepository, IGameGenreRepository gameGenreRepository, IGenreRepository genreRepository)
        {
            this.gameRepository = gameRepository;
            this.gameGenreRepository = gameGenreRepository;
            this.genreRepository = genreRepository;
        }
        public List<GameViewModel> GetGames(List<long> genreIds)
        {
            List<GameGenreViewModel> gameGenres = gameGenreRepository.GetAll();
            List<GenreViewModel> genres = genreRepository.GetAll();
            List<GameViewModel> games = gameRepository.GetAll().Where(g => gameGenres.Where(g => genreIds.Contains(g.GenreId)).Select(gg=> gg.GameId).Contains(g.Id)).ToList();
            foreach(var game in games)
            {
                game.GenreList = genres.Where(g=> gameGenres.Where(gg=> gg.GameId == game.Id).Select(gg=> gg.GenreId).Contains(g.Id)).ToList();
            }
            return games;
        }
        public GameViewModel GetGame(long id)
        {
            return gameRepository.Get(id);
        }
        public void InsertGame(GameViewModel model)
        {
            gameRepository.Insert(model);
        }
        public void UpdateGame(GameViewModel model)
        {
            gameRepository.Update(model);
        }
        public void DeleteGame(long id)
        {
            gameRepository.Delete(id);
        }
    }
}
