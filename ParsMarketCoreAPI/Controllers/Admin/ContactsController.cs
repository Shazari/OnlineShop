using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarketCoreAPI.Controllers
{
    
 
    public class ContactsController :BaseApiControllerWithDatabase
    {
        public ContactsController(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactViewModel>>> GetContact()
        {
            var result = await UnitOfWork.ContactRepository.GetAllAsync();
            return Ok(value: result);
        }

        //GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactViewModel>> Get(int id)
        {
            var contact = await UnitOfWork.ContactRepository.GetById(id);
            var ContactView = new ContactViewModel 
            { 
                Email =contact.Email,
                Id=contact.Id,
                Name=contact.Name,
                Telephone=contact.Telephone,

                Text=contact.Text
            };
            if (contact == null)
            {
                return NotFound();
            }

            return ContactView;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutContact(ContactViewModel viewModel)
        {
            var contact = await UnitOfWork.ContactRepository.GetById(viewModel.Id);

            contact.Id = viewModel.Id;
            contact.Email = viewModel.Email;
            contact.Name = viewModel.Name;
            contact.Telephone = viewModel.Telephone;
            contact.Text = viewModel.Text; 
       
            if (contact.Id != viewModel.Id)
            {
                return BadRequest();
            }
        await UnitOfWork.ContactRepository.Update(contact);

            //_context.Entry(person).State = EntityState.Modified;

        try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExists(contact.Id))
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
        public async Task<ActionResult<ContactViewModel>> PostPerson(ContactViewModel viewModel)
        {
            var contact = new Models.Contact()
            {
                Email = viewModel.Email,
                CreateDate = viewModel.RegisterDate,
                Telephone=viewModel.Telephone,
                Name=viewModel.Name,
                Text=viewModel.Text
                };
            await UnitOfWork.ContactRepository.Insert(contact);
            //_context.People.Add(person);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetContact", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeletePerson(int id)
        {
            var contact = await UnitOfWork.ContactRepository.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            await UnitOfWork.ContactRepository.Delete(contact);
            await UnitOfWork.SaveAsync();

            return contact;
        }

        private bool IsExists(long id)
        {
            var res= UnitOfWork.ContactRepository.IsExist(id);
            return res;
        }
    }
}
