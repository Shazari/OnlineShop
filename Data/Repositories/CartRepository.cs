using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
   public class CartRepository: Repository<Cart>, ICartRepository
    {
        internal CartRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {

        }
    }
}
