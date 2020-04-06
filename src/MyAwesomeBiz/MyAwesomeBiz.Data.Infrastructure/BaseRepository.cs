using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Data.Infrastructure
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyDbContext _dbContext;

        public BaseRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> ReadAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Save(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();

           return entity;
        }

        public async Task<T> Update(T entity)
        {
           _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}