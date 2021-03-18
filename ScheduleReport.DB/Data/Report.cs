using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB
{
    /// <summary>
    /// Модель отчёта
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Идентификатор отчёта
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип отчёта
        /// </summary>
        public int ReportType { get; set; }

        /// <summary>
        /// Объект мониторинга
        /// </summary>
        public List<MonitoringObject> MonitoringObjects { get; set; }

        /// <summary>
        /// Время создания отчёта
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// Период отчёта
        /// </summary>
        public int Periodicity { get; set; }

        /// <summary>
        /// Параметры построения отчёта
        /// </summary>
        public object Parameters { get; set; }
    }
}
