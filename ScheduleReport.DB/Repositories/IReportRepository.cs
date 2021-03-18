using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.DB.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {
        /// <summary>
        /// Получить все отчёты
        /// </summary>
        List<Report> GetAllReports();

        /// <summary>
        /// Создать очтёт
        /// </summary>
        bool CreateReport(Report item);

        /// <summary>
        /// Удалить отчёт
        /// </summary>
        bool DeleteReport(Func<Report, bool> func);
    }
}
