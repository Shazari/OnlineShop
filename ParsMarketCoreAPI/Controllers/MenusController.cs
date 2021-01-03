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

    public class MenusController : BaseApiControllerWithDatabase
    {
        private readonly ILogger<MenusController> _logger;
        public MenusController(IUnitOfWork unitOfWork, ILogger<MenusController> Logger) : base(unitOfWork)
        {
            _logger = Logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetAsync()
        {
            var result = await UnitOfWork.MenuRepository.GetAllAsync();

            return Ok(value: result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetByIdAsync(int id)
        {
            var result = await UnitOfWork.MenuRepository.GetById(id);

            return Ok(value: result);
        }


        [HttpPost]
        public async Task<ActionResult<Menu>> Insert(ViewModels.MenuViewModel viewModel)
        {
            try
            {
                var parent = await UnitOfWork.MenuRepository.GetById(1);

                var NewEntity = new Menu()
                {
                    Name = viewModel.Name,
                    PageUrl = viewModel.PageUrl,
                    InsertDateTime=DateTime.Now,
                    Parent = null,

                };

                await UnitOfWork.MenuRepository.Insert(NewEntity);
                await UnitOfWork.SaveAsync();
                return Ok(value: NewEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(value: null);
            }

        }
        [HttpPut]
        public async Task<IActionResult> PutMenu(ViewModels.MenuViewModel viewModel)
        {
            try
            {
                if (viewModel == null)
                {
                    return BadRequest();
                }
                else
                {
                    var parent = await UnitOfWork.MenuRepository.GetById(1);
                    var menu = await UnitOfWork.MenuRepository.GetById(viewModel.Id);
                    menu.Name = viewModel.Name;
                    menu.PageUrl = viewModel.PageUrl;
                    menu.Parent = parent;

                    await UnitOfWork.MenuRepository.Update(menu);
                    await UnitOfWork.SaveAsync();
                    return Ok(value: menu);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(value: null);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ViewModels.MenuViewModel> DeleteAsync(int id)
        {
            try
            {
                if (id == null)
                {

                }
                var menu = await UnitOfWork.MenuRepository.GetById(id);
                if (menu == null)
                {

                }

                await UnitOfWork.MenuRepository.Delete(menu);
                await UnitOfWork.SaveAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return default;
        }

        private bool IsMenuExists(int id)
        {
            return UnitOfWork.MenuRepository.IsExist(id);
        }

    }
}




