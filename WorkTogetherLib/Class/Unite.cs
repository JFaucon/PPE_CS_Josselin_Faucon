using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente une unité dans le système.
    /// </summary>
    public partial class Unite
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de l'unité.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la baie associée à l'unité.
        /// </summary>
        public int BaieId { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la réservation associée à l'unité (nullable).
        /// </summary>
        public int? ReservationId { get; set; }

        /// <summary>
        /// Obtient ou définit le numéro associé à l'unité.
        /// </summary>
        public string NumSpot { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit si l'unité est disponible.
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Obtient ou définit la baie associée à l'unité.
        /// </summary>
        public virtual Baie Baie { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la réservation associée à l'unité (nullable).
        /// </summary>
        public virtual Reservation? Reservation { get; set; }
    }
}
