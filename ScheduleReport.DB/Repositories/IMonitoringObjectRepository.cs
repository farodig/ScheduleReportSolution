using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleReport.DB.Repositories
{
    public interface IMonitoringObjectRepository : IRepository<MonitoringObject>
    {
        /// <summary>
        /// Получить все объекты
        /// </summary>
        List<MonitoringObject> GetAllObjects();
    }
}
