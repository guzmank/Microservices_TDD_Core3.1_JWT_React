using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Home.Framework.Data.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        // Get records by it's primary key
        TModel Get(Guid id);

        // Get all records
        IEnumerable<TModel> GetAll();

        // Get all records matching a lambda expression
        IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate);

        // Get the a single matching record or null
        TModel SingleOrDefault(Expression<Func<TModel, bool>> predicate);

        // Add single record
        void Add(TModel entity);

        // Add multiple records
        void AddRange(IEnumerable<TModel> entities);

        // Remove records
        void Remove(TModel entity);

        // remove multiple records
        void RemoveRange(IEnumerable<TModel> entities);
    }
}
