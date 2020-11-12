using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get();

        Task<T> FindAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        void Create(T entity);

        void Delete(int id);

        Task SaveAsync();
    }
}
