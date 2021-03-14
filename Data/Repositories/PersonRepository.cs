using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ParsMarketDbContext databaseContext) : base(databaseContext)
        {

        }

        public virtual async Task<Person> GetPersonForLogin(string email, string password)
        {
            try
            {
                var user = await DbSet.SingleOrDefaultAsync(e => e.EmailAddress == email.ToLower().Trim() && e.Password == password);
                return user;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
        public virtual async Task<Person> GetPersonByEmail(string email)
        {
            var person = await DbSet.SingleOrDefaultAsync(e=>e.EmailAddress==email.ToLower().Trim());
            return person;
        }

       

        public bool IsPersonExist(long id)
        {
            var b = DbSet.Any(e => e.Id == id);
            return b;
        }

        public bool IsUserExistByEmail(string email)
        {
            var res = DbSet.Any(e => e.EmailAddress == email.ToLower().Trim());
            return res;
        }
    }
}
