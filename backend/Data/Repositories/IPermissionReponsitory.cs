using backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Repositories
{
    public interface IPermissionReponsitory : IRepository<Permission, Guid>
    {
    }
}
