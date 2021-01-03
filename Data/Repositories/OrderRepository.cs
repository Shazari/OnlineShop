using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
   public class OrderRepository:Repository<Order>,IOrderRepository
    {
        internal OrderRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {

        }
    }
}
