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

    public class OrdersController : BaseApiControllerWithDatabase
    {
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(IUnitOfWork unitOfWork, ILogger<OrdersController> Logger) : base(unitOfWork)
        {
            _logger = Logger;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrder()
        {
            var result = await UnitOfWork.OrderRepository.GetAllAsync();
            return Ok(value: result);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var Order = await UnitOfWork.OrderRepository.GetById(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order Order)
        {
            var order = UnitOfWork.OrderRepository.GetById(Order.Id);
            if (order.Id != Order.Id)
            {
                return BadRequest();
            }
            await UnitOfWork.OrderRepository.Update(Order);

            //_context.Entry(Order).State = EntityState.Modified;

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsOrderExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoginViewModel>> PostOrder(OrderViewModel order)
        {
            var person = await UnitOfWork.PersonRepository.GetById(order.Person.Id);
            var Order2 = new Order()
            {
                InsertDateTime = DateTime.Now,
                Person = person,
                IsFinaly = true,
                CreateDate = DateTime.Now,
            };
            await UnitOfWork.OrderRepository.Insert(Order2);
            //_context.Order.Add(Order);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetOrder", new { id = Order2.Id }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var Order = await UnitOfWork.OrderRepository.GetById(id);
            if (Order == null)
            {
                return NotFound();
            }

            await UnitOfWork.OrderRepository.Delete(Order);
            await UnitOfWork.SaveAsync();

            return Order;
        }

        private bool IsOrderExists(int id)
        {
            return UnitOfWork.OrderRepository.IsExist(id);
        }
    }
}

