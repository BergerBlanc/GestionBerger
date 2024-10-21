using Microsoft.AspNetCore.Mvc;

namespace GestionBerger.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Couleur()
        {
            return RedirectToAction("Index", "Couleur");
        }
    }

}
