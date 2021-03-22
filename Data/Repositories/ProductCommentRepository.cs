using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductCommentRepository:Repository<ProductComment>,IProductCommentRepository
    {
        internal ProductCommentRepository(ParsMarketDbContext databaseContext) : base(databaseContext)
        { }
    }
}
