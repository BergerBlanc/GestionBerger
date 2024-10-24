using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionBerger.Controllers
{
    public class RaceChienController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;


        public RaceChienController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<RaceChien> listeRacesChiens;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllRacesChiens";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeRacesChiens = new List<RaceChien>();

            while (reader.Read())
            {
                RaceChien racechien = new RaceChien();

                racechien.IdRaceChien = reader.GetInt32("IdRaceChien");

                racechien.NomRaceChien = reader.GetString("NomRaceChien");

                listeRacesChiens.Add(racechien);
            }

            conn.Close();
            return View(listeRacesChiens);

        }


        // GET: RaceChienController/Create
        public ActionResult Create()
        {
            RaceChien c = new RaceChien();
            return View(c);
        }

        // POST: RaceChienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(RaceChien racechien)
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
                cmd.CommandText = "InsertRaceChien";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomRaceChien", racechien.NomRaceChien));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(racechien);
            }
        }

        // GET: RaceChienController/Edit/5
        public ActionResult Edit(int IdRaceChien)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            RaceChien racechien = new RaceChien();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRaceChienById";
            cmd.Parameters.Add(new SqlParameter("@IdRaceChien", IdRaceChien));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                racechien.IdRaceChien = reader.GetInt32("IdRaceChien");
                racechien.NomRaceChien = reader.GetString("NomRaceChien");

            }

            conn.Close();
            return View(racechien);
        }

        // POST: RaceChienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdRaceChien, RaceChien racechien)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateRaceChien";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdRaceChien", IdRaceChien));
                cmd.Parameters.Add(new SqlParameter("@NomRaceChien", racechien.NomRaceChien));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(racechien);
            }
        }

        // GET: RaceChienController/Delete/5
        public ActionResult Delete(int IdRaceChien)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            RaceChien racechien = new RaceChien();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRaceChienById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdRaceChien", IdRaceChien));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                racechien.IdRaceChien = reader.GetInt32("IdRaceChien");
                racechien.NomRaceChien = reader.GetString("NomRaceChien");

            }

            conn.Close();
            return View(racechien);
        }

        // POST: RaceChienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdRaceChien, RaceChien racechien)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteRaceChien";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdRaceChien", IdRaceChien));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(racechien);
            }
        }
    }
}
