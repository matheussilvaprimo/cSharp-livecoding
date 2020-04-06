using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Data.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T>Save(T entity);
        Task<T>Update(T entity);
        Task<T>FindOne(Expression<Func<T, bool>> predicate);
        Task<List<T>>ReadAll();
    }
}