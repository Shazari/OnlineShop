using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
    public class OrderDetailsRepository : Repository<OrderDetail>, IOrderDetailsRepository
    {
        internal OrderDetailsRepository(ParsMarketDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
