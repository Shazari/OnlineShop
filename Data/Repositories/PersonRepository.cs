using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
    public class PersonRepository :Repository<Person>,IPersonRepository
    {
        public PersonRepository(ParsMarketDbContext databaseContext) : base(databaseContext)
        {

        }

        public bool IsPersonExist(string  id)
        {
            //var b=DbSet.Any(e => e.Id == id);
            return true;
        }
    }
}
