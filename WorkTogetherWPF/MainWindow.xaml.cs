using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkTogetherWPF.Views;
using WorkTogetherWPF.Windows;

namespace WorkTogetherWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            WindowLogin login = new WindowLogin();
            login.ShowDialog();

            if (login.DialogResult == false)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Événement déclenché lors du clic sur l'élément "Utilisateur" du menu.
        /// </summary>
        private void Utilisateur_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new UserView());
        }

        /// <summary>
        /// Événement déclenché lors du clic sur l'élément "Baie" du menu.
        /// </summary>
        private void Baie_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new BaieView());
        }

        /// <summary>
        /// Événement déclenché lors du clic sur l'élément "Report" du menu.
        /// </summary>
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new ReportView());
        }

        /// <summary>
        /// Événement déclenché lors du clic sur l'élément "Forfait" du menu.
        /// </summary>
        private void Forfait_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new ForfaitView());
        }

        /// <summary>
        /// Événement déclenché lors du clic sur l'élément "Reservation" du menu.
        /// </summary>
        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new ReservationView());
        }
    }
}
