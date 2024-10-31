using GestionBerger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace GestionBerger.Controllers
{
    public class VilleController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;
        public VilleController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: VilleController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Ville> listeVilles;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllVilles";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeVilles = new List<Ville>();

            while (reader.Read())
            {
                Ville ville = new Ville();

                ville.IdVille = reader.GetInt32("IdVille");

                ville.NomVille = reader.GetString("NomVille");
                ville.Contact = reader.GetString("Contact");
                ville.Telephone = reader.GetString("Telephone");
                listeVilles.Add(ville);
            }

            conn.Close();
            return View(listeVilles);
            return View();
        }

        // GET: VilleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VilleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VilleController/Create
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

        // GET: VilleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VilleController/Edit/5
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

        // GET: VilleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VilleController/Delete/5
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
