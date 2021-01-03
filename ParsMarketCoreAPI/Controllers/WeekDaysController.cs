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

    public class WeekDaysController : BaseApiControllerWithDatabase
    {
        public WeekDaysController(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }

        public async Task<ActionResult<IEnumerable<DayWeekViewModel>>> GetWeekDay()
        {
            var result = await UnitOfWork.WeekDayRepository.GetAllAsync();
            return Ok(value: result);
        }

        //GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DayWeekViewModel>> GetWeekDay(int id)
        {
            var WeekDay = await UnitOfWork.WeekDayRepository.GetById(id);

            var WeekDayView = new DayWeekViewModel
            {
                Day = WeekDay.Day,
                StartTime = WeekDay.StartTime,
                EndTime = WeekDay.EndTime
            };
            if (WeekDay == null)
            {
                return NotFound();
            }

            return WeekDayView;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutWeekDay(DayWeekViewModel viewModel)
        {
            var getId = await UnitOfWork.WeekDayRepository.GetById(viewModel.Id);
            var WeekDayUpdate = new Models.DayWeek
            {
                Day = viewModel.Day,
                StartTime = viewModel.StartTime,
                EndTime= viewModel.EndTime,

            };
            if (getId.Id != viewModel.Id)
            {
                return BadRequest();
            }
            await UnitOfWork.WeekDayRepository.Update(WeekDayUpdate);

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
        public async Task<ActionResult<DayWeekViewModel>> PostWeekDay(DayWeekViewModel viewModel)
        {

            var WeekDay = new Models.DayWeek()
            {
                Id = viewModel.Id,
                Day = viewModel.Day,
                InsertDateTime = DateTime.Now,
                EndTime = viewModel.EndTime,
                StartTime=viewModel.StartTime
              
            };
            await UnitOfWork.WeekDayRepository.Insert(WeekDay);
            //_context.People.Add(person);
            await UnitOfWork.SaveAsync();

            return CreatedAtAction("GetWeekDay", new { id = viewModel.Id }, viewModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DayWeek>> DeleteWeekDay(int id)
        {
            var WeekDay = await UnitOfWork.WeekDayRepository.GetById(id);
            if (WeekDay == null)
            {
                return NotFound();
            }

            await UnitOfWork.WeekDayRepository.Delete(WeekDay);
            await UnitOfWork.SaveAsync();

            return WeekDay;
        }

        private bool IsExists(int id)
        {
            var res = UnitOfWork.WeekDayRepository.IsExist(id);
            return res;
        }

    }
}
