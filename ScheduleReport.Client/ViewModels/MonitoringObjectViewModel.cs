using ScheduleReport.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleReport.Client.ViewModels
{
    /// <summary>
    /// Объект под наблюдением ViewModel
    /// </summary>
    public class MonitoringObjectViewModel
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Номер объекта
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// Порядок сортировки
        /// </summary>
        public int Order { get; }

        /// <summary>
        /// Инициализация объекта
        /// </summary>
        public MonitoringObjectViewModel(MonitoringObject item)
        {
            // Идентификатор объекта
            ID = item.ID;

            // Номер объекта
            Number = item.Number;

            // Порядок сортировки
            Order = item.Code;
        }

        /// <summary>
        /// Преобразовать отображение в оъект
        /// </summary>
        /// <param name="self"></param>
        public static explicit operator MonitoringObject(MonitoringObjectViewModel self)
        {
            var item = new MonitoringObject();

            // Идентификатор объекта
            item.ID = self.ID;

            // Код объекта
            item.Code = self.Order;

            // Номер объекта
            item.Number = self.Number;

            return item;
        }
    }
}
