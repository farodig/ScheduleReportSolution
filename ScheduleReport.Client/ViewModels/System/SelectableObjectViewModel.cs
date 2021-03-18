using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.Client.ViewModels
{
    /// <summary>
    /// Модель комбобокса с чекбоксами
    /// </summary>
    /// <typeparam name="T">Тип данных лежащий в комбобоксе</typeparam>
    public class SelectableObjectViewModel<T>
    {
        /// <summary>
        /// Объект выбран?
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Выводимое название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фактический объект
        /// </summary>
        public T Value { get; set; }
    }
}
