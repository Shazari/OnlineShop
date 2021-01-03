using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Models;
using ViewModels;
namespace ParsMarketCoreAPI.Controllers
{
    

    public class BasketsController:BaseApiControllerWithDatabase
    {
        public BasketsController(IUnitOfWork unitOfWork):base(unitOfWork)
        { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAsync()
        {
            var result =await UnitOfWork.ProductRepository.GetAllAsync();
            
            return Ok(result);
        }


    }
}
