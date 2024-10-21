using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBerger.Models
{
    public class Employe
    {
        [Key]
        public int matricule {  get; set; }

        public string Nom {  get; set; }
        public string NAS { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public DateOnly DateEmbauche { get; set; }
        public string Departement { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Commentaires { get; set; }
    }
}
