using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using ViewModels;
using Models;
namespace ParsMarketCoreAPI
{

    public class ProductService:IProductService
    {
        public IUnitOfWork unitOfWork { get; }
        public ProductService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            var result = await unitOfWork.ProductRepository.GetAllAsync();
            return result;
        }

        public async Task AddProduct(Product Product)
        {
            await unitOfWork.ProductRepository.Insert(Product);
        }

        public async Task UpdatePRoduct(Product Product)
        {
            await unitOfWork.ProductRepository.Update(Product);
        }

        public async Task DeleteProduct(Product Product )
        {
            await unitOfWork.ProductRepository.Delete(Product);
        }
    }
}
