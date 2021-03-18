using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB
{
    /// <summary>
    /// Период отчёта
    /// </summary>
    public enum ReportPeriodEnum
    {
        /// <summary>
        /// За день
        /// </summary>
        Day = 1,

        /// <summary>
        /// За месяц
        /// </summary>
        Month = 2,

        /// <summary>
        /// За год
        /// </summary>
        Year = 3,
    }
}
