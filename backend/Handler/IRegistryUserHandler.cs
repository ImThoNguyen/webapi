using backend.Data.Entities;
using backend.Queries;
using backend.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Handler
{
    public interface IRegistryUserHandler
    {
        Task<UserAcountResult> SaveAccount(RegistryUser registryUser);
        Task<User> Update();
        List<User> GetUsers();
        User Authenticate(string AccountName, string Password);
    }
}
