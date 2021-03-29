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

            productQuery = productQuery.Where(s => s.Price >= filter.StartPrice);


            if (filter.Categories!=null&&filter.Categories.Any())
            {
                productQuery = productQuery.SelectMany(s=>s.ProductSelectedCategories.Where(f=>filter.Categories.Contains(f.CategoryId)).Select(t=>t.product));
            }


            if (filter.EndPrice != 0)
            {
                productQuery = productQuery.Where(s => s.Price <= filter.EndPrice);
            }

            var count = (int)Math.Ceiling(productQuery.Count() / (double)filter.TakeEntity);
            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);
            var products = await productQuery.Paging(pager).ToListAsync();
            return filter.SetProducts(products).SetPaging(pager);
        }

        public async Task<List<Category>> GetAllActiveProductCategories()
        {
            var result = await unitOfWork.CategoryRepository.GetAllAsync();
            return result.Where(s=>!s.IsDelete).ToList();
        }
    }
}
