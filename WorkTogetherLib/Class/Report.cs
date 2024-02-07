using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente un rapport dans le système.
    /// </summary>
    public partial class Report
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du rapport.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'utilisateur associé au rapport.
        /// </summary>
        public int? UserrId { get; set; }

        /// <summary>
        /// Obtient ou définit le sujet du rapport.
        /// </summary>
        public string Subject { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit l'objet du rapport.
        /// </summary>
        public string Object { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit l'utilisateur associé au rapport.
        /// </summary>
        public virtual User? Userr { get; set; } = null!;
    }
}
