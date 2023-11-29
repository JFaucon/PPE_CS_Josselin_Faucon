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
    class BaieViewModel
    {
        public ObservableCollection<Baie> Baies { get; set; }

        public BaieViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Baies = new ObservableCollection<Baie>(context.Baies);
            }
        }
    }
}
