using System;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleReport.DB.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly RepositoryContext RepositoryPatternContext;

        public Repository(RepositoryContext repositoryContext)
        {
            RepositoryPatternContext = repositoryContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return RepositoryPatternContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetAll)} couldn't retrieve entities: {ex.Message}");
            }
        }

        public TEntity Get(Func<TEntity, bool> func)
        {
            try
            {
                return RepositoryPatternContext.Set<TEntity>().FirstOrDefault(func);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(Get)} couldn't retrieve entities: {ex.Message}");
            }
        }

        public bool Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                return RepositoryPatternContext.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public bool Delete(Func<TEntity, bool> func)
        {
            try
            {
                if (func == null)
                {
                    throw new ArgumentNullException($"{nameof(Delete)} func must not be null");
                }

                // Найти сущность
                var entity = Get(func);

                try
                {
                    if (entity != null)
                    {
                        // Удалить сущность
                        return RepositoryPatternContext.Delete(entity);
                    }

                    return true;    
                }
                catch (Exception ex)
                {
                    throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
