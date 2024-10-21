using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBerger.Controllers
{
    public class RaceChienController : Controller
    {
        // GET: RaceChienController
        public ActionResult Index()
        {
            return View();
        }

        
        // GET: RaceChienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RaceChienController/Create
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

        // GET: RaceChienController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RaceChienController/Edit/5
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

        // GET: RaceChienController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RaceChienController/Delete/5
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
