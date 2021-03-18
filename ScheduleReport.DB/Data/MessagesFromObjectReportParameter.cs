using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB
{
    /// <summary>
    /// Параметры отчёта "Сообщения с объекта"
    /// </summary>
    public class MessagesFromObjectReportParameter
    {
        /// <summary>
        /// Тип сенсора
        /// </summary>
        public SensorTypeEnum SensorType { get; set; }
    }
}
