using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsMarketCoreAPI
{

    public class SlidersController : BaseApiControllerWithDatabase
    {
        private ISliderService sliderService;
        public SlidersController(IUnitOfWork UnitOfWork,ISliderService SliderService) : base(UnitOfWork)
        {
            sliderService = SliderService;
        }
        #region AllActiveSliders

        [HttpGet("GetActiveSliders")]
        public async Task<IActionResult> GetActiveSliders()
        {
            var sliders = await sliderService.GetActiveSliders();
            return JsonResponseStatus.Success(sliders);
        }

        #endregion
    }
}
