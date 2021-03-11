using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using ViewModels;
using Data;
using Microsoft.EntityFrameworkCore;

namespace ParsMarketCoreAPI
{
    public class AboutsController :BaseApiControllerWithDatabase
    {
        public AboutsController(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutUsViewModel>>> GetAbout()
        {
            var result = await UnitOfWork.AboutUsRepository.GetAllAsync();
            return Ok(value: result);
        }

        //GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutUsViewModel>> GetAbout(int id)
        {
            var aboutUs = await UnitOfWork.AboutUsRepository.GetById(id);

            var newEntity = new AboutUsViewModel
            {
                LinkTitle=aboutUs.LinkTitle,
                Text=aboutUs.Text,
                Title=aboutUs.Title
            };
            if (aboutUs == null)
            {
                return NotFound();
            }

            return newEntity;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutAboutUs(AboutUsViewModel viewModel)
        {
            var aboutUs = await UnitOfWork.AboutUsRepository.GetById(viewModel.Id);

            aboutUs.LinkTitle = viewModel.LinkTitle;
            aboutUs.Title = viewModel.Title;
            aboutUs.Id = viewModel.Id;
            aboutUs.Text = viewModel.Text;

            if (aboutUs.Id != viewModel.Id)
            {
                return BadRequest();
            }
            await UnitOfWork.AboutUsRepository.Update(aboutUs);

            //_context.Entry(person).State = EntityState.Modified;

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(aboutUs.Id))
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
        public async Task<ActionResult<AboutUsViewModel>> PostAboutUs(AboutUsViewModel viewModel)
        {

            var aboutUs = new Models.AboutUs()
            {
                Id = viewModel.Id,
                Text = viewModel.Text,
                CreateDate = DateTime.Now,
                LinkTitle = viewModel.LinkTitle,
                Title=viewModel.Title
                
            };
            await UnitOfWork.AboutUsRepository.Insert(aboutUs);
            //_context.People.Add(person);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetCategory", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAboutUs(int id)
        {
            var aboutUs = await UnitOfWork.AboutUsRepository.GetById(id);
            if (aboutUs == null)
            {
                return NotFound();
            }

            await UnitOfWork.AboutUsRepository.Delete(aboutUs);
            await UnitOfWork.SaveAsync();

            return default;
        }

        private bool IsExists(long id)
        {
            var res = UnitOfWork.AboutUsRepository.IsExist(id);
            return res;
        }

    }
}
