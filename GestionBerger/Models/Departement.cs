using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionBerger.Models
{
    public class Departement
    {
        [Key]  // Indique que cette propriété est la clé primaire.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDepartement { get; set; }
        public string NomDepartement { get; set; }
    }
}
