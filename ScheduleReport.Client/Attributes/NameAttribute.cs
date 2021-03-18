using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.Client.Attributes
{
    /// <summary>
    /// Название
    /// </summary>
    public class NameAttribute : Attribute
    {
        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public NameAttribute(string value)
        {
            // Значение
            Value = value;
        }
    }
}
