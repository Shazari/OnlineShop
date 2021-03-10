using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using Data;
namespace ParsMarketCoreAPI
{
    public class SliderService : ISliderService
    {
        public SliderService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public UnitOfWork   UnitOfWork { get; set; }
        public Task AddSlider(Slider slider)
        {
           
            throw new NotImplementedException();
        }

        public Task<List<SliderViewModel>> GetActiveSliders()
        {
            throw new NotImplementedException();
        }

        public Task<List<SliderViewModel>> GetAllSliders()
        {
            throw new NotImplementedException();
        }

        public Task<Slider> GetSliderById(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSlider(Slider slider)
        {
            throw new NotImplementedException();
        }
    }
}
