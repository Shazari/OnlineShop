using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt
{
    public class OrderServices : BaseServices, IOrderServices
    {
        public OrderServices(HttpClient client):base(client)
        {

        }
        public async Task<bool> DeleteAsync(int id)
        {
            var content = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");
            var RequestUri = ($"https://localhost:44380/Orders/{id}");
           
           var  response = await Http.DeleteAsync(requestUri: RequestUri);
            return response.IsSuccessStatusCode;
        }

        public async Task<IList<OrderViewModel>> GetAsync()
        {
            var res = await GetAsync();
            return res;

        }

        public async Task<OrderViewModel> GetByIdAsync(int id)
        {
            var respons = await Http.GetFromJsonAsync<OrderViewModel>($"https://localhost:44380/People/{id}");
            // var result = await GetAsync<PersonViewModel>();

            return respons;
        }

        public Task<OrderViewModel> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderViewModel> PostAsync(OrderViewModel viewModel)
        {
            var res = await PostAsync<OrderViewModel, OrderViewModel>(viewModel);
            return res;
        }

        public async Task<OrderViewModel> PutAsync(OrderViewModel viewModel)
        {
            var result = await PutAsync<OrderViewModel, OrderViewModel>(viewModel);
            return result;
        }

        protected override string GetApiUrl()
        {
            return "Orders";
        }

       
    }
}
