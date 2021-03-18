using ScheduleReport.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.Client.Enums
{
    /// <summary>
    /// Периодичность выполнения отчёта
    /// </summary>
    public enum PeriodicityReportEnum
    {
        /// <summary>
        /// День
        /// </summary>
        [Name("День")]
        Day = 1,

        /// <summary>
        /// Неделя
        /// </summary>
        [Name("Неделя")]
        Week = 2,

        /// <summary>
        /// Месяц
        /// </summary>
        [Name("Месяц")]
        Month = 3,
    }
}
