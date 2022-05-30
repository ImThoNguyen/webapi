using backend.Data.Entities;
using backend.Data.Repositories;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace backend.Data.Context
{
    public class EFCoreDBContext : DbContext, IBlogStoryDBContext, IUnitOfWork, IDataProtectionKeyContext
    {
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        private IDbContextTransaction _dbContextTransaction;

        public EFCoreDBContext(DbContextOptions<EFCoreDBContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            BuildPost(modelBuilder);
            BuildCategory(modelBuilder);
            BuildPermision(modelBuilder);
            BuildUser(modelBuilder);
            BuildGender(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void BuildPost(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>(builder => {
                builder.HasMany(p => p.Posts).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            });
        }

        private void BuildCategory(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Post>(builder => {
                builder.HasOne(p => p.Category).WithMany(p => p.Posts).OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            });
        }

        private void BuildUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(builder => {
                builder.HasOne(p => p.Users).WithMany(p => p.Permissions).OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            });
            modelBuilder.Entity<Gender>(builder =>
            {
                builder.HasMany(p => p.Users).WithOne(p => p.Gender).OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            });
        }

        private void BuildGender(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder => {
                builder.HasOne(p => p.Gender).WithMany(p => p.Users).OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            });
        }


        private void BuildPermision(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder => {
                builder.HasMany(p => p.Permissions).WithOne(p => p.Users).OnDelete(DeleteBehavior.Cascade);
                builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            });
        }

        public IDisposable BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _dbContextTransaction = Database.BeginTransaction(isolationLevel);
            return _dbContextTransaction;
        }

        public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            _dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel);
            return _dbContextTransaction;
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContextTransaction.CommitAsync(cancellationToken);
        }
    }
}
