using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBerger.Models
{
    public class Citoyen
    {
        [Key]  // Indique que cette propriété est la clé primaire.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCitoyen { get; set; }
        public string NomCitoyen { get; set; }
        public string Telephone { get; set; }
        public string Telephone2 { get; set; }
        public string Ville { get; set; }
        public string Civique { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Commentaires { get; set; }
        
    }
}
