using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionBerger.Models
{
    public class RaceChien
    {
        [Key]  // Indique que cette propriété est la clé primaire.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRaceChien { get; set; }
        public string NomRaceChien { get; set; }
    }
}
