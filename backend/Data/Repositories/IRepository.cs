using backend.Data.Context;
using backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace backend.Data.Repositories
{
    public interface IRepository<TEntity, Tkey> where TEntity : Entity<Tkey>
    {
        public IUnitOfWork UnitOfWork { get;}
        IQueryable<TEntity> GetAll();
        Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Delete(TEntity entity);
        Task<T> FirstOrDefaultAsync<T>(IQueryable<T> query);
        Task<T> SingleOrDefaultAsync<T>(IQueryable<T> query);
        Task<List<T>> ToListAsync<T>(IQueryable<T> query);

    }
}
 