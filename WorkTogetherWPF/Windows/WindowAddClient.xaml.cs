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
    /// Logique d'interaction pour WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public WindowAddClient()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void SubmitClient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
