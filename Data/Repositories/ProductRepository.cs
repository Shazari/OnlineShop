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
        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            var product = await DbSet.Include(p=>p.Codes).Include(p=>p.Categories).ToListAsync();
            return product;
        }
        public Task<Product> GetProductById(int id)
        {
            var product =  DbSet.Include(p => p.Codes).Include(p => p.Categories).FirstAsync(p=>p.Id==id);
            return product;
        }
    }
}
