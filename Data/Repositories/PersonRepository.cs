using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
    public class PersonRepository:Repository<Person>,IPersonRepository
    {
        internal PersonRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {

        }

        public bool IsPersonExist(int id)
        {
            return DbSet.Any(e=>e.Id==id);
        }

      
    }
}
