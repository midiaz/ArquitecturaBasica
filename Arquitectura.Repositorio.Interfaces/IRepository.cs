using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arquitectura.Repositorio.Interfaces
{
    public interface IRepository<T> where T : class//BaseEntity
    {
        IEnumerable<T> GetAll();
        //T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
        T GetOne(Expression<Func<T, Boolean>> Filtro);
        T GetOne(Expression<Func<T, Boolean>> Filtro, string Includes);
        void UpdateWithDetach(T entity, Expression<Func<T, Boolean>> Filtro);
        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        #endregion
    }
}
