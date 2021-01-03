using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
   public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        internal CategoryRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {
                
        }
    }
}
