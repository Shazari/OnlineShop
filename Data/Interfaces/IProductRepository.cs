using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
   public interface IProductRepository:IRepository<Product>
    {
       IQueryable<Product> GetEntitiesQuery();
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductById(int id);
    }
}
