using ScheduleReport.Client.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.Client.Enums
{
    /// <summary>
    /// Типы отчётов
    /// </summary>
    public enum ReportTypeEnum
    {
        /// <summary>
        /// Движение и остановка
        /// </summary>
        [Name("Движение и остановка")]
        MoveAndStop = 1,

        /// <summary>
        /// Сообщения от объекта
        /// </summary>
        [Name("Сообщение от объекта")]
        MessagesFromObject = 2,
    }
}
