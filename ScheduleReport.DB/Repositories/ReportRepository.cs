using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.DB.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public bool CreateReport(Report item)
        {
            // Добавить отчёт
            return Add(item);
        }

        public bool DeleteReport(Func<Report, bool> func)
        {
            // Удалить отчёт
            return Delete(func);
        }

        public List<Report> GetAllReports()
        {
            // Получить все отчёты
            return GetAll().ToList();
        }
    }
}
