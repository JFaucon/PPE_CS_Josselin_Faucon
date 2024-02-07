using System;
using System.Windows;
using WorkTogetherLib.Class;

namespace WorkTogetherWPF.Windows
{
    /// <summary>
    /// Interaction logic for WindowAddComptable.xaml
    /// </summary>
    public partial class WindowAddComptable : Window
    {
        /// <summary>
        /// Obtient ou définit l'email du comptable.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtient ou définit le mot de passe du comptable.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="WindowAddComptable"/>.
        /// </summary>
        public WindowAddComptable()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// Événement déclenché lors de la soumission du formulaire pour ajouter un comptable.
        /// </summary>
        private void SubmitComptable_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
