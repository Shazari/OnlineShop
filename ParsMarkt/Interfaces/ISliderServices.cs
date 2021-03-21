using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface ISliderServices
    {
        Task<List<SliderViewModel>> GetActiveSlider();
        Task<SliderViewModel> AddSlider(SliderViewModel viewModel);

    }
}
