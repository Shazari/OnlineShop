using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Data;
using ViewModels;
namespace ParsMarketCoreAPI
{
    public interface IUserService
    {
        Task<User> GetUserById(long id);
        Task<List<Models.User>> GetAllUsers();
        Task AddUser(Models.User user);
        Task UptateUser(Models.User user);
        Task DeleteUser(long id);

    }
}
