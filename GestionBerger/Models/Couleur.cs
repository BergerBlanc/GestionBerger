using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionBerger.Models
{
    public class Couleur
    {
        [Key]  // Indique que cette propriété est la clé primaire.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCouleur { get; set; }
        public string NomCouleur { get; set; }
    }
}
