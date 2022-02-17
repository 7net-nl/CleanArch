using CleanArchitecture.Domain.Contract.Interfaces;
using CleanArchitecture.Domain.Contract.Interfaces.EF;
using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF.Repositories
{
    public class EFBaseRepository : IBaseRepository
    {
        private readonly DBContextEF context;

        public EFBaseRepository(DBContextEF Context)
        {
            context = Context;
        }
        public Task<string> AddAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            context.AddAsync(entity);
            return Task.FromResult(entity.ID.ToString());
        }

        public Task<string> UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            var Result = context.Update(entity);
            return Task.FromResult(Result.State.ToString());
        }

        public Task<string> DeleteAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            var Result = context.Remove(entity);
            return Task.FromResult(Result.State.ToString());
        }

        public Task<string> DeleteRangeAsync<TEntity>(List<TEntity> entities) where TEntity : Entity
        {
            context.RemoveRange(entities);
            return Task.FromResult("Deleted All");
        }

        public async Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity,bool>> expression)
            where TEntity : Entity
            
        {
            return await Task.FromResult(context.Set<TEntity>().Where(expression));
            
        }

        public async Task<IQueryable<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity
        {
            return await Task.FromResult(context.Set<TEntity>());
        }

        public async Task SaveAsync()
        {
            context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
