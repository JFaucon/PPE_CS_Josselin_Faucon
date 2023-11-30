using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogetherLib.Class;
using WorkTogetherWPF.Views;
using WorkTogetherWPF.Windows;

namespace WorkTogetherWPF.ViewModels
{
    class UserViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get => _SelectedUser; set => _SelectedUser = value; }

        private User _SelectedUser;

        public UserViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Users = new ObservableCollection<User>(context.Users);
            }
        }

        public void AddClient()
        {
            WindowAddClient addClient = new WindowAddClient();
            addClient.ShowDialog();

            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                User user = new User();
                user.LastName = addClient.LastName;
                user.FirstName = addClient.FirstName;
                user.Email = addClient.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(addClient.Password, BCrypt.Net.BCrypt.GenerateSalt(13));
                user.Password = user.Password.Replace("$2a$13$", "$2y$13$");
                user.Roles = "[\"ROLE_CLIENT\"]";
                user.Discr = "client";
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void AddComptable()
        {
            WindowAddComptable addComptable = new WindowAddComptable();
            addComptable.ShowDialog();

            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                User user = new User();
                user.Email = addComptable.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(addComptable.Password, BCrypt.Net.BCrypt.GenerateSalt(13));
                user.Password = user.Password.Replace("$2a$13$", "$2y$13$");
                user.Roles = "[\"ROLE_COMPTABLE\"]";
                user.Discr = "comptable";
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void AddAdmin()
        {
            WindowAddAdmin addAdmin = new WindowAddAdmin();
            addAdmin.ShowDialog();

            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                User user = new User();
                user.Email = addAdmin.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(addAdmin.Password, BCrypt.Net.BCrypt.GenerateSalt(13));
                user.Password = user.Password.Replace("$2a$13$", "$2y$13$");
                user.Roles = "[\"ROLE_ADMIN\"]";
                user.Discr = "admin";
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void DeleteUser()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedUser != null)
                {
                    context.Users.Remove(SelectedUser);
                    Users.Remove(SelectedUser);
                    context.SaveChanges();
                }
            }
        }
    }
}
