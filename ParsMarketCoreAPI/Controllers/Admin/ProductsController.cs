using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace ParsMarketCoreAPI.Controllers
{
    public class ProductsController : BaseApiControllerWithDatabase
    {
        private IProductService _productService;

        public ProductsController(IUnitOfWork UnitOfWork, IWebHostEnvironment Env, IProductService productService) : base(UnitOfWork)
        {
            _productService = productService;
            env = Env;
        }
        private readonly IWebHostEnvironment env;

       

        [HttpGet("GetProducts")]
        public async Task<ActionResult<FilterProduct>> GetProducts([FromQuery] FilterProduct filter)
        {
            var products = await _productService.FilterProduct(filter);
            return Ok(products);
        }

       

        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Get()
        {
            var result = await UnitOfWork.ProductRepository.GetAllAsync();
            return Ok(value: result);
        }

        //GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Get(int id)
        {
            var product = await UnitOfWork.ProductRepository.GetProductById(id);

            var ProductView = new ProductViewModel
            {
                //TODO
                Image = product.Image,
                Name = product.Name,
                Id = product.Id,

                LongDescription = product.LongDescription,
                ShortDescription = product.ShortDescription,


            };
            if (product == null)
            {
                return NotFound();
            }

            return ProductView;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("EditProduct")]
        public async Task<IActionResult> PutProduct(ProductViewModel viewModel)
        {
            var product = await UnitOfWork.ProductRepository.GetById(viewModel.Id);
            product.Id = viewModel.Id;
            product.Image = viewModel.Image;
            product.ShortDescription = viewModel.ShortDescription;
            product.LongDescription = viewModel.LongDescription;
            product.Name = viewModel.Name;
            product.Price = viewModel.Price;
             var categories = await UnitOfWork.CategoryRepository.GetAllAsync();
            var selectedCategory = await UnitOfWork.ProductSelectedCategoryRepository.GetAllAsync();
            product.ProductSelectedCategories = selectedCategory.Where(cat => viewModel.CategoriesId.Contains(cat.Id)).ToList();

            if (product.Id != viewModel.Id)
            {
                return BadRequest();
            }
            await UnitOfWork.ProductRepository.Update(product);


            //_context.Entry(person).State = EntityState.Modified;

            try
            {
                UnitOfWork.Save();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> PostProduct([FromBody] ProductViewModel viewModel)
        {

            var product = new Models.Product()
            {

                Name = viewModel.Name,
                Image = viewModel.Image,
                CreateDate = DateTime.Now,
                LongDescription = viewModel.LongDescription,
                Price = viewModel.Price,
                ShortDescription = viewModel.ShortDescription,
                IsExist=viewModel.IsExist,
                

            };
            //var categiories = new List<Category>();
            //viewModel.CategoryViewModel.ForEach(cat => categiories.Add(
            //    new Category
            //    {
            //        Description = cat.Description,
            //        Id = cat.Id,
            //        Name = cat.Name,
            //    }
            //    ));
            //product.Categories = categiories;
            //var categories = await UnitOfWork.CategoryRepository.GetAllAsync();
            //product.Categories = categories.Where(cat => viewModel.CategoriesId.Contains(cat.Id)).ToList();

            var selectedCategory = await UnitOfWork.ProductSelectedCategoryRepository.GetAllAsync();
            product.ProductSelectedCategories = selectedCategory.Where(cat => viewModel.CategoriesId.Contains(cat.Id)).ToList();

            await UnitOfWork.ProductRepository.Insert(product);
            

            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetProduct", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await UnitOfWork.ProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            await UnitOfWork.ProductRepository.Delete(product);
            await UnitOfWork.SaveAsync();

            return product;
        }

        private bool IsExists(long id)
        {
            var res = UnitOfWork.ProductRepository.IsExist(id);
            return res;
        }

        

    }
}
