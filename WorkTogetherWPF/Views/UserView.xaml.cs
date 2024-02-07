using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkTogetherLib.Class;
using WorkTogetherWPF.ViewModels;
using WorkTogetherWPF.Windows;

namespace WorkTogetherWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="UserView"/>.
        /// </summary>
        public UserView()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "AddClient".
        /// </summary>
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            ((UserViewModel)this.DataContext).AddClient();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "AddComptable".
        /// </summary>
        private void AddComptable_Click(object sender, RoutedEventArgs e)
        {
            ((UserViewModel)this.DataContext).AddComptable();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Delete".
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ((UserViewModel)this.DataContext).DeleteUser();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "AddAdmin".
        /// </summary>
        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            ((UserViewModel)this.DataContext).AddAdmin();
        }
    }
}
