using ScheduleReport.Client.Attributes;
using ScheduleReport.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.Client.Extensions
{
    /// <summary>
    /// Расширение для Combobox
    /// </summary>
    public static class ComboboxExtension
    {
        /// <summary>
        /// Получить список значений enum для ComboBox
        /// </summary>
        /// <typeparam name="T">Тип Enum</typeparam>
        /// <returns>Список значений</returns>
        public static List<ComboBoxViewModel<T>> EnumToComboBox<T>()
            where T : struct, IConvertible
        {
            return typeof(T)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(a => new ComboBoxViewModel<T>
                {
                    Name = ((NameAttribute)a.GetCustomAttributes(typeof(NameAttribute), false).FirstOrDefault()).Value,
                    Value = (T)Enum.Parse(typeof(T), a.Name)
                })
                .ToList();
        }

        /// <summary>
        /// Получить значение ComboBox
        /// </summary>
        public static ComboBoxViewModel<T> EnumToComboBoxItem<T>(T item)
        {
            return new ComboBoxViewModel<T>
            {
                Name = typeof(T).GetMember(item.ToString()).First().GetCustomAttribute<NameAttribute>().Value,
                Value = item
            };
        }
    }
}
