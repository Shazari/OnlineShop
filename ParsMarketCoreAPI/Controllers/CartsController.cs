using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using ViewModels;
namespace ParsMarketCoreAPI
{
    public class CartsController : BaseApiControllerWithDatabase
    {
        public CartsController(UnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CartViewModel>>> GetCartAsync()
        //{
        //    var result = await UnitOfWork.CartRepository.GetAllAsync();
        //    return Ok(result);
        //}

    }
}
