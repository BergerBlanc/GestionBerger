using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBerger.Controllers
{
    public class InterventionController : Controller
    {
        // GET: InterventionController
        public ActionResult Index()
        {
            return View();
        }

        
        // GET: InterventionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterventionController/Create
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

        // GET: InterventionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InterventionController/Edit/5
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

        // GET: InterventionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InterventionController/Delete/5
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
