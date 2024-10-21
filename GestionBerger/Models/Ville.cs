using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionBerger.Models
{
    public class Ville
    {
        [Key]  // Indique que cette propriété est la clé primaire.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVille { get; set; }
        public string NomVille { get; set; }
        public string Contact { get; set; }
        public string Telephone { get; set; }
        public string Commentaires { get; set; }
    }
}
