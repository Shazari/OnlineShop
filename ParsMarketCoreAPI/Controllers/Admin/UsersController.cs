using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using ViewModels;
using Microsoft.AspNetCore.Http;
using Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<PersonViewModel>> GetPerson(long id)
        {
            var person = await UnitOfWork.PersonRepository.GetById(id);
            if (person == null&&!person.IsActive)
            {
                return BadRequest("person null");
            }
            var Person = new PersonViewModel()
            {
                 Id = person.Id,
                EmailAddress = person.EmailAddress,
                Address = person.Address,
                City = person.City,

                Countries = person.Countries,
                FirstName = person.FirstName,
               
               
                PhoneNumber = person.PhoneNumber,
                PostCode = person.PostCode,
            };
           

            return Ok(Person);
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
                    EmailAddress = viewModel.EmailAddress,
                    Password = viewModel.Password,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,

                    Address = viewModel.Address,
                    //Id = viewModel.Id,
                    City = viewModel.City,
                    Countries = viewModel.Countries,
                    //InsertDateTime = DateTime.Now,
                    IsActive = viewModel.IsActive,
                    IsAdmin = viewModel.IsAdmin,
                    PhoneNumber = viewModel.PhoneNumber,
                    PostCode = viewModel.PostCode,
                    Orders = null,
                    Role = null,


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
        public async Task<IActionResult> PutPerson(PersonViewModel viewModel, long id)
        {
            var person = await UnitOfWork.PersonRepository.GetById(viewModel.Id);

            person.FirstName = viewModel.FirstName;
            person.LastName = viewModel.LastName;
            person.Address = viewModel.Address;
            person.Address2 = viewModel.Address;
            person.PostCode = viewModel.PostCode;
            person.City = viewModel.City;
            person.Countries = viewModel.Countries;
            person.IsActive = viewModel.IsActive;
            person.IsAdmin = viewModel.IsAdmin;
            person.EmailAddress = viewModel.EmailAddress;
            person.PhoneNumber = viewModel.PhoneNumber;
            person.Password = viewModel.Password;

            await UnitOfWork.PersonRepository.Update(person);

            //_context.Entry(person).State = EntityState.Modified;

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!IsExists(person.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return Ok(viewModel);
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
