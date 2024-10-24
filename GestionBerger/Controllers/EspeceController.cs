using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionBerger.Controllers
{
    public class EspeceController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;


        public EspeceController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Espece> listeEspeces;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllEspeces";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeEspeces = new List<Espece>();

            while (reader.Read())
            {
                Espece espece = new Espece();

                espece.IdEspece = reader.GetInt32("IdEspece");

                espece.NomEspece = reader.GetString("NomEspece");

                listeEspeces.Add(espece);
            }

            conn.Close();
            return View(listeEspeces);

        }


        // GET: EspeceController/Create
        public ActionResult Create()
        {
            Espece c = new Espece();
            return View(c);
        }

        // POST: EspeceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Espece espece)
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
                cmd.CommandText = "InsertEspece";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomEspece", espece.NomEspece));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(espece);
            }
        }

        // GET: EspeceController/Edit/5
        public ActionResult Edit(int IdEspece)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Espece espece = new Espece();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEspeceById";
            cmd.Parameters.Add(new SqlParameter("@IdEspece", IdEspece));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                espece.IdEspece = reader.GetInt32("IdEspece");
                espece.NomEspece = reader.GetString("NomEspece");

            }

            conn.Close();
            return View(espece);
        }

        // POST: EspeceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdEspece, Espece espece)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEspece";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdEspece", IdEspece));
                cmd.Parameters.Add(new SqlParameter("@NomEspece", espece.NomEspece));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(espece);
            }
        }

        // GET: EspeceController/Delete/5
        public ActionResult Delete(int IdEspece)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Espece espece = new Espece();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEspeceById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdEspece", IdEspece));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                espece.IdEspece = reader.GetInt32("IdEspece");
                espece.NomEspece = reader.GetString("NomEspece");

            }

            conn.Close();
            return View(espece);
        }

        // POST: EspeceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdEspece, Espece espece)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEspece";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdEspece", IdEspece));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(espece);
            }
        }
    }
}
