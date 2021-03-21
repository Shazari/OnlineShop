using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        [Inject]
        public IJSRuntime JsRuntime { get; set; }


        public List<SliderViewModel> sliderViewModel { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            await JsRuntime.InvokeVoidAsync("LoadCustome");

        }


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
