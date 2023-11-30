using Microsoft.EntityFrameworkCore;
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
    class BaieViewModel
    {
        public ObservableCollection<Baie> Baies { get; set; }
        public Baie SelectedBaie { get => _SelectedBaie; set => _SelectedBaie = value; }

        private Baie _SelectedBaie;
        public BaieViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Baies = new ObservableCollection<Baie>(context.Baies.Include(u => u.Unites).ThenInclude(u => u.Reservation)) ;
            }
        }

        internal void DeleteBaie()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedBaie != null && SelectedBaie.Unites.All(u => u.ReservationId == null))
                {
                    context.Unites.RemoveRange(SelectedBaie.Unites);
                    context.Baies.Remove(SelectedBaie);
                    Baies.Remove(SelectedBaie);
                    context.SaveChanges();
                }
            }
        }

        internal void AddBaie()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                Baie baie = new Baie();
                baie.NbSpot = 42;
                try
                {
                    baie.Code = "B"+(int.Parse(Baies.Last().Code.Substring(1, 3))+1).ToString("D3");
                }
                catch (ArgumentNullException)
                {
                    baie.Code = "B001";
                }

                Baies.Add(baie);
                context.Baies.Add(baie);
                context.SaveChanges();
                
                for (int i = 1; i < 43; i++)
                {
                    Unite Unites = new Unite();
                    Unites.BaieId = baie.Id;
                    Unites.Available = false;
                    Unites.NumSpot = i.ToString();
                    context.Unites.Add(Unites);

                }
                context.SaveChanges();
            }
        }
    }
}
