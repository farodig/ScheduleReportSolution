using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleReport.DB.Repositories
{
    public class MonitoringObjectRepository : Repository<MonitoringObject>, IMonitoringObjectRepository
    {
        public MonitoringObjectRepository(RepositoryContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
        }

        public List<MonitoringObject> GetAllObjects()
        {
            return GetAll().ToList();
        }
    }
}
