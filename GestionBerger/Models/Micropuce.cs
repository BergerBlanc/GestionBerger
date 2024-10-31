using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBerger.Models
{
    public class Micropuce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMicropuce { get; set; }

        [Required]
        public string NumMicropuce { get; set; }
        public string DossierAnimal { get; set; }
        public string NumContrat { get; set; }
        public string Espece {  get; set; }
        public string Race { get; set; }
        public string Couleur { get; set; }
        public string Sexe { get; set; }
        public string Age { get; set; }
        public string NomAnimal {  get; set; }
        public string NomProprietaire { get; set; }
        public string Telephone { get; set; }
        public string Telephone2 { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public DateOnly DateAchat { get; set; }
        public string Commentaires { get; set; }
    }
}
