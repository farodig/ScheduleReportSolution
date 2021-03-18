using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB
{
    /// <summary>
    /// Параметры отчёта "движение и остановки"
    /// </summary>
    public class MoveAndStopReportParameter
    {
        /// <summary>
        /// Период отчёта
        /// </summary>
        public ReportPeriodEnum Period { get; set; }
    }
}
