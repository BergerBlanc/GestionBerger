using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionBerger.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionBerger.Controllers
{
    public class RaceChatController : Controller
    {
        public IConfiguration configuration;
        private string connectionString;


        public RaceChatController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // GET: StoredProcController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<RaceChat> listeRacesChats;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllRacesChats";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeRacesChats = new List<RaceChat>();

            while (reader.Read())
            {
                RaceChat racechat = new RaceChat();

                racechat.IdRaceChat = reader.GetInt32("IdRaceChat");

                racechat.NomRaceChat = reader.GetString("NomRaceChat");

                listeRacesChats.Add(racechat);
            }

            conn.Close();
            return View(listeRacesChats);

        }


        // GET: RaceChatController/Create
        public ActionResult Create()
        {
            RaceChat c = new RaceChat();
            return View(c);
        }

        // POST: RaceChatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(RaceChat racechat)
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
                cmd.CommandText = "InsertRaceChat";

                // Ajout des paramètres à la commande
                cmd.Parameters.Add(new SqlParameter("@NomRaceChat", racechat.NomRaceChat));
                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(racechat);
            }
        }

        // GET: RaceChatController/Edit/5
        public ActionResult Edit(int IdRaceChat)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            RaceChat racechat = new RaceChat();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRaceChatById";
            cmd.Parameters.Add(new SqlParameter("@IdRaceChat", IdRaceChat));

            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                racechat.IdRaceChat = reader.GetInt32("IdRaceChat");
                racechat.NomRaceChat = reader.GetString("NomRaceChat");

            }

            conn.Close();
            return View(racechat);
        }

        // POST: RaceChatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int IdRaceChat, RaceChat racechat)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateRaceChat";

                // Ajout des paramètres à la commande

                cmd.Parameters.Add(new SqlParameter("@IdRaceChat", IdRaceChat));
                cmd.Parameters.Add(new SqlParameter("@NomRaceChat", racechat.NomRaceChat));

                cmd.Connection = conn;

                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(racechat);
            }
        }

        // GET: RaceChatController/Delete/5
        public ActionResult Delete(int IdRaceChat)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            RaceChat racechat = new RaceChat();

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRaceChatById";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("@IdRaceChat", IdRaceChat));

            conn.Open();
            reader = cmd.ExecuteReader();


            if (reader.Read())
            {

                racechat.IdRaceChat = reader.GetInt32("IdRaceChat");
                racechat.NomRaceChat = reader.GetString("NomRaceChat");

            }

            conn.Close();
            return View(racechat);
        }

        // POST: RaceChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int IdRaceChat, RaceChat racechat)
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;

                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteRaceChat";  // Supposant que cette procédure stockée existe pour la suppression
                cmd.Parameters.Add(new SqlParameter("@IdRaceChat", IdRaceChat));
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(racechat);
            }
        }
    }
}
