using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using backend.CrossCuttingConcerns;
using backend.Data.Context;
using backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories
{
   

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {

        private readonly EFCoreDBContext _dbContext;
        private IDateTimeProvider _dateTimeProvider;

        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();



        public Repository(EFCoreDBContext dBContext, IDateTimeProvider dateTimeProvider)
        {
            _dbContext = dBContext;
            _dateTimeProvider = dateTimeProvider; 
        }
        public IUnitOfWork UnitOfWork {

            get {
                return _dbContext;
            }
        }


        public async Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity.Id.Equals(default(TKey)))
            {

                entity.CreatedOn = _dateTimeProvider.Now;
                await DbSet.AddAsync(entity, cancellationToken);
            }
            else {
                entity.ModifiedOn = _dateTimeProvider.Now;
            }
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public Task<T1> FirstOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public Task<T1> SingleOrDefaultAsync<T1>(IQueryable<T1> query)
        {
            return query.SingleOrDefaultAsync();
        }

        public Task<List<T1>> ToListAsync<T1>(IQueryable<T1> query)
        {
            return query.ToListAsync();
        }
    }
}
