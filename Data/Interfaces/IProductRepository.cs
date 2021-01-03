using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
   public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductById(int id);
    }
}
