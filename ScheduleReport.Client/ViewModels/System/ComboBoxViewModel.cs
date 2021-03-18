using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.Client.ViewModels
{
    /// <summary>
    /// Модель комбобокса
    /// </summary>
    /// <typeparam name="T">Тип данных лежащий в комбобоксе</typeparam>
    public class ComboBoxViewModel<T>
    {
        /// <summary>
        /// Выводимое значение
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фактическое значение
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Приведение к строке
        /// </summary>
        public override string ToString() => Name;
    }
}
