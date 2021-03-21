using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt
{
    public class SliderServices : BaseServices, ISliderServices
    {
        public SliderServices(HttpClient client):base(client)
        {

        }
        public string Url;
        public async Task<List<SliderViewModel>> GetActiveSlider()
        {
            Url = "GetActiveSliders";
            RequestUri = $"{BaseUrl}/{GetApiUrl()}/{Url}";
            var result =await  GetAsync<List<SliderViewModel>>();
            if (result==null)
            {
                Console.WriteLine("ErrorSLider");
            }
            return result;
        }

        public async Task<SliderViewModel> AddSlider(SliderViewModel viewModel)
        {
            Url = "AddSlider";
            RequestUri = $"{BaseUrl}/{GetApiUrl()}/{Url}";
            var res = await PostAsync<SliderViewModel,SliderViewModel>(viewModel);
            if (res==null)
            {
                Console.WriteLine("Alaki Slider");
            }
            return res;
        }
        protected override string GetApiUrl()
        {
            return "Sliders";
        }

       
    }
}
