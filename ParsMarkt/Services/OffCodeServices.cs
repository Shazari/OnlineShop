using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
    public class OffCodeServices : BaseServices, IOffCodeServices
    {
        public OffCodeServices(HttpClient client):base(client)
        {

        }

        protected override string GetApiUrl()
        {
            return "OffCodes";
        }

        public async Task<IList<OffCodeViewModel>> GetAsync()
        {
            var result = await GetAsync<IList<OffCodeViewModel>>();
            return result;
        }

        public Task<OffCodeViewModel> PostAsync(OffCodeViewModel viewModel)
        {
            throw new NotImplementedException();
        }

       
    }
}
