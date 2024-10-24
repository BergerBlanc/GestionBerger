using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionBerger.Controllers
{
    public class EtatSanteController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;


        public EtatSanteController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<EtatSante> listeEtatSantes;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllEtatsSante";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeEtatSantes = new List<EtatSante>();

            while (reader.Read())
            {
                EtatSante etatsante = new EtatSante();

                etatsante.IdEtatSante = reader.GetInt32("IdEtatSante");

                etatsante.NomEtatSante = reader.GetString("NomEtatSante");

                listeEtatSantes.Add(etatsante);
            }

            conn.Close();
            return View(listeEtatSantes);

        }


        // GET: EtatSanteController/Create
        public ActionResult Create()
        {
            EtatSante c = new EtatSante();
            return View(c);
        }

        // POST: EtatSanteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(EtatSante etatsante)
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
                cmd.CommandText = "InsertEtatSante";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomEtatSante", etatsante.NomEtatSante));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(etatsante);
            }
        }

        // GET: EtatSanteController/Edit/5
        public ActionResult Edit(int IdEtatSante)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            EtatSante etatsante = new EtatSante();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEtatSanteById";
            cmd.Parameters.Add(new SqlParameter("@IdEtatSante", IdEtatSante));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                etatsante.IdEtatSante = reader.GetInt32("IdEtatSante");
                etatsante.NomEtatSante = reader.GetString("NomEtatSante");

            }

            conn.Close();
            return View(etatsante);
        }

        // POST: EtatSanteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdEtatSante, EtatSante etatsante)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEtatSante";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdEtatSante", IdEtatSante));
                cmd.Parameters.Add(new SqlParameter("@NomEtatSante", etatsante.NomEtatSante));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(etatsante);
            }
        }

        // GET: EtatSanteController/Delete/5
        public ActionResult Delete(int IdEtatSante)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            EtatSante etatsante = new EtatSante();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEtatSanteById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdEtatSante", IdEtatSante));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                etatsante.IdEtatSante = reader.GetInt32("IdEtatSante");
                etatsante.NomEtatSante = reader.GetString("NomEtatSante");

            }

            conn.Close();
            return View(etatsante);
        }

        // POST: EtatSanteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdEtatSante, EtatSante etatsante)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEtatSante";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdEtatSante", IdEtatSante));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(etatsante);
            }
        }
    }
}
