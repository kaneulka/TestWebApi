using Microsoft.AspNetCore.Mvc;
using Service.StudioService;
using ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudioController : Controller
    {
        private readonly IStudioService studioService;
        public StudioController(IStudioService studioService)
        {
            this.studioService = studioService;
        }

        [HttpGet]
        public IActionResult Studios()
        {
            List<StudioViewModel> model = studioService.GetStudios();
            return View(model);
        }
        [HttpPost]
        public void AddStudio(StudioViewModel model)
        {
            studioService.InsertStudio(model);
            RedirectToAction("Studios");
        }
        [HttpGet]
        public IActionResult UpdateStudio(long id)
        {
            StudioViewModel model = studioService.GetStudio(id);
            return View(model);
        }
        [HttpPost]
        public void UpdateStudio(StudioViewModel model)
        {
            studioService.UpdateStudio(model);
            RedirectToAction("Studios");
        }
        [HttpPost]
        public void DeleteStudio(long id)
        {
            studioService.DeleteStudio(id);
            RedirectToAction("Studios");
        }
    }
}
