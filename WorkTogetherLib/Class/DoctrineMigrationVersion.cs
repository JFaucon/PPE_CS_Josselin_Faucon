using System;

namespace WorkTogetherLib.Class
{
    /// <summary>
    /// Représente une version de migration dans le cadre de la doctrine de migration.
    /// </summary>
    public partial class DoctrineMigrationVersion
    {
        /// <summary>
        /// Obtient ou définit la version de la migration.
        /// </summary>
        public string Version { get; set; } = null!;

        /// <summary>
        /// Obtient ou définit la date et l'heure d'exécution de la migration.
        /// </summary>
        public DateTime? ExecutedAt { get; set; }

        /// <summary>
        /// Obtient ou définit le temps d'exécution de la migration.
        /// </summary>
        public int? ExecutionTime { get; set; }
    }
}
