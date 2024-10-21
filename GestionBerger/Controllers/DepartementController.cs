using GestionBerger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace GestionBerger.Controllers
{
    public class DepartementController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;


        public DepartementController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Departement> listeDepartements;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllDepartements";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeDepartements = new List<Departement>();

            while (reader.Read())
            {
                Departement departement = new Departement();

                departement.IdDepartement = reader.GetInt32("IdDepartement");

                departement.NomDepartement = reader.GetString("NomDepartement");

                listeDepartements.Add(departement);
            }

            conn.Close();
            return View(listeDepartements);
        }

            // GET: DepartementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartementController/Create
        public ActionResult Create()
        {
            Departement d = new Departement();
            return View(d);
        }

        // POST: DepartementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Departement departement)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDepartement";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomDepartement", departement.NomDepartement));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(departement);
            }
        }

        // GET: DepartementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartementController/Edit/5
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

        // GET: DepartementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartementController/Delete/5
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
