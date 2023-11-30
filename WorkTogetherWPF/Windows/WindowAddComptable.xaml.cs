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
using System.Windows.Shapes;
using WorkTogetherLib.Class;

namespace WorkTogetherWPF.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowAddComptable.xaml
    /// </summary>
    public partial class WindowAddComptable : Window
    {
        private string _Email;

        private string _Password;

        public string Email { get => _Email; set => _Email = value; }
        public string Password { get => _Password; set => _Password = value; }
        public WindowAddComptable()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void SubmitComptable_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
