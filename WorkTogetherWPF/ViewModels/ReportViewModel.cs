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
    class ReportViewModel
    {
        public ObservableCollection<Report> Reports { get; set; }
        public Report SelectedReport { get => _SelectedReport; set => _SelectedReport = value; }

        private Report _SelectedReport;
        public ReportViewModel()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                this.Reports = new ObservableCollection<Report>(context.Reports);
            }
        }

        internal void DeleteReport()
        {
            using (WorkTogetherContext context = new WorkTogetherContext())
            {
                if (SelectedReport != null)
                {
                    context.Reports.Remove(SelectedReport);
                    Reports.Remove(SelectedReport);
                    context.SaveChanges();
                }
            }
        }
    }
}
