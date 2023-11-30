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

        private void Utilisateur_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new UserView());
        }

        private void Baie_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new BaieView());
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new ReportView());
        }

        private void Forfait_Click(object sender, RoutedEventArgs e)
        {
            DockPanel.Children.Clear();
            DockPanel.Children.Add(new ForfaitView());
        }
    }
}