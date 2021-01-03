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

    public class OffCodesController : BaseApiControllerWithDatabase
    {
        public OffCodesController(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }

        public async Task<ActionResult<IEnumerable<OffCodeViewModel>>> GetOffCode()
        {
            var result = await UnitOfWork.OffCodeRepository.GetAllAsync();
            return Ok(value: result);
        }

        //GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OffCodeViewModel>> GetOffCode(int id)
        {
            var offCode = await UnitOfWork.OffCodeRepository.GetById(id);

            var offCodeView = new OffCodeViewModel
            {
                Code=offCode.Code,
                Title=offCode.Title,
                Products= (ICollection<ProductViewModel>)offCode.Products,
                Id=offCode.Id
            };
            if (offCode == null)
            {
                return NotFound();
            }

            return offCodeView;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutOffCode(OffCodeViewModel viewModel)
        {
            var getId = await UnitOfWork.OffCodeRepository.GetById(viewModel.Id);
            var offCodeUpdate = new Models.OffCodes
            {
                Id = viewModel.Id,
                Code = viewModel.Code,
                Products= (ICollection<Product>)viewModel.Products,
                Title=viewModel.Title,

            };
            if (getId.Id != viewModel.Id)
            {
                return BadRequest();
            }
            await UnitOfWork.OffCodeRepository.Update(offCodeUpdate);

            //_context.Entry(person).State = EntityState.Modified;

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(getId.Id))
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
        public async Task<ActionResult<OffCodeViewModel>> PostCategory(OffCodeViewModel viewModel)
        {

            var offCode = new Models.OffCodes()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                InsertDateTime = DateTime.Now,
                Code = viewModel.Code,
                Products= (ICollection<Product>)viewModel.Products,
            };
            await UnitOfWork.OffCodeRepository.Insert(offCode);
            //_context.People.Add(person);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetOffCode", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OffCodes>> DeleteOffCode(int id)
        {
            var offCode = await UnitOfWork.OffCodeRepository.GetById(id);
            if (offCode == null)
            {
                return NotFound();
            }

            await UnitOfWork.OffCodeRepository.Delete(offCode);
            await UnitOfWork.SaveAsync();

            return offCode;
        }

        private bool IsExists(int id)
        {
            var res = UnitOfWork.OffCodeRepository.IsExist(id);
            return res;
        }

    }
}
