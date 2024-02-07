using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente un message du service de messagerie.
    /// </summary>
    public partial class MessengerMessage
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du message.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Obtient ou définit le corps du message.
        /// </summary>
        public string Body { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit les en-têtes du message.
        /// </summary>
        public string Headers { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit le nom de la file associée au message.
        /// </summary>
        public string QueueName { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la date et l'heure de création du message.
        /// (DC2Type:datetime_immutable)
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Obtient ou définit la date et l'heure à laquelle le message est disponible.
        /// (DC2Type:datetime_immutable)
        /// </summary>
        public DateTime AvailableAt { get; set; }

        /// <summary>
        /// Obtient ou définit la date et l'heure de livraison du message.
        /// (DC2Type:datetime_immutable)
        /// </summary>
        public DateTime? DeliveredAt { get; set; }
    }
}
