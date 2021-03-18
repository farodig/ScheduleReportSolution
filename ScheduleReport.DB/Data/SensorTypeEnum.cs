using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB
{
    /// <summary>
    /// Типы сенсоров
    /// </summary>
    public enum SensorTypeEnum
    {
        /// <summary>
        /// Топливный сенсор
        /// </summary>
        Fuel = 1,

        /// <summary>
        /// Датчик зажигания
        /// </summary>
        Ignition = 2,

        /// <summary>
        /// Датчик детонации
        /// </summary>
        SnockSensor = 3,
    }
}
