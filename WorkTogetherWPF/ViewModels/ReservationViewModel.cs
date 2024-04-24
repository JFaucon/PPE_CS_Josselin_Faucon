using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WorkTogetherLib.Class;
using WorkTogetherWPF.Views;
using WorkTogetherWPF.Windows;

namespace WorkTogetherWPF.ViewModels
{
    /// <summary>
    /// ViewModel pour la gestion des Réservations.
    /// </summary>
    class ReservationViewModel
    {
        // Collection observable des Réservations
        public ObservableCollection<Reservation> Reservations { get; set; }

        // Réservation sélectionnée
        public Reservation SelectedReservation { get => _SelectedReservation; set => _SelectedReservation = value; }
        private Reservation _SelectedReservation;

        /// <summary>
        /// Constructeur du ViewModel Reservation.
        /// Initialise la collection des Réservations à partir de la base de données.
        /// </summary>
        public ReservationViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Chargement des Réservations depuis la base de données avec les utilisateurs (Userr) et les forfaits (Forfait) associés
                this.Reservations = new ObservableCollection<Reservation>(context.Reservations.Include(p => p.Userr).Include(p => p.Forfait));
            }
        }

        /// <summary>
        /// Exporte la liste des réservations au format PDF.
        /// </summary>
        internal void ExportToPdf()
        {
            // Construction du contenu du document PDF
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine("Liste des réservations : " + Environment.NewLine);

            foreach (Reservation resa in this.Reservations)
            {
                stringBuilder.AppendLine("Code : " + resa.Number + " - Prix : " + resa.Forfait.Price * resa.Quantity /100 + "€ - Nom du pack : " + resa.Forfait.Name);
            }

            // Création du fichier PDF
            System.IO.FileStream fs = new FileStream("reservation.pdf", FileMode.Create);
            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            // Ouverture du document PDF
            document.Open();

            // Ajout du contenu au document PDF
            document.Add(new iTextSharp.text.Paragraph(stringBuilder.ToString()));

            // Fermeture du document PDF
            document.Close();

            // Fermeture de l'instance du rédacteur
            writer.Close();

            // Fermeture du descripteur de fichier
            fs.Close();
        }
    }
}
