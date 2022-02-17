using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.MongoDb.Repositories
{
    public class MongoDbBaseRepository : IBaseRepository
    {
        private readonly MongoDbContext context;

        public MongoDbBaseRepository(MongoDbContext context)
        {
            this.context = context;

        }
        public async Task<string> AddAsync<TEntity>(TEntity entity) where TEntity : Entity
        {

            await context.Set<TEntity>().InsertOneAsync(entity);

            return entity.ID.ToString();
        }

        public async Task<string> UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            throw new NotImplementedException();

        }

        public Task<string> DeleteAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteRangeAsync<TEntity>(List<TEntity> entities) where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : Entity
        {

            return await Task.FromResult(context.Set<TEntity>().AsQueryable().Where(expression));

           

           
        }

        public async Task<IQueryable<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity
        {
            return await Task.FromResult(context.Set<TEntity>().AsQueryable());
        
        }

        public async Task SaveAsync()
        {
           await Task.CompletedTask;
        }
    }
}
