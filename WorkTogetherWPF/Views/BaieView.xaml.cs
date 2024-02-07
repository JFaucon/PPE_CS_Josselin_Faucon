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
using WorkTogetherWPF.ViewModels;

namespace WorkTogetherWPF.Views
{
    /// <summary>
    /// Interaction logic for BaieView.xaml
    /// </summary>
    public partial class BaieView : UserControl
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BaieView"/>.
        /// </summary>
        public BaieView()
        {
            InitializeComponent();
            this.DataContext = new BaieViewModel();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Ajouter Baie".
        /// </summary>
        private void AddBaie_Click(object sender, RoutedEventArgs e)
        {
            ((BaieViewModel)this.DataContext).AddBaie();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer Baie".
        /// </summary>
        private void DeleteBaie_Click(object sender, RoutedEventArgs e)
        {
            ((BaieViewModel)this.DataContext).DeleteBaie();
        }
    }
}
