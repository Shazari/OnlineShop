using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
    interface IWeekDayServices
    {
        Task<IList<DayWeekViewModel>> GetAsync();
        Task<DayWeekViewModel> PostAsync(DayWeekViewModel viewModel);
        Task<DayWeekViewModel> PutAsync(DayWeekViewModel viewModel, int id);
        Task<DayWeekViewModel> DeleteAsync(int id);
    }
}
