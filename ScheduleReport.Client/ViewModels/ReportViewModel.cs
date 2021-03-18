using ScheduleReport.Client.Enums;
using ScheduleReport.Client.Extensions;
using ScheduleReport.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.Client.ViewModels
{
    public class ReportViewModel : INotifyPropertyChanged
    {
        #region Локальные переменные
        private ComboBoxViewModel<ReportTypeEnum> _reportType;
        private ComboBoxViewModel<PeriodicityReportEnum> _periodicityReport;
        private string _jobTitle;
        private DateTime _startTime = DateTime.Now;
        #endregion

        #region Публичные свойства

        public Guid ID { get; set; }

        /// <summary>
        /// Название отчёта
        /// </summary>
        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; OnPropertyChanged(nameof(JobTitle)); }
        }


        /// <summary>
        /// Тип отчёта
        /// </summary>
        public ComboBoxViewModel<ReportTypeEnum> ReportType
        {
            get { return _reportType; }
            set { _reportType = value; OnPropertyChanged(nameof(ReportType)); }
        }

        /// <summary>
        /// Периодичность выполнения отчёта
        /// </summary>
        public ComboBoxViewModel<PeriodicityReportEnum> PeriodicityReport
        {
            get { return _periodicityReport; }
            set { _periodicityReport = value; OnPropertyChanged(nameof(PeriodicityReport)); }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; OnPropertyChanged(nameof(StartTime)); }
        }

        /// <summary>
        /// Объекты под наблюдением
        /// </summary>
        public List<MonitoringObjectViewModel> MonitorObjects { get; set; } = new List<MonitoringObjectViewModel>();
        #endregion

        #region Методы преобразования
        /// <summary>
        /// Преобразовать отображение в объект
        /// </summary>
        public static explicit operator Report(ReportViewModel item)
        {
            var report = new Report();

            // Идентификатор отчёта
            report.ID = Guid.NewGuid();

            // Заголовок задачи
            report.Title = item.JobTitle;

            // Тип отчёта
            report.ReportType = (int)item.ReportType.Value;

            // Период отчёта
            report.Periodicity = (int)item.PeriodicityReport.Value;

            // Объект мониторинга
            report.MonitoringObjects = item.MonitorObjects.Select(a => (MonitoringObject)a).ToList();

            return report;
        }

        /// <summary>
        /// Преобразовать отображение в объект
        /// </summary>
        public static explicit operator ReportViewModel(Report item)
        {
            var report = new ReportViewModel();

            // Идентификатор отчёта
            report.ID = item.ID;

            // Заголовок задачи
            report.JobTitle = item.Title;

            // Тип отчёта
            report.ReportType = ComboboxExtension.EnumToComboBoxItem((ReportTypeEnum)item.ReportType);

            // Период отчёта
            report.PeriodicityReport = ComboboxExtension.EnumToComboBoxItem((PeriodicityReportEnum)item.Periodicity);

            // Объект мониторинга
            //report.MonitoringObjects = item.MonitorObjects.Select(a => (MonitoringObject)a).ToList();

            return report;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
