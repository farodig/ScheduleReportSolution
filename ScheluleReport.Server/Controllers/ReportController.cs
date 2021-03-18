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
    public class ReportController : ControllerBase
    {
        #region Инициализация
        private ReportRepository ReportRepository;

        public ReportController(RepositoryContext myDependency)
        {
            ReportRepository = new ReportRepository(myDependency);
        }
        #endregion

        /// <summary>
        /// Вернуть список отчётов
        /// </summary>
        [HttpGet]
        public IEnumerable<Report> Index()
        {
            return ReportRepository.GetAllReports();
        }

        /// <summary>
        /// Создать новый отчёт
        /// </summary>
        [HttpPost]
        [Route("/[controller]/[action]")]
        public bool Create([FromBody] Report item)
        {
            // TODO: Добавить проверку
            return ReportRepository.CreateReport(item);
        }

        /// <summary>
        /// Удалить отчёт
        /// </summary>
        [HttpDelete]
        [Route("/[controller]/[action]/{id}")]
        public bool Delete(Guid id)
        {
            return ReportRepository.DeleteReport(a => a.ID == id);
        }
    }
}
