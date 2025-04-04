using System.ComponentModel.DataAnnotations;

namespace Projet5.Models
{
    public class VoitureModel
    {
        [Key]
        public int Vin { get; set; }
        [Required(ErrorMessage = "Le champ Marque est requis.")]
        public string Marque { get; set; } = null!;
        public string Modele { get; set; } = null!;
        public int AnneeModel { get; set; }
        public string Finition { get; set; }= null!;
        [Display(Name = "Date d'achat")]
        public DateOnly DateAchat { get; set; }
        public DateOnly DateDisponibilité { get; set; }
        public int PrixAchat { get; set; }
        public int CoutReparation { get; set; }
        
        public bool EstDisponible { get; set; }
        public string ImageUrl { get; set; }

        // Autres propriétés spécifiques à votre modèle de voiture
    }
}
