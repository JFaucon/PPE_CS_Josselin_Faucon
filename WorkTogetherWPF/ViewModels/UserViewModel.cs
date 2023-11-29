using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogetherLib.Class;
using WorkTogetherWPF.Views;

namespace WorkTogetherWPF.ViewModels
{
    class UserViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UserViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Users = new ObservableCollection<User>(context.Users);
            }
        }
    }
}
