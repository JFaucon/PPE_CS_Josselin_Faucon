using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente une baie dans le système.
    /// </summary>
    public partial class Baie
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique de la baie.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le nombre de spots dans la baie.
        /// </summary>
        public int NbSpot { get; set; }

        /// <summary>
        /// Obtient ou définit le code associé à la baie.
        /// </summary>
        public string Code { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la liste des unités associées à la baie.
        /// </summary>
        public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
    }
}
