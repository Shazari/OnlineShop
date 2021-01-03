using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
   public class OffCodesRepository:Repository<OffCodes>, IOffCodeRepository
    {
        internal OffCodesRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {

        }

      

        public async Task<IEnumerable<OffCodes>> GetAllOffCodesAsync()
        {
            var cartItems = await DbSet.Include(c => c.Products).ToListAsync();
            return cartItems;
        }
    }
}
