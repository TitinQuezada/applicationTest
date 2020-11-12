using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public readonly ApplicationContext _context;
        public readonly DbSet<T> _set;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        IEnumerable<T> IBaseRepository<T>.Get()
        {
            return _set.AsEnumerable();
        }

        void IBaseRepository<T>.Create(T entity)
        {
            _context.Add(entity);
        }

        void IBaseRepository<T>.Delete(int id)
        {
            IQueryable<T> queryable = _set.AsQueryable();
            T entity = queryable.FirstOrDefault(entity => entity.Id == id);
            _context.Remove(entity);
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.FirstOrDefaultAsync(condition);
        }

        async Task IBaseRepository<T>.SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
