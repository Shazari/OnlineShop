using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using ViewModels;
using Microsoft.AspNetCore.Http;
using Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParsMarketCoreAPI.Controllers
{
    
    public class UsersController :BaseApiControllerWithDatabase
    {
        public UsersController(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPerson()
        {
            var result = await UnitOfWork.PersonRepository.GetAllAsync();
            return Ok(value: result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<PersonViewModel>> PostUsers(PersonViewModel viewModel)
        {

            try
            {
                if (viewModel==null)
                {
                    return BadRequest();
                }
                else
                {

                
                var person = new Models.Person()
                {
                    
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    EmailAddress = viewModel.EmailAddress,
                    Password = viewModel.Password,
                    Address = viewModel.Address,
                    Id = viewModel.Id,
                    City = viewModel.City,
                    Countries = viewModel.Countries,
                    InsertDateTime = DateTime.Now,
                    IsActive = viewModel.IsActive,
                    IsAdmin = viewModel.IsAdmin,
                    PhoneNumber = viewModel.PhoneNumber,
                    PostCode = viewModel.PostCode,
                    Orders=null,
                    Role=null,

                };

               


                await UnitOfWork.PersonRepository.Insert(person);
                //_context.People.Add(person);
                await UnitOfWork.SaveAsync();
            }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error rerieving data from database");
            }

            return CreatedAtAction("GetPerson", new { id = viewModel.Id }, viewModel);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonViewModel>> DeletePerson(int id)
        {
            var person = await UnitOfWork.PersonRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            var personViewMode = new PersonViewModel
            {

            };
            await UnitOfWork.PersonRepository.Delete(person);
            await UnitOfWork.SaveAsync();

            return personViewMode;
        }
    }
}
