using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Contract.Repositories
{
    public interface IBaseRepository
    {
        Task<string> AddAsync<TEntity>(TEntity entity) where TEntity : Entity;
        Task<string> UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity;
        Task<string> DeleteAsync<TEntity>(TEntity entity) where TEntity : Entity;
        Task<string> DeleteRangeAsync<TEntity>(List<TEntity> entities) where TEntity : Entity;
        Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : Entity;
        Task<IQueryable<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity;
        Task SaveAsync();
        




    }
}
