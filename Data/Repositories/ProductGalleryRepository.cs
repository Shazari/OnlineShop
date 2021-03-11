using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
    public class ProductGalleryRepository : Repository<ProductGallery>, IProductGalleryRepository
    {
        internal ProductGalleryRepository(ParsMarketDbContext parsMarketDbContext) : base(parsMarketDbContext)
        { 
        }
    }
}
