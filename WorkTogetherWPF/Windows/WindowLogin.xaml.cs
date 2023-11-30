using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace WorkTogetherWPF.Windows;

/// <summary>
/// Logique d'interaction pour WindowLogin.xaml
/// </summary>
public partial class WindowLogin : Window
{
    public WindowLogin()
    {
        InitializeComponent();
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        string useremail = Email.Text;
        string password = pwd.Password;

#if DEBUG
        useremail = "admin@admin.com";
        password = "admin";
#endif

        bool isPasswordCorrect = false;
        using (WorkTogetherContext context = new WorkTogetherContext())
        {
            User user = context.Users.FirstOrDefault(u => u.Email == useremail);
            if (user != null && user.Discr == "admin")
            {
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
