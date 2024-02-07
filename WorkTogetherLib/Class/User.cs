using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente un utilisateur dans le système.
    /// Implémente l'interface IEditableObject pour la gestion de l'édition.
    /// </summary>
    public partial class User : IEditableObject
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'utilisateur.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit l'adresse e-mail de l'utilisateur.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit les rôles de l'utilisateur (DC2Type:json).
        /// </summary>
        public string Roles { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit le mot de passe de l'utilisateur.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit le prénom de l'utilisateur (nullable).
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de famille de l'utilisateur (nullable).
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Obtient ou définit le discriminant (discriminator) de l'utilisateur.
        /// Il s'agit d'une propriété utilisée dans le cadre de l'héritage de tables.
        /// </summary>
        public string Discr { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit le chemin de l'image de profil de l'utilisateur (nullable).
        /// </summary>
        public string? ProfileImage { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des rapports associés à l'utilisateur.
        /// </summary>
        public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

        /// <summary>
        /// Obtient ou définit la liste des réservations associées à l'utilisateur.
        /// </summary>
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        /// <summary>
        /// Méthode appelée au début de l'édition de l'utilisateur.
        /// </summary>
        public void BeginEdit()
        {
            // Logique d'édition (si nécessaire) peut être ajoutée ici
        }

        /// <summary>
        /// Méthode appelée pour annuler les modifications apportées à l'utilisateur pendant l'édition.
        /// </summary>
        public void CancelEdit()
        {
            // Logique d'annulation d'édition (si nécessaire) peut être ajoutée ici
        }

        /// <summary>
        /// Méthode appelée à la fin de l'édition de l'utilisateur pour sauvegarder les modifications.
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
