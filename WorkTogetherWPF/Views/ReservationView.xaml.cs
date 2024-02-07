using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ReservationView.xaml
    /// </summary>
    public partial class ReservationView : UserControl
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ReservationView"/>.
        /// </summary>
        public ReservationView()
        {
            InitializeComponent();
            this.DataContext = new ReservationViewModel();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton "Exportpdf".
        /// </summary>
        private void Exportpdf_Click(object sender, RoutedEventArgs e)
        {
            ((ReservationViewModel)this.DataContext).ExportToPdf();
            ProcessStartInfo? psi = new ProcessStartInfo();
            psi.FileName = @"c:\windows\explorer.exe";
            psi.Arguments = "C:\\Users\\user-pc\\OneDrive\\Documents\\IIA\\E2\\ppe\\ClientLourd\\WorkTogether\\WorkTogetherWPF\\bin\\Debug\\net8.0-windows";
            Process.Start(psi);
        }
    }
}
