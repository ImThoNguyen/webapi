using backend.Data.Entities;
using backend.Data.Repositories;
using backend.Queries;
using backend.Results;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Handler
{
    public class RegistryUserHandler : IRegistryUserHandler
    {
        private readonly IValidator<RegistryUser> _validator;
        private IUserReponsitory _iUserReponsitory;

        public RegistryUserHandler(IValidator<RegistryUser> validator, IUserReponsitory iUserReponsitory)
        {
            _validator = validator;
            _iUserReponsitory = iUserReponsitory;
        }
        public User Authenticate(string AccountName, string Password)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<UserAcountResult> SaveAccount(RegistryUser registryUser)
        {

            var validationResult = _validator.Validate(registryUser);
            if (!validationResult.IsValid)
            {
                List<ValidationFailure> failures = validationResult.Errors;
                throw new Exception(string.Join(", ", failures));
            }


            User user = new User();
            user.Id = registryUser.Id;
            user.AccountName = registryUser.AccountName;
            user.Password = registryUser.Password;
            user.GivenName = registryUser.GivenName;
            user.Address1 = registryUser.Address1;
            user.Address2 = registryUser.Address2;
            user.City = registryUser.City;
            user.Country = registryUser.Country;
            user.CreatedOn = registryUser.CreatedOn;
            user.CreatedBy = registryUser.CreatedBy;
            user.ModifiedOn = registryUser.ModifiedOn;
            user.ModifiedBy = registryUser.ModifiedBy;
            user.UserInfo = registryUser.UserInfo;
            user.CommonName = registryUser.CommonName;
            user.FamilyName = registryUser.FamilyName;
            user.FullName = registryUser.FullName;
            user.MiddleName = registryUser.MiddleName;
            user.UserNote = registryUser.UserNote;
            user.Photo = registryUser.Photo;


            await _iUserReponsitory.AddOrUpdateAsync(user);
            await _iUserReponsitory.UnitOfWork.SaveChangesAsync();

            UserAcountResult userAcountResult = new UserAcountResult();

            userAcountResult.AccountName = registryUser.AccountName;
            userAcountResult.GivenName = registryUser.GivenName;
            userAcountResult.Address1 = registryUser.Address1;
            userAcountResult.Address2 = registryUser.Address2;
            userAcountResult.City = registryUser.City;
            userAcountResult.Country = registryUser.Country;
            userAcountResult.UserInfo = registryUser.UserInfo;
            userAcountResult.CommonName = registryUser.CommonName;
            userAcountResult.FamilyName = registryUser.FamilyName;
            userAcountResult.FullName = registryUser.FullName;
            userAcountResult.MiddleName = registryUser.MiddleName;
            userAcountResult.UserNote = registryUser.UserNote;
            userAcountResult.Photo = registryUser.Photo;

            return userAcountResult;
        }

        public Task<User> Update()
        {
            throw new NotImplementedException();
        }


    }
}
