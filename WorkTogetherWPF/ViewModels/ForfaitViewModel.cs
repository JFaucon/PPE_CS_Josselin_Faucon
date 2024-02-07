using System;
using System.Collections.ObjectModel;
using System.Linq;
using WorkTogetherLib.Class;
using WorkTogetherWPF.Views;
using WorkTogetherWPF.Windows;

namespace WorkTogetherWPF.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des Forfaits.
    /// </summary>
    class ForfaitViewModel
    {
        // Collection observable des Forfaits
        public ObservableCollection<Forfait> Forfaits { get; set; }

        // Forfait sélectionné
        public Forfait SelectedForfait { get => _SelectedForfait; set => _SelectedForfait = value; }
        private Forfait _SelectedForfait;

        /// <summary>
        /// Constructeur du ViewModel Forfait.
        /// Initialise la collection des Forfaits à partir de la base de données.
        /// </summary>
        public ForfaitViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Chargement des Forfaits depuis la base de données
                this.Forfaits = new ObservableCollection<Forfait>(context.Forfaits);
            }
        }
    }
}
