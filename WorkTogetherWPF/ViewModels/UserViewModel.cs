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
    /// ViewModel pour la gestion des Utilisateurs.
    /// </summary>
    class UserViewModel
    {
        // Collection observable des Utilisateurs
        public ObservableCollection<User> Users { get; set; }

        // Utilisateur sélectionné
        public User SelectedUser { get => _SelectedUser; set => _SelectedUser = value; }
        private User _SelectedUser;

        /// <summary>
        /// Constructeur du ViewModel User.
        /// Initialise la collection des Utilisateurs à partir de la base de données.
        /// </summary>
        public UserViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Chargement des Utilisateurs depuis la base de données avec les réservations (Reservations) et les rapports (Reports) associés
                this.Users = new ObservableCollection<User>(context.Users.Include(u => u.Reservations).Include(u => u.Reports));
            }
        }

        /// <summary>
        /// Ajoute un client en affichant une fenêtre de dialogue.
        /// </summary>
        public void AddClient()
        {
            // Affichage de la fenêtre de dialogue pour ajouter un client
            WindowAddClient addClient = new WindowAddClient();
            addClient.ShowDialog();

            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Création d'un nouvel utilisateur de type client
                User user = new User();
                user.LastName = addClient.LastName;
                user.FirstName = addClient.FirstName;
                user.Email = addClient.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(addClient.Password, BCrypt.Net.BCrypt.GenerateSalt(13));
                user.Password = user.Password.Replace("$2a$13$", "$2y$13$");
                user.Roles = "[\"ROLE_CLIENT\"]";
                user.Discr = "client";

                // Ajout de l'utilisateur à la collection observable et à la base de données
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Ajoute un comptable en affichant une fenêtre de dialogue.
        /// </summary>
        public void AddComptable()
        {
            // Affichage de la fenêtre de dialogue pour ajouter un comptable
            WindowAddComptable addComptable = new WindowAddComptable();
            addComptable.ShowDialog();

            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Création d'un nouvel utilisateur de type comptable
                User user = new User();
                user.Email = addComptable.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(addComptable.Password, BCrypt.Net.BCrypt.GenerateSalt(13));
                user.Password = user.Password.Replace("$2a$13$", "$2y$13$");
                user.Roles = "[\"ROLE_COMPTABLE\"]";
                user.Discr = "comptable";

                // Ajout de l'utilisateur à la collection observable et à la base de données
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Ajoute un administrateur en affichant une fenêtre de dialogue.
        /// </summary>
        public void AddAdmin()
        {
            // Affichage de la fenêtre de dialogue pour ajouter un administrateur
            WindowAddAdmin addAdmin = new WindowAddAdmin();
            addAdmin.ShowDialog();

            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                // Création d'un nouvel utilisateur de type administrateur
                User user = new User();
                user.Email = addAdmin.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(addAdmin.Password, BCrypt.Net.BCrypt.GenerateSalt(13));
                user.Password = user.Password.Replace("$2a$13$", "$2y$13$");
                user.Roles = "[\"ROLE_ADMIN\"]";
                user.Discr = "admin";

                // Ajout de l'utilisateur à la collection observable et à la base de données
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Supprime l'Utilisateur sélectionné de la base de données et de la collection observable.
        /// </summary>
        public void DeleteUser()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedUser != null && SelectedUser.Reservations.Count > 0)
                {
                    // Supprime les rapports associés à l'utilisateur
                    SelectedUser.Reports.ToList().ForEach(report => { report.UserrId = null; });

                    // Supprime l'Utilisateur de la base de données
                    context.Users.Remove(SelectedUser);

                    // Supprime l'Utilisateur de la collection observable
                    Users.Remove(SelectedUser);

                    // Enregistre les modifications dans la base de données
                    context.SaveChanges();
                }
            }
        }
    }
}
