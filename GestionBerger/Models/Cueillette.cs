using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBerger.Models
{
    public class Cueillette
    {
        [Key]  // Indique que cette propriété est la clé primaire.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCueillette { get; set; }
        public string IdCitoyen { get; set; }
        public DateTime DateHeureRecu {  get; set; }
        public DateOnly DatePrevu { get; set; }
        public string Espece {  get; set; }
        public string Race { get; set; }
        public string Couleur { get; set; }
        public string Sexe { get; set; }
        public string Age { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Intersection { get; set; }
        public string Intervention { get; set; }
        public bool complete { get; set; }
        public DateTime DateHeureFinalise { get; set; }
        public string Commentaires { get; set; }
    }
}
