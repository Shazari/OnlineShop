using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using Models;
namespace ParsMarketCoreAPI
{
   public interface ISliderService
    {
        Task<List<SliderViewModel>> GetAllSliders();

        Task<List<SliderViewModel>> GetActiveSliders();
        Task AddSlider(Slider slider);
        Task UpdateSlider(Slider slider);
        Task<Slider> GetSliderById(long id);

    }
}
