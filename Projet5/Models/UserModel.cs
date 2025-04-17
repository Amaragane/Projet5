using System.ComponentModel.DataAnnotations;

namespace Projet5.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Identifiant")]

        [Required(ErrorMessage = "Le champ Identifiant est requis.")]
        public string Identifiant { get; set; }
        [Required(ErrorMessage = "Le champ Mot de passe est requis.")]
        [Display(Name = "Mot de passe")]

        public string MotDePasse { get; set; }
        public bool EstAdministateur { get; set; }
    }
}
