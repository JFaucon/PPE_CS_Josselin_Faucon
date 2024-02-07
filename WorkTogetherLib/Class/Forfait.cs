using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente un forfait dans le système.
    /// Implémente l'interface IEditableObject pour la gestion de l'édition.
    /// </summary>
    public partial class Forfait : IEditableObject
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du forfait.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le nom du forfait.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit le prix du forfait.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre de spots inclus dans le forfait.
        /// </summary>
        public int NbSlot { get; set; }

        /// <summary>
        /// Obtient ou définit la remise associée au forfait.
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre de mois du forfait.
        /// </summary>
        public int NbMonth { get; set; }

        /// <summary>
        /// Obtient ou définit le chemin de l'image associée au forfait.
        /// </summary>
        public string ImgPath { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la liste des réservations associées au forfait.
        /// </summary>
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        /// <summary>
        /// Méthode appelée au début de l'édition du forfait.
        /// </summary>
        public void BeginEdit()
        {
            // Logique d'édition (si nécessaire) peut être ajoutée ici
        }

        /// <summary>
        /// Méthode appelée pour annuler les modifications apportées au forfait pendant l'édition.
        /// </summary>
        public void CancelEdit()
        {
            // Logique d'annulation d'édition (si nécessaire) peut être ajoutée ici
        }

        /// <summary>
        /// Méthode appelée à la fin de l'édition du forfait pour sauvegarder les modifications.
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
