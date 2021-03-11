using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
   public class ProductSelectedCategoryRepository : Repository<ProductSelectedCategory>, IProductSelectedCategoryRepository
    {
        internal ProductSelectedCategoryRepository(ParsMarketDbContext parsMarketDbContext) : base(parsMarketDbContext)
        {
        }
    }
}
