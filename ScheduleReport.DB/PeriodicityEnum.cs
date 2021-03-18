using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB
{
    /// <summary>
    /// Цикличность построения отчёта
    /// </summary>
    public enum PeriodicityEnum
    {
        /// <summary>
        /// Один раз в день
        /// </summary>
        Day = 1,

        /// <summary>
        /// Один раз в неделю
        /// </summary>
        Week = 2,

        /// <summary>
        /// Один раз в месяц
        /// </summary>
        Month = 3,
    }
}
