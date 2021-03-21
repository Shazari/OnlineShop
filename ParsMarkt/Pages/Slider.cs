using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Pages
{
    public partial class Slider
    {
        public Slider()
        {
            sliderViewModel = new List<SliderViewModel>();
        }
        [Inject]
        public ISliderServices SliderService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<SliderViewModel> sliderViewModel { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                var result = await SliderService.GetActiveSlider();
                if (result!=null)
                {
                    sliderViewModel = result;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }
          
           
        }
    }
}
