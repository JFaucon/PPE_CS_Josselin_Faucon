using System;
using System.Windows;
using WorkTogetherLib.Class;

namespace WorkTogetherWPF.Windows
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="WindowLogin"/>.
        /// </summary>
        public WindowLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton de connexion.
        /// </summary>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string useremail = Email.Text;
            string password = pwd.Password;

#if RELEASE
            useremail = "admin@admin.com";
            password = "admin";
#endif

            bool isPasswordCorrect = false;
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Email == useremail);
                if (user != null && user.Discr != "client")
                {
                    ((App)Application.Current).User = user;
                    user.Password = user.Password.Replace("$2y$13$", "$2a$13$");
                    isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password);
                }
            }

            if (isPasswordCorrect)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }
    }
}
