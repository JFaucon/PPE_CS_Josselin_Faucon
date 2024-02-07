using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente une réservation dans le système.
    /// Implémente l'interface IEditableObject pour la gestion de l'édition.
    /// </summary>
    public partial class Reservation : IEditableObject
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de la réservation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'utilisateur associé à la réservation.
        /// </summary>
        public int UserrId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant du forfait associé à la réservation.
        /// </summary>
        public int ForfaitId { get; set; }

        /// <summary>
        /// Obtient ou définit le numéro associé à la réservation.
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la date de début de la réservation.
        /// </summary>
        public DateOnly BeginDate { get; set; }

        /// <summary>
        /// Obtient ou définit la date de fin de la réservation (nullable).
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Obtient ou définit la quantité associée à la réservation.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Obtient ou définit si la réservation est renouvelable.
        /// </summary>
        public bool Renewable { get; set; }

        /// <summary>
        /// Obtient ou définit le forfait associé à la réservation.
        /// </summary>
        public virtual Forfait Forfait { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la liste des unités associées à la réservation.
        /// </summary>
        public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();

        /// <summary>
        /// Obtient ou définit l'utilisateur associé à la réservation.
        /// </summary>
        public virtual User Userr { get; set; } = null!;

        /// <summary>
        /// Méthode appelée au début de l'édition de la réservation.
        /// </summary>
        public void BeginEdit()
        {
            // Logique d'édition (si nécessaire) peut être ajoutée ici
        }

        /// <summary>
        /// Méthode appelée pour annuler les modifications apportées à la réservation pendant l'édition.
        /// </summary>
        public void CancelEdit()
        {
            // Logique d'annulation d'édition (si nécessaire) peut être ajoutée ici
        }

        /// <summary>
        /// Méthode appelée à la fin de l'édition de la réservation pour sauvegarder les modifications.
        /// </summary>
        public void EndEdit()
        {
            using WorkTogetherContext context = new WorkTogetherContext();
            {
                // Définir l'état de l'entité comme modifié et enregistrer les changements dans la base de données.
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
