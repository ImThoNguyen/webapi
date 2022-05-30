using backend.CrossCuttingConcerns;
using backend.Data.Context;
using backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Repositories
{
    public class UserReponsitory : Repository<User, Guid>, IUserReponsitory
    {
        public UserReponsitory(EFCoreDBContext dBContext, IDateTimeProvider dateTimeProvider) : base (dBContext, dateTimeProvider)
        {

        }

    }
}
