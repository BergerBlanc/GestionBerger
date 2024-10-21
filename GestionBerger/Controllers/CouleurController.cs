using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionBerger.Controllers
{
    public class CouleurController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;
        

        public CouleurController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Couleur> listeCouleurs;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllCouleurs";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeCouleurs = new List<Couleur>();
            
            while (reader.Read())
            {
                Couleur couleur = new Couleur();

                couleur.IdCouleur = reader.GetInt32("IdCouleur");

                couleur.NomCouleur = reader.GetString("NomCouleur");
                
                listeCouleurs.Add(couleur);
            }

            conn.Close();
            return View(listeCouleurs);

        }


        // GET: CouleurController/Create
        public ActionResult Create()
        {
            Couleur c = new Couleur();
            return View(c);
        }

        // POST: CouleurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Couleur couleur)
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
                cmd.CommandText = "InsertCouleur";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomCouleur", couleur.NomCouleur));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(couleur);
            }
        }

        // GET: CouleurController/Edit/5
        public ActionResult Edit(int IdCouleur)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Couleur couleur = new Couleur();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCouleurById";
            cmd.Parameters.Add(new SqlParameter("@IdCouleur", IdCouleur));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                couleur.IdCouleur = reader.GetInt32("IdCouleur");
                couleur.NomCouleur = reader.GetString("NomCouleur");
                
            }

            conn.Close();
            return View(couleur);
        }

        // POST: CouleurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdCouleur, Couleur couleur)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCouleur";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdCouleur", IdCouleur));
                cmd.Parameters.Add(new SqlParameter("@NomCouleur", couleur.NomCouleur));
                
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(couleur);
            }
        }

        // GET: CouleurController/Delete/5
        public ActionResult Delete(int IdCouleur)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Couleur couleur = new Couleur();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCouleurById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdCouleur", IdCouleur));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                couleur.IdCouleur = reader.GetInt32("IdCouleur");
                couleur.NomCouleur = reader.GetString("NomCouleur");
                
            }

            conn.Close();
            return View(couleur);
        }

        // POST: CouleurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdCouleur, Couleur couleur)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteCouleur";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdCouleur", IdCouleur));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(couleur);
            }
        }
    }
}
