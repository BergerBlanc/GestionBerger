using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBerger.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnimal { get; set; }
        public string DossierAnimal { get; set; }
        public string Espece {  get; set; }
        public string Race { get; set; }
        public string Couleur { get; set; }
        public string Sexe { get; set; }
        public string Age { get; set; }
        public string NomAnimal {  get; set; }
        public string Medaille { get; set; }
        public string Micropuce { get; set; }
        public string EtatSante { get; set; }
        public string Comportement { get; set; }
        public string Commentaires { get; set; }
    }
}
