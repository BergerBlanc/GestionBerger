using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionBerger.Controllers
{
    public class CitoyenController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;

        public CitoyenController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Citoyen> listeCitoyens;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllCitoyens";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeCitoyens = new List<Citoyen>();

            while (reader.Read())
            {
                Citoyen citoyen = new Citoyen();
                citoyen.IdCitoyen = reader.GetInt32("IdCitoyen");

                citoyen.NomCitoyen = reader.GetString("NomCitoyen");
                citoyen.Telephone = reader.GetString("Telephone");
                citoyen.Telephone2 = reader.GetString("Telephone2");
                citoyen.Civique = reader.GetString("Civique");
                citoyen.Rue = reader.GetString("Rue");
                citoyen.Ville = reader.GetString("Ville");
                citoyen.CodePostal = reader.GetString("CodePostal");
                citoyen.Commentaires = reader.GetString("Commentaires");

                listeCitoyens.Add(citoyen);
            }

            conn.Close();
            return View(listeCitoyens);

        }

        // GET: CitoyenController/Details/5
        public ActionResult Details(int IdCitoyen)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Citoyen citoyen = new Citoyen();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCitoyenById";
            cmd.Parameters.Add(new SqlParameter("@IdCitoyen", IdCitoyen));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                
                citoyen.IdCitoyen = reader.GetInt32("IdCitoyen");
                citoyen.Telephone = reader.GetString("Telephone");
                citoyen.Telephone2 = reader.GetString("Telephone2");
                citoyen.NomCitoyen = reader.GetString("NomCitoyen");
                citoyen.Civique = reader.GetString("Civique");
                citoyen.Rue = reader.GetString("Rue");
                citoyen.Ville = reader.GetString("Ville");
                citoyen.CodePostal = reader.GetString("CodePostal");

                citoyen.Commentaires = reader.GetString("Commentaires");
                
            }

            conn.Close();
            return View(citoyen);
        }

        // GET: CitoyenController/Create
        public ActionResult Create()
        {
            List<string> listeRues = new List<string>();
            connectionString = configuration.GetConnectionString("defaultConnection");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllRuesMascouche", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string rueComplete = reader.GetString(0); // Assurez-vous que la première colonne contient la rue concaténée
                    listeRues.Add(rueComplete);
                }
                conn.Close();
            }

            ViewBag.ListeRues = new SelectList(listeRues);
            Citoyen citoyen = new Citoyen();
            return View(citoyen);
        }

        // POST: CitoyenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Citoyen citoyen)
        {
            
                // TODO: Add insert logic here
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertCitoyen";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomCitoyen", citoyen.NomCitoyen));
                cmd.Parameters.Add(new SqlParameter("@Telephone", citoyen.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Telephone2", citoyen.Telephone2));
                cmd.Parameters.Add(new SqlParameter("@Ville", citoyen.Ville));
                cmd.Parameters.Add(new SqlParameter("@Civique", citoyen.Civique));
                cmd.Parameters.Add(new SqlParameter("@Rue", citoyen.Rue));
                cmd.Parameters.Add(new SqlParameter("@CodePostal", citoyen.CodePostal));
                cmd.Parameters.Add(new SqlParameter("@Commentaires", citoyen.Commentaires));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            
        }

        // GET: CitoyenController/Edit/5
        public ActionResult Edit(int IdCitoyen)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Citoyen citoyen = new Citoyen();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCitoyenById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdCitoyen", IdCitoyen));

            conn.Open();
            reader = cmd.ExecuteReader();
            

            if (reader.Read())
            {
                
                citoyen.IdCitoyen = reader.GetInt32("IdCitoyen");
                citoyen.Telephone = reader.GetString("Telephone");
                citoyen.Telephone2 = reader.GetString("Telephone2");
                citoyen.NomCitoyen = reader.GetString("NomCitoyen");
                citoyen.Civique = reader.GetString("Civique");
                citoyen.Rue = reader.GetString("Rue");
                citoyen.Ville = reader.GetString("Ville");
                citoyen.CodePostal = reader.GetString("CodePostal");

                citoyen.Commentaires = reader.GetString("Commentaires");
                
            }

            conn.Close();
            return View(citoyen);
        }

        // POST: CitoyenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdCitoyen, Citoyen citoyen)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCitoyen";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdCitoyen", IdCitoyen));
                cmd.Parameters.Add(new SqlParameter("@Telephone", citoyen.Telephone));
                cmd.Parameters.Add(new SqlParameter("@Telephone2", citoyen.Telephone2));
                cmd.Parameters.Add(new SqlParameter("@NomCitoyen", citoyen.NomCitoyen));
                cmd.Parameters.Add(new SqlParameter("@Civique", citoyen.Civique));
                cmd.Parameters.Add(new SqlParameter("@Rue", citoyen.Rue));
                cmd.Parameters.Add(new SqlParameter("@Ville", citoyen.Ville));
                cmd.Parameters.Add(new SqlParameter("@CodePostal", citoyen.CodePostal));
                cmd.Parameters.Add(new SqlParameter("@Commentaires", citoyen.Commentaires));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(citoyen);
            }
        }


        // GET: CitoyenController/Delete/5
        public ActionResult Delete(int IdCitoyen)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Citoyen citoyen = new Citoyen();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCitoyenById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdCitoyen", IdCitoyen));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                citoyen.IdCitoyen = reader.GetInt32("IdCitoyen");
                citoyen.Telephone = reader.GetString("Telephone");
                citoyen.Telephone2 = reader.GetString("Telephone2");
                citoyen.NomCitoyen = reader.GetString("NomCitoyen");
                citoyen.Civique = reader.GetString("Civique");
                citoyen.Rue = reader.GetString("Rue");
                citoyen.Ville = reader.GetString("Ville");
                citoyen.CodePostal = reader.GetString("CodePostal");

                citoyen.Commentaires = reader.GetString("Commentaires");

            }

            conn.Close();
            return View(citoyen);
        }

        // POST: CitoyenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdCitoyen, Citoyen citoyen)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteCitoyen";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdCitoyen", IdCitoyen));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(citoyen);
            }
        }
    }
}
