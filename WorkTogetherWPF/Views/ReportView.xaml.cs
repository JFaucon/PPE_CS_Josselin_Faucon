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
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ReportView"/>.
        /// </summary>
        public ReportView()
        {
            InitializeComponent();
            this.DataContext = new ReportViewModel();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Supprimer".
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ((ReportViewModel)this.DataContext).DeleteReport();
        }
    }
}
