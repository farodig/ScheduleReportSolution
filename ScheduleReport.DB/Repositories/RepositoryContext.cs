using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.DB.Repositories
{
    /// <summary>
    /// Здесь должен быть EntityFramework, но вставлена заглушка для выборки таблиц
    /// можно доработать через рефлексию, но это уже будет написание собственного framework
    /// </summary>
    public class RepositoryContext
    {
        /// <summary>
        /// Список отчётов
        /// </summary>
        public List<Report> Reports { get; set; } = new List<Report>()
        {
            new Report
            {
                ID = Guid.NewGuid(),
                Title = "Пример отчёта",
                CreateDateTime = DateTime.Now,
                MonitoringObjects = new List<MonitoringObject>(),
                Periodicity = 1,
                ReportType = 1,
            }
        };

        /// <summary>
        /// Список объектов
        /// </summary>
        public List<MonitoringObject> MonitoringObjects { get; set; } = new List<MonitoringObject>()
        {
            new MonitoringObject{ ID = Guid.NewGuid(), Code = 1, Number = "o001oa178"},
            new MonitoringObject{ ID = Guid.NewGuid(), Code = 2, Number = "o002oo47"},
            new MonitoringObject{ ID = Guid.NewGuid(), Code = 3, Number = "a100aa777"},
        };

        #region Заглушка EF (так мы не пишем)
        public bool Add<TEntity>(TEntity entity) where TEntity : class, new()
        {
            try
            {
                if (entity is Report report)
                {
                    Reports.Add(report);
                }
                else if (entity is MonitoringObject monitoringObject)
                {
                    MonitoringObjects.Add(monitoringObject);
                }
                else
                {
                    throw new Exception("Unknown type.");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, new()
        {
        }

        internal IQueryable<TEntity> Set<TEntity>()
        {
            if (typeof(TEntity) == typeof(Report))
            {
                return (IQueryable<TEntity>)Reports.AsQueryable(); ;
            } else if (typeof(TEntity) == typeof(MonitoringObject))
            {
                return (IQueryable<TEntity>)MonitoringObjects.AsQueryable();
            } else
            {
                return null;
            }
        }

        public bool Delete<TEntity>(TEntity item)//Func<TEntity, bool> func)
            where TEntity : class, new()
        {
            try
            {
                if (item is Report reportItem)//typeof(Report) == typeof(TEntity))// && Reports.FirstOrDefault((Func<Report, bool>)func) is Report reportItem)
                {
                    Reports.Remove(reportItem);
                }
                else if (item is MonitoringObject objectItem)//typeof(MonitoringObject) == typeof(TEntity) && Objects.FirstOrDefault((Func<MonitoringObject, bool>)func) is MonitoringObject objectItem)
                {
                    MonitoringObjects.Remove(objectItem);
                } else
                {
                    throw new Exception("Unknown type.");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion
    }
}
