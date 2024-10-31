using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionBerger.Controllers
{
    public class AnimalController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;

        public AnimalController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Animal> listeAnimals;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllAnimaux";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeAnimals = new List<Animal>();

            while (reader.Read())
            {
                Animal animal = new Animal();
                animal.IdAnimal = reader.GetInt32("IdAnimal");

                animal.NomAnimal = reader.GetString("NomAnimal");
                
                animal.Commentaires = reader.GetString("Commentaires");

                listeAnimals.Add(animal);
            }

            conn.Close();
            return View(listeAnimals);

        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int IdAnimal)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Animal animal = new Animal();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAnimalById";
            cmd.Parameters.Add(new SqlParameter("@IdAnimal", IdAnimal));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                animal.IdAnimal = reader.GetInt32("IdAnimal");
                //animal.Telephone = reader.GetString("Telephone");
                //animal.Telephone2 = reader.GetString("Telephone2");
                //animal.NomAnimal = reader.GetString("NomAnimal");
                //animal.Civique = reader.GetString("Civique");
                //animal.Rue = reader.GetString("Rue");
                //animal.Ville = reader.GetString("Ville");
                //animal.CodePostal = reader.GetString("CodePostal");

                animal.Commentaires = reader.GetString("Commentaires");

            }

            conn.Close();
            return View(animal);
        }

        // GET: AnimalController/Create
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
            Animal animal = new Animal();
            return View(animal);
        }

        // POST: AnimalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Animal animal)
        {

            // TODO: Add insert logic here
            SqlConnection conn;
            SqlCommand cmd;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertAnimal";

            // Ajout des paramètres à la commande
            cmd.Parameters.Add(new SqlParameter("@NomAnimal", animal.NomAnimal));
            //cmd.Parameters.Add(new SqlParameter("@Telephone", animal.Telephone));
            //cmd.Parameters.Add(new SqlParameter("@Telephone2", animal.Telephone2));
            //cmd.Parameters.Add(new SqlParameter("@Ville", animal.Ville));
            //cmd.Parameters.Add(new SqlParameter("@Civique", animal.Civique));
            //cmd.Parameters.Add(new SqlParameter("@Rue", animal.Rue));
            //cmd.Parameters.Add(new SqlParameter("@CodePostal", animal.CodePostal));
            cmd.Parameters.Add(new SqlParameter("@Commentaires", animal.Commentaires));

            cmd.Connection = conn;

            conn.Open();
            int rowCount = cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction(nameof(Index));

        }

        // GET: AnimalController/Edit/5
        public ActionResult Edit(int IdAnimal)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Animal animal = new Animal();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAnimalById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdAnimal", IdAnimal));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                animal.IdAnimal = reader.GetInt32("IdAnimal");
                //animal.Telephone = reader.GetString("Telephone");
                //animal.Telephone2 = reader.GetString("Telephone2");
                //animal.NomAnimal = reader.GetString("NomAnimal");
                //animal.Civique = reader.GetString("Civique");
                //animal.Rue = reader.GetString("Rue");
                //animal.Ville = reader.GetString("Ville");
                //animal.CodePostal = reader.GetString("CodePostal");

                animal.Commentaires = reader.GetString("Commentaires");

            }

            conn.Close();
            return View(animal);
        }

        // POST: AnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdAnimal, Animal animal)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAnimal";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdAnimal", IdAnimal));
                //cmd.Parameters.Add(new SqlParameter("@Telephone", animal.Telephone));
                //cmd.Parameters.Add(new SqlParameter("@Telephone2", animal.Telephone2));
                //cmd.Parameters.Add(new SqlParameter("@NomAnimal", animal.NomAnimal));
                //cmd.Parameters.Add(new SqlParameter("@Civique", animal.Civique));
                //cmd.Parameters.Add(new SqlParameter("@Rue", animal.Rue));
                //cmd.Parameters.Add(new SqlParameter("@Ville", animal.Ville));
                //cmd.Parameters.Add(new SqlParameter("@CodePostal", animal.CodePostal));
                cmd.Parameters.Add(new SqlParameter("@Commentaires", animal.Commentaires));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(animal);
            }
        }


        // GET: AnimalController/Delete/5
        public ActionResult Delete(int IdAnimal)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Animal animal = new Animal();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAnimalById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdAnimal", IdAnimal));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                animal.IdAnimal = reader.GetInt32("IdAnimal");
                //animal.Telephone = reader.GetString("Telephone");
                //animal.Telephone2 = reader.GetString("Telephone2");
                //animal.NomAnimal = reader.GetString("NomAnimal");
                //animal.Civique = reader.GetString("Civique");
                //animal.Rue = reader.GetString("Rue");
                //animal.Ville = reader.GetString("Ville");
                //animal.CodePostal = reader.GetString("CodePostal");

                animal.Commentaires = reader.GetString("Commentaires");

            }

            conn.Close();
            return View(animal);
        }

        // POST: AnimalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdAnimal, Animal animal)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteAnimal";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdAnimal", IdAnimal));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(animal);
            }
        }
    }
}
