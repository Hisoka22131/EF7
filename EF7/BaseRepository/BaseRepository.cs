using EF7.Models;
using EF7.Repository.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7.BaseRepository
{
    /// <summary>
    /// Наследуем каждый репозиторий от этого класса 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> where TEntity : EntityBase
    {
        internal readonly ApplicationContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void AddEntity(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void RemoveEntity(object id)
        {
            TEntity? entity = dbSet.Find(id);
            if (entity != null)
                RemoveEntity(entity);
        }

        public void RemoveEntity(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void UpdateEntity(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public TE? GetEntity<TE>(int? id) where TE : EntityBase
        {
            return context.Find<TE>(id);
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return dbSet.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
