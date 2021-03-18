using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.DB.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(Func<TEntity, bool> func);

        bool Add(TEntity entity);

        bool Delete(Func<TEntity, bool> func);
    }
}
