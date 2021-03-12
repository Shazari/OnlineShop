using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using ViewModels;
namespace ParsMarketCoreAPI
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork { get; }
        public UserService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }
        public Task AddUser(User user)
        {
            
            throw new NotImplementedException();
        }

        public Task DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public Task UptateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterUserResult> RegisterUser(RegisterViewModel register)
        {
            if (IsUserExistByEmail(register.EmailAddress))
                return RegisterUserResult.EmailExist;
            var user = new Person() {
                EmailAddress = register.EmailAddress,
                Password = register.Password,
                Address = null,
                Address2 = null,
                City = null,
                Countries = null,
                FirstName=null,
                LastName=null,
                IsAdmin=false,
                IsDelete=false,
                IsActive=true,
                PhoneNumber=12345,
                PostCode=12345,
               
            };
            await unitOfWork.PersonRepository.Insert(user);
            return RegisterUserResult.Success;
        }

        public bool IsUserExistByEmail(string email)
        {
            var res = unitOfWork.PersonRepository.IsUserExistByEmail(email);
            return res;
        }
    }
}
