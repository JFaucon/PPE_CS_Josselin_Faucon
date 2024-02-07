using System;
using System.Collections.ObjectModel;
using System.Linq;
using WorkTogetherLib.Class;
using WorkTogetherWPF.Views;
using WorkTogetherWPF.Windows;

namespace WorkTogetherWPF.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des Rapports (Reports).
    /// </summary>
    class ReportViewModel
    {
        // Collection observable des Rapports
        public ObservableCollection<Report> Reports { get; set; }

        // Rapport sélectionné
        public Report SelectedReport { get => _SelectedReport; set => _SelectedReport = value; }
        private Report _SelectedReport;

        /// <summary>
        /// Constructeur du ViewModel Report.
        /// Initialise la collection des Rapports à partir de la base de données.
        /// </summary>
        public ReportViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Chargement des Rapports depuis la base de données
                this.Reports = new ObservableCollection<Report>(context.Reports);
            }
        }

        /// <summary>
        /// Supprime le Rapport sélectionné de la base de données et de la collection observable.
        /// </summary>
        internal void DeleteReport()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedReport != null)
                {
                    // Supprime le Rapport de la base de données
                    context.Reports.Remove(SelectedReport);

                    // Supprime le Rapport de la collection observable
                    Reports.Remove(SelectedReport);

                    // Enregistre les modifications dans la base de données
                    context.SaveChanges();
                }
            }
        }
    }
}
