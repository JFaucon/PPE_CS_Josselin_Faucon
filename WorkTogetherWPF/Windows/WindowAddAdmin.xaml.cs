using System;
using System.Windows;
using WorkTogetherLib.Class;

namespace WorkTogetherWPF.Windows
{
    /// <summary>
    /// Interaction logic for WindowAddAdmin.xaml
    /// </summary>
    public partial class WindowAddAdmin : Window
    {
        /// <summary>
        /// Email de l'administrateur.
        /// </summary>
        private string _Email;

        /// <summary>
        /// Mot de passe de l'administrateur.
        /// </summary>
        private string _Password;

        /// <summary>
        /// Obtient ou définit l'email de l'administrateur.
        /// </summary>
        public string Email { get => _Email; set => _Email = value; }

        /// <summary>
        /// Obtient ou définit le mot de passe de l'administrateur.
        /// </summary>
        public string Password { get => _Password; set => _Password = value; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="WindowAddAdmin"/>.
        /// </summary>
        public WindowAddAdmin()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// Événement déclenché lors de la soumission du formulaire pour ajouter un administrateur.
        /// </summary>
        private void SubmitAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
