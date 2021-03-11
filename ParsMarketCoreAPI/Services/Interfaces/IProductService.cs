using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using ViewModels;
using Models;
namespace ParsMarketCoreAPI
{
  public  interface IProductService
    {
        #region Product
        Task<IEnumerable<Product>> GetAllProduct();
        Task AddProduct(Product Product);
        Task UpdatePRoduct(Product Product);
        Task DeleteProduct(Product Product);
        #endregion
    }
}
