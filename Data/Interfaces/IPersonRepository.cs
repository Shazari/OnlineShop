using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
    public interface IPersonRepository:IRepository<Person>
    {
        bool IsPersonExist(long id);
       bool IsUserExistByEmail(string email);
        Task<Person> GetPersonForLogin(string email,string password);
        Task<Person> GetPersonByEmail(string email);
    }
}
