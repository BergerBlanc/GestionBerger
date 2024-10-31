using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBerger.Models
{
    public class Employe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmploye { get; set; }
        public int Matricule {  get; set; }

        public string Nom {  get; set; }
        public string NAS { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public DateOnly DateEmbauche { get; set; }
        public string Departement { get; set; }
        public string LoginEmploye { get; set; }
        public string PasswordEmploye { get; set; }
        public string Commentaires { get; set; }
    }
}
