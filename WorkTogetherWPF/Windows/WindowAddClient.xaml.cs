using System;
using System.Windows;
using WorkTogetherLib.Class;

namespace WorkTogetherWPF.Windows
{
    /// <summary>
    /// Interaction logic for WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        /// <summary>
        /// Obtient ou définit le nom de famille du client.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Obtient ou définit le prénom du client.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Obtient ou définit l'email du client.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtient ou définit le mot de passe du client.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="WindowAddClient"/>.
        /// </summary>
        public WindowAddClient()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// Événement déclenché lors de la soumission du formulaire pour ajouter un client.
        /// </summary>
        private void SubmitClient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
