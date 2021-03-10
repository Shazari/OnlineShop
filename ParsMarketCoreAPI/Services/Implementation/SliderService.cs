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
        public UnitOfWork UnitOfWork { get; set; }

        public async Task AddSlider(Slider slider)
        {
            await UnitOfWork.SliderRepository.Insert(slider);

        }

        public async Task<List<Slider>> GetActiveSliders()
        {
            var res = await UnitOfWork.SliderRepository.GetAllAsync();
            return res.Where(s => !s.IsDelete).ToList();
        }

        public async Task<List<Slider>> GetAllSliders()
        {
            var result = await UnitOfWork.SliderRepository.GetAllAsync();
            return result.ToList();
        }

        public async Task<Slider> GetSliderById(long id)
        {
            var result = await UnitOfWork.SliderRepository.GetById(id);
            return result;
        }

        public async Task UpdateSlider(Slider slider)
        {
            await UnitOfWork.SliderRepository.Update(slider);
        }


    }
}
