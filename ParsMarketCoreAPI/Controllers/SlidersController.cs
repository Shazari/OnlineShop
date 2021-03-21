using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarketCoreAPI
{

    public class SlidersController : BaseApiControllerWithDatabase
    {
        private ISliderService sliderService;
        public SlidersController(IUnitOfWork UnitOfWork, ISliderService SliderService) : base(UnitOfWork)
        {
            sliderService = SliderService;
        }
        #region AllActiveSliders

        [HttpGet("GetActiveSliders")]
        public async Task<ActionResult<IEnumerable<SliderViewModel>>> GetActiveSliders()
        {
            var sliders = await sliderService.GetActiveSliders();
            return JsonResponseStatus.Success(sliders);
        }

        [HttpPost("AddSlider")]
        public async Task<ActionResult> PostSlider([FromBody] SliderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var slider = new Models.Slider
            {
                CreateDate = DateTime.Now,
                Description = viewModel.Description,
                ImageName = viewModel.ImageName,
                SmallImageName = viewModel.SmallImageName,
                Title = viewModel.Title,
                IsDelete = false,
                LastUpdateDate = DateTime.Now,
                Link = viewModel.Link
            };

            try
            {
                await UnitOfWork.SliderRepository.Insert(slider);
                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                throw new Exception("BadRequest INsert");
            }
            

            return JsonResponseStatus.Success(viewModel);
        }

        #endregion
    }
}
