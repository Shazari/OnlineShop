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
        public IUnitOfWork UnitOfWork { get; }
        public UserService(UnitOfWork unitOfWork)
        {
            UnitOfWork = UnitOfWork;
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
    }
}
