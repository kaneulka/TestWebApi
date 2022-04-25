using Microsoft.AspNetCore.Mvc;
using Service.GameGenreService;
using Service.GameService;
using ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService gameService;
        private readonly IGameGenreService gameGenreService;
        public GameController(IGameService gameService, IGameGenreService gameGenreService)
        {
            this.gameService = gameService;
            this.gameGenreService = gameGenreService;
        }

        [HttpGet]
        public IActionResult Games(List<long> genreIds)
        {
            List<GameViewModel> model = gameService.GetGames(genreIds);
            return View(model);
        }
        [HttpPost]
        public void AddGame(GameViewModel model, List<long> genreIds)
        {
            gameService.InsertGame(model);
            gameGenreService.InsertArrayGameGenre(model, genreIds);
            RedirectToAction("Games");
        }
        [HttpGet]
        public IActionResult UpdateGame(long id)
        {
            GameViewModel model = gameService.GetGame(id);
            return View(model);
        }
        [HttpPost]
        public void UpdateGame(GameViewModel model, List<long> genreIds)
        {
            GameViewModel oldGameModel = gameService.GetGame(model.Id);
            gameService.UpdateGame(model);
            gameGenreService.DeleteArrayGameGenre(oldGameModel, oldGameModel.GameGenreList.Select(g => g.Genre).Select(g => g.Id).ToList());
            gameGenreService.InsertArrayGameGenre(model, genreIds);
            RedirectToAction("Games");
        }
        [HttpPost]
        public void DeleteGame(long id)
        {
            GameViewModel game = gameService.GetGame(id);
            gameService.DeleteGame(id);
            RedirectToAction("Games");
        }
    }
}
