using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionBerger.Models
{
    public class RueMascouche
    {
        [Key]  // Indique que cette propriété est la clé primaire.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TypeRue { get; set; }
        public string NomRue { get; set; }
    }
}
