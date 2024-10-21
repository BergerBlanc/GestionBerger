using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBerger.Controllers
{
    public class CueilletteController : Controller
    {
        // GET: CueilletteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CueilletteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CueilletteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CueilletteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CueilletteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CueilletteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CueilletteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CueilletteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
