using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBerger.Controllers
{
    public class EtatSanteController : Controller
    {
        // GET: EtatSanteController
        public ActionResult Index()
        {
            return View();
        }

        
        // GET: EtatSanteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtatSanteController/Create
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

        // GET: EtatSanteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EtatSanteController/Edit/5
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

        // GET: EtatSanteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EtatSanteController/Delete/5
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
