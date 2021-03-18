using ScheduleReport.Client.Extensions;
using ScheduleReport.Client.ViewModels;
using ScheduleReport.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScheduleReport.Client.Commands
{
    public class DeleteReportCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public void Execute(object parameter)
        {
            if (parameter is ReportViewModel report)
            {
                RestApiExtension.DeleteReport(report.ID);
            }
        }
    }
}
