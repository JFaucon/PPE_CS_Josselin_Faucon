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
    /// Logique d'interaction pour BaieView.xaml
    /// </summary>
    public partial class BaieView : UserControl
    {
        public BaieView()
        {
            InitializeComponent();
            this.DataContext = new BaieViewModel();
        }
        private void AddBaie_Click(object sender, RoutedEventArgs e)
        {
            ((BaieViewModel)this.DataContext).AddBaie();
        }
        private void DeleteBaie_Click(object sender, RoutedEventArgs e)
        {
            ((BaieViewModel)this.DataContext).DeleteBaie();
        }
    }
}
