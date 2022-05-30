using backend.CrossCuttingConcerns;
using backend.Data.Context;
using backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(EFCoreDBContext dbContext, IDateTimeProvider dateTimeProvider) : base (dbContext, dateTimeProvider)
        {
        }

    }
}
