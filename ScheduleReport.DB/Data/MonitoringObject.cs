using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB
{
    /// <summary>
    /// Объект под наблюдением
    /// </summary>
    public class MonitoringObject
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Код объекта
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Номер объекта
        /// </summary>
        public string Number { get; set; }
    }
}
