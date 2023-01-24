using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7.Repository
{
    /// <summary>
    /// Базовый репозиторий для наследования дочерних репозиториев
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        public readonly ApplicationContext context;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public abstract void AddEntity(TEntity entity);

        public abstract void DeleteEntity(int? Id);

        public abstract TEntity? GetEntity(int? Id);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract void UpdateEntity(TEntity dto);
        public virtual void SaveEntity()
        {
            context.SaveChanges();
        }
    }
}
