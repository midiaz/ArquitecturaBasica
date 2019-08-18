using Arquitectura.Repositorio.Interfaces;
using Arquitectura.Repositorio.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arquitectura.Repositorio.Repositorio
{
    public class Repository<T> : IRepository<T> where T : class//BaseEntity
    {
        private readonly ContextoBD context;
        private DbSet<T> entities;
        private string errorMessage = string.Empty;

        public Repository(ContextoBD context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        //public T Get(long id)
        //{
        //    return entities.SingleOrDefault(s => s.Id == id);
        //}
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }



        public void UpdateWithDetach(T entity, Expression<Func<T, Boolean>> Filtro)
        {
            var local = context.Set<T>().Local.AsQueryable().FirstOrDefault(Filtro);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public T GetOne(Expression<Func<T, Boolean>> Filtro)
        {
            return GetOne(Filtro, null);
        }

        public T GetOne(Expression<Func<T, Boolean>> Filtro, string Includes)
        {

            var query = context.Set<T>();

            return !string.IsNullOrEmpty(Includes)
                ? query.Include(Includes.Trim()).AsNoTracking().Where(Filtro).FirstOrDefault()
                : query.AsNoTracking().Where(Filtro).FirstOrDefault();

        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        #region Properties
        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                
                return entities;
            }
        }

        #endregion
    }
}
