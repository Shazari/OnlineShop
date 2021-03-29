using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using ViewModels;
using Microsoft.EntityFrameworkCore;
namespace ParsMarketCoreAPI.Controllers
{

    public class CategoriesController : BaseApiControllerWithDatabase
    {
        public CategoriesController(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        [HttpGet("GetActiveCategories")]
        public async Task<ActionResult<IEnumerable<CategoriesViewModel>>> Getcategory()
        {
            var category = await UnitOfWork.CategoryRepository.GetAllAsync();
            var result = category.Where(c => !c.IsDelete).ToList();
            return Ok(value: result);
        }

        //GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriesViewModel>> GetCategory(int id)
        {
            var category = await UnitOfWork.CategoryRepository.GetById(id);
         
            var categoryView = new CategoriesViewModel
            {
                Description = category.UrlTitle,
                Title = category.Title,
                Id = category.Id,
                
            };
            if (category == null)
            {
                return NotFound();
            }

            return Ok(categoryView);
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPut]
        public async Task<IActionResult> PutCategory(CategoriesViewModel viewModel)
        {
            var category = await UnitOfWork.CategoryRepository.GetById(viewModel.Id);

            category.UrlTitle = viewModel.Description;
            category.Title = viewModel.Title;
            category.Id = viewModel.Id;


            if (category.Id != viewModel.Id)
            {
                return BadRequest();
            }
            await UnitOfWork.CategoryRepository.Update(category);

            //_context.Entry(person).State = EntityState.Modified;

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(category.Id))
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
        public async Task<ActionResult<CategoriesViewModel>> PostCategory(CategoriesViewModel viewModel)
        {

            var category = new Models.Category()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                CreateDate = DateTime.Now,
                UrlTitle = viewModel.Description
            };
            await UnitOfWork.CategoryRepository.Insert(category);
            //_context.People.Add(person);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetCategory", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await UnitOfWork.CategoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            await UnitOfWork.CategoryRepository.Delete(category);
            await UnitOfWork.SaveAsync();

            return default;
        }

        private bool IsExists(long id)
        {
            var res = UnitOfWork.CategoryRepository.IsExist(id);
            return res;
        }

    }
}
