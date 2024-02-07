using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogetherLib.Class;
using WorkTogetherWPF.Views;
using WorkTogetherWPF.Windows;

namespace WorkTogetherWPF.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des Baies.
    /// </summary>
    class BaieViewModel
    {
        // Collection observable des Baies
        public ObservableCollection<Baie> Baies { get; set; }

        // Baie sélectionnée
        public Baie SelectedBaie { get => _SelectedBaie; set => _SelectedBaie = value; }
        private Baie _SelectedBaie;

        // Compteur d'unités disponibles
        public int CountUniteAvailable { get => _CountUniteAvailable; set => CountUniteAvailable = value; }
        private int _CountUniteAvailable;

        /// <summary>
        /// Constructeur du ViewModel Baie.
        /// Initialise la collection des Baies et le compteur d'unités disponibles.
        /// </summary>
        public BaieViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Chargement des Baies avec leurs Unites et Reservations associées
                this.Baies = new ObservableCollection<Baie>(context.Baies.Include(u => u.Unites).ThenInclude(u => u.Reservation));

                // Calcul du nombre total d'unités disponibles dans toutes les Baies
                _CountUniteAvailable = context.Unites.Count(p => p.Available);
            }
        }

        /// <summary>
        /// Supprime la Baie sélectionnée s'il n'y a aucune réservation associée à ses unités.
        /// </summary>
        internal void DeleteBaie()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedBaie != null && SelectedBaie.Unites.All(u => u.ReservationId == null))
                {
                    // Supprime les unités associées à la Baie
                    context.Unites.RemoveRange(SelectedBaie.Unites);

                    // Supprime la Baie
                    context.Baies.Remove(SelectedBaie);
                    Baies.Remove(SelectedBaie);

                    // Enregistre les modifications dans la base de données
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Ajoute une nouvelle Baie avec ses unités associées.
        /// </summary>
        internal void AddBaie()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                Baie baie = new Baie();
                baie.NbSpot = 42;

                try
                {
                    // Génère le code de la Baie en fonction du dernier code existant
                    baie.Code = "B" + (int.Parse(Baies.Last().Code.Substring(1, 3)) + 1).ToString("D3");
                }
                catch (ArgumentNullException)
                {
                    // Si aucune Baie n'existe, utilise "B001" comme premier code
                    baie.Code = "B001";
                }

                // Ajoute la Baie à la collection observable et au contexte EF
                Baies.Add(baie);
                context.Baies.Add(baie);
                context.SaveChanges();

                // Ajoute 42 unités associées à la nouvelle Baie
                for (int i = 1; i < 43; i++)
                {
                    Unite unite = new Unite();
                    unite.BaieId = baie.Id;
                    unite.Available = false;
                    unite.NumSpot = i.ToString();
                    context.Unites.Add(unite);
                }

                // Enregistre les modifications dans la base de données
                context.SaveChanges();
            }
        }
    }
}
