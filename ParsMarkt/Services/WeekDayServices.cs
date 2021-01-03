using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt
{
    public class WeekDayServices:BaseServices,IWeekDayServices
    {
        public WeekDayServices(HttpClient client) : base(client)
        {

        }

        public Task<DayWeekViewModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<DayWeekViewModel>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DayWeekViewModel> PostAsync(DayWeekViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<DayWeekViewModel> PutAsync(DayWeekViewModel viewModel, int id)
        {
            throw new NotImplementedException();
        }

        protected override string GetApiUrl()
        {
            return "WeekDays";
        }
    }
}
