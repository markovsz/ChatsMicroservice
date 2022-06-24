using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Messager.Chats.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);
        Task<IQueryable<T>> FindAll(bool trackChanges);
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Update(T entity);
        void Delete(T entity);
    }
}
