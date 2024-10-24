using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;

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


        // GET: DepartementController/Create
        public ActionResult Create()
        {
            Departement c = new Departement();
            return View(c);
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
        public ActionResult Edit(int IdDepartement)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Departement departement = new Departement();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDepartementById";
            cmd.Parameters.Add(new SqlParameter("@IdDepartement", IdDepartement));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                departement.IdDepartement = reader.GetInt32("IdDepartement");
                departement.NomDepartement = reader.GetString("NomDepartement");

            }

            conn.Close();
            return View(departement);
        }

        // POST: DepartementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdDepartement, Departement departement)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDepartement";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdDepartement", IdDepartement));
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

        // GET: DepartementController/Delete/5
        public ActionResult Delete(int IdDepartement)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Departement departement = new Departement();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDepartementById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdDepartement", IdDepartement));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                departement.IdDepartement = reader.GetInt32("IdDepartement");
                departement.NomDepartement = reader.GetString("NomDepartement");

            }

            conn.Close();
            return View(departement);
        }

        // POST: DepartementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdDepartement, Departement departement)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDepartement";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdDepartement", IdDepartement));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(departement);
            }
        }
    }
}
