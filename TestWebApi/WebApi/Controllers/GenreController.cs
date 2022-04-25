using Microsoft.AspNetCore.Mvc;
using Service.GenreService;
using ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;
        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public IActionResult Genres()
        {
            List<GenreViewModel> model = genreService.GetGenres();
            return View(model);
        }
        [HttpPost]
        public void AddGenre(GenreViewModel model)
        {
            genreService.InsertGenre(model);
            RedirectToAction("Genres");
        }
        [HttpGet]
        public IActionResult UpdateGenre(long id)
        {
            GenreViewModel model = genreService.GetGenre(id);
            return View(model);
        }
        [HttpPost]
        public void UpdateGenre(GenreViewModel model)
        {
            genreService.UpdateGenre(model);
            RedirectToAction("Genres");
        }
        [HttpPost]
        public void DeleteGenre(long id)
        {
            genreService.DeleteGenre(id);
            RedirectToAction("Genres");
        }
    }
}
