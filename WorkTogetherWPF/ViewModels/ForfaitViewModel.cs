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
    class ForfaitViewModel
    {
        public ObservableCollection<Forfait> Forfaits { get; set; }
        public Forfait SelectedForfait { get => _SelectedForfait; set => _SelectedForfait = value; }

        private Forfait _SelectedForfait;
        public ForfaitViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Forfaits = new ObservableCollection<Forfait>(context.Forfaits);
            }
        }
    }
}
