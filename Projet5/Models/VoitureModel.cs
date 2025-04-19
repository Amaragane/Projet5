using System.ComponentModel.DataAnnotations;

namespace Projet5.Models
{
    public class VoitureModel
    {
        [Key]
        public int Vin { get; set; }

        [Required(ErrorMessage = "Le champ Marque est requis.")]
        public string Marque { get; set; } = null!;

        [Required(ErrorMessage = "Le champ Modele est requis.")]
        public string Modele { get; set; } = null!;
        [CustomRange(1980)]
        [Display(Name = "Année du modele")]
        [Required(ErrorMessage = "Le champ Année du modele est requis.")]
        public int AnneeModel { get; set; }

        [Required(ErrorMessage = "Le champ Finition est requis.")]
        public string Finition { get; set; } = null!;

        [Display(Name = "Date d'achat")]
        [Required(ErrorMessage = "Le champ Date d'achat est requis.")]
        public DateOnly DateAchat { get; set; }

        [Display(Name = "Date de disponibilité")]
        [Required(ErrorMessage = "Le champ date de disponibilité est requis.")]
        public DateOnly DateDisponibilité { get; set; }

        [Required(ErrorMessage = "Le champ prix d'achat est requis.")]
        [Display(Name = "Prix d'achat")]
        public int PrixAchat { get; set; }


        [Display(Name = "Réparation")]
        [Required(ErrorMessage = "Le champ des réparation est requis.")]
        public string Reparation { get; set; } = null!;

        [Display(Name = "Cout des répaaration")]
        [Required(ErrorMessage = "Le champ Cout des réparation est requis.")]
        public int CoutReparation { get; set; }

        [Display(Name = "Disponibilité")]
        [Required(ErrorMessage = "La disponibilité est requise.")]
        public bool EstDisponible { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "L'image est requise.")]
        public string? ImageUrl { get; set; }

        // Autres propriétés spécifiques à votre modèle de voiture
    }
    public class CustomRangeAttribute(int minimum) : RangeAttribute(minimum, DateTime.Now.Year)
    {

    }
}

