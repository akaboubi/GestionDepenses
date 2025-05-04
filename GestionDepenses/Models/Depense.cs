using System.ComponentModel.DataAnnotations;

namespace GestionDepenses.Models
{
    /// <summary>
    /// Représente une dépense réalisée.
    /// </summary>
    public class Depense
    {
        /// <summary>
        /// Identifiant unique de la dépense (généré automatiquement).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Montant de la dépense. Doit être supérieur à 0.
        /// </summary
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à 0.")]
        public decimal Montant { get; set; }

        /// <summary>
        /// C'est la Date à laquelle la dépense a été faite.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Commentaire (non obligatoire) de la dépense (max. 100 caractères).
        /// </summary>
        [MaxLength(100)]
        public string Commentaire { get; set; }

        /// <summary>
        /// Nature de la dépense (Déplacement ou Restaurant).
        /// </summary>
        [Required]
        [EnumDataType(typeof(NatureDepense))]
        public NatureDepense Nature { get; set; }

        /// <summary>
        /// Distance parcourue en kilomètres pour un déplacement. Doit être supérieure à 0.
        /// </summary>     
        public int? Distance { get; set; }

        /// <summary>
        /// Nombre d'invités concernés par la dépense (0 ou plus).
        /// </summary>
        public int? NombreInvites { get; set; }
    }

    /// <summary>
    /// Représente les différentes natures de dépense
    /// </summary>
    public enum NatureDepense
    {
        /// <summary>Dépense pour un déplacement.</summary>
        Deplacement = 0,

        /// <summary>Dépense pour un restaurant.</summary>
        Restaurant = 1
    }
}
