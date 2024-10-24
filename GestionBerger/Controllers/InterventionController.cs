using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionBerger.Controllers
{
    public class InterventionController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;


        public InterventionController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Intervention> listeInterventions;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllInterventions";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeInterventions = new List<Intervention>();

            while (reader.Read())
            {
                Intervention intervention = new Intervention();

                intervention.IdIntervention = reader.GetInt32("IdIntervention");

                intervention.NomIntervention = reader.GetString("NomIntervention");

                listeInterventions.Add(intervention);
            }

            conn.Close();
            return View(listeInterventions);

        }


        // GET: InterventionController/Create
        public ActionResult Create()
        {
            Intervention c = new Intervention();
            return View(c);
        }

        // POST: InterventionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Intervention intervention)
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
                cmd.CommandText = "InsertIntervention";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomIntervention", intervention.NomIntervention));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(intervention);
            }
        }

        // GET: InterventionController/Edit/5
        public ActionResult Edit(int IdIntervention)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Intervention intervention = new Intervention();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInterventionById";
            cmd.Parameters.Add(new SqlParameter("@IdIntervention", IdIntervention));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                intervention.IdIntervention = reader.GetInt32("IdIntervention");
                intervention.NomIntervention = reader.GetString("NomIntervention");

            }

            conn.Close();
            return View(intervention);
        }

        // POST: InterventionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdIntervention, Intervention intervention)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateIntervention";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdIntervention", IdIntervention));
                cmd.Parameters.Add(new SqlParameter("@NomIntervention", intervention.NomIntervention));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(intervention);
            }
        }

        // GET: InterventionController/Delete/5
        public ActionResult Delete(int IdIntervention)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Intervention intervention = new Intervention();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInterventionById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdIntervention", IdIntervention));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                intervention.IdIntervention = reader.GetInt32("IdIntervention");
                intervention.NomIntervention = reader.GetString("NomIntervention");

            }

            conn.Close();
            return View(intervention);
        }

        // POST: InterventionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdIntervention, Intervention intervention)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteIntervention";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdIntervention", IdIntervention));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(intervention);
            }
        }
    }
}
