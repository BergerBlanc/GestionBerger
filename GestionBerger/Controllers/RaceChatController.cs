using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBerger.Controllers
{
    public class RaceChatController : Controller
    {
        // GET: RaceChatController
        public ActionResult Index()
        {
            return View();
        }


        // GET: RaceChatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RaceChatController/Create
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

        // GET: RaceChatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RaceChatController/Edit/5
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

        // GET: RaceChatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RaceChatController/Delete/5
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
