using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarketCoreAPI.Controllers
{
    
    public class AuthController : BaseApiControllerWithDatabase
    {
        public AuthController(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        { }
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> GetRole()
        {
            var result = await UnitOfWork.RoleRepository.GetAllAsync();
            return Ok(value: result);
        }

        //GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewModel>> GetRole(int id)
        {
            var Role = await UnitOfWork.RoleRepository.GetById(id);

            var RoleView = new RoleViewModel
            {
                //Id=Role.Id,
               // Name=Role.Name,
               // Title=Role.NormalizedName
                
            };
            if (Role == null)
            {
                return NotFound();
            }

            return RoleView;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutRole(RoleViewModel viewModel)
        {

            var role = await UnitOfWork.RoleRepository.GetById(viewModel.Id);



            //role.Name = viewModel.Name;
           // role.NormalizedName = viewModel.Title;


         
            //if (role.Id != viewModel.Id)
            //{
            //    return BadRequest();
            //}
            await UnitOfWork.RoleRepository.Update(role);

            //_context.Entry(person).State = EntityState.Modified;

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!IsExists(role.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("SignIn")]
        public async Task<ActionResult<LoginViewModel>> PostRole(RoleViewModel viewModel)
        {

            var Role = new Models.Roles()
            {
               // NormalizedName=viewModel.Title,
               //Name=viewModel.Name,
               //Title=viewModel.Title

            };
          
            await UnitOfWork.RoleRepository.Insert(Role);
            //_context.People.Add(person);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetRole", new { viewModel });
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Roles>> DeleteRole(int id)
        {
            var Role = await UnitOfWork.RoleRepository.GetById(id);
            if (Role == null)
            {
                return NotFound();
            }

            await UnitOfWork.RoleRepository.Delete(Role);
            await UnitOfWork.SaveAsync();

            return Role;
        }

        private bool IsExists(int id)
        {
            var res = UnitOfWork.RoleRepository.IsExist(id);
            return res;
        }

    }
}
