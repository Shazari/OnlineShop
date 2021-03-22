using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using ViewModels;
using Models;
using Microsoft.EntityFrameworkCore;

namespace ParsMarketCoreAPI
{

    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;
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

        public async Task UpdateProduct(Product Product)
        {
            await unitOfWork.ProductRepository.Update(Product);
        }

        public async Task DeleteProduct(Product Product)
        {
            await unitOfWork.ProductRepository.Delete(Product);
        }

        public async Task<FilterProduct> FilterProduct(FilterProduct filter)
        {
            var productQuery = unitOfWork.ProductRepository.GetEntitiesQuery();
           
            if (!string.IsNullOrEmpty(filter.Title))
                productQuery = productQuery.Where(s => s.Name.Contains(filter.Title));

            productQuery = productQuery.Where(s => s.Price >= filter.StartPrice && s.Price <= filter.EndPrice);

            var count = (int)Math.Ceiling(productQuery.Count() / (double)filter.TakeEntity);
            var pager = Pager.Build(count, filter.PageID, filter.TakeEntity);
            var products = await productQuery.Paging(pager).ToListAsync();
            return filter.SetProducts(products).SetPaging(pager);
        }
    }
}
