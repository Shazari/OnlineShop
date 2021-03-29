using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace Data
{
   public class ProductRepository:Repository<Product>,IProductRepository
    {
        internal ProductRepository(ParsMarketDbContext databaseContex) : base(databaseContex)
        { }

        public IQueryable<Product> GetEntitiesQuery()
        {
            var result = DbSet.AsQueryable();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            var product = await DbSet.Include(p=>p.Codes).Include(p=>p.ProductSelectedCategories).ToListAsync();
            return product;
        }
        public Task<Product> GetProductById(int id)
        {
            var product =  DbSet.Include(p => p.Codes).Include(p => p.ProductSelectedCategories).FirstAsync(p=>p.Id==id);
            return product;
        }
    }
}
