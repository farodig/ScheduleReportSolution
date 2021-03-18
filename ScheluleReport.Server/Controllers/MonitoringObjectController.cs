using Microsoft.AspNetCore.Mvc;
using ScheduleReport.DB;
using ScheduleReport.DB.Repositories;
using ScheduleReport.Server.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleReport.Server.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("[controller]")]
    public class MonitoringObjectController : ControllerBase
    {
        #region Инициализация
        private MonitoringObjectRepository MonitoringObjectRepository;

        /// <summary>
        /// Инициализация
        /// </summary>
        public MonitoringObjectController(RepositoryContext myDependency)
        {
            MonitoringObjectRepository = new MonitoringObjectRepository(myDependency);
        }
        #endregion

        /// <summary>
        /// Вернуть список объектов
        /// </summary>
        [HttpGet]
        public IEnumerable<MonitoringObject> Index()
        {
            return MonitoringObjectRepository.GetAllObjects();
        }
    }
}
