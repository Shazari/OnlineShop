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

    public class PeopleController : BaseApiControllerWithDatabase
    {

        public PeopleController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPeople()
        {
            var result = await UnitOfWork.PersonRepository.GetAllAsync();
            return Ok(value: result);
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonViewModel>> GetPerson(int id)
        {
            var person = await UnitOfWork.PersonRepository.GetById(id);
            if (person == null)
            {
                return BadRequest("person null");
            }
            var Person = new PersonViewModel()
            {
               // Id = person.Id,
                EmailAddress = person.EmailAddress,
                Address = person.Address,
                City = person.City,

                Countries = person.Countries,
                FirstName = person.FirstName,
                IsActive = person.IsActive,
                IsAdmin = person.IsAdmin,
                LastName = person.LastName,
                Password = person.Password,
                PhoneNumber = person.PhoneNumber,
                PostCode = person.PostCode,
            };
            person.Orders = new List<Cart>
            {

            };
            if (person == null)
            {
                return NotFound();
            }

            return Person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutPerson(PersonViewModel viewModel)
        {
            var person = await UnitOfWork.PersonRepository.GetById(viewModel.Id);
            //person.Id = viewModel.Id;
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

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(PersonViewModel viewModel, int id)
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

            return NoContent();
        }
        // POST: api/People
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("register")]
        public async Task<ActionResult<PersonViewModel>> PostPerson([FromBody] PersonViewModel viewModel)
        {
            var person = new Person()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                EmailAddress = viewModel.EmailAddress,
                Password = viewModel.Password,
                Address = viewModel.Address,
                //Id = viewModel.Id,
                City = viewModel.City,
                Countries = viewModel.Countries,
               // InsertDateTime = DateTime.Now,
                IsActive = viewModel.IsActive,
                IsAdmin = viewModel.IsAdmin,
                PhoneNumber = viewModel.PhoneNumber,
                PostCode = viewModel.PostCode,
                Role = null,
                Orders=null,

            };
            await UnitOfWork.PersonRepository.Insert(person);
            //_context.People.Add(person);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetPerson", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/People/5
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

        private bool IsExists(int id)
        {
            return UnitOfWork.PersonRepository.IsExist(id);
        }
    }
}

