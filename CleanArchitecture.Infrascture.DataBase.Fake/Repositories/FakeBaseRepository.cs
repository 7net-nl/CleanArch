using CleanArchitecture.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.Fake.Repositories
{
    public class FakeBaseRepository : IBaseRepository
    {
        public Task<string> AddAsync<TEntity>(TEntity entity) where TEntity : Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync<TEntity>(TEntity entity) where TEntity : Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync<TEntity>(TEntity entity) where TEntity : Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteRangeAsync<TEntity>(List<TEntity> entities) where TEntity : Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAllAsync<TEntity>() where TEntity : Domain.Entities.Entity
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
