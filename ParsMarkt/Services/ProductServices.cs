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
    public class ProductServices : BaseServices, IProductServices
    {
        public ProductServices(HttpClient client):base(client)
        {

        }
        //protected HttpClient http { get; }
        protected override string GetApiUrl()
        {
            return "Products";
        }
        public async Task<IList<ProductViewModel>> GetAsync()
        {
          
            var result = await GetAsync<IList<ProductViewModel>>();

            return result;
        }

        public async Task<ProductViewModel> PostAsync(ProductViewModel viewModel)
        {
           
            var result = await PostAsync<ProductViewModel, ProductViewModel>(viewModel);
            return result;
            
        }

        public async Task<ProductViewModel> PutAsync(ProductViewModel viewModel)
        {
            var result = await PutAsync<ProductViewModel, ProductViewModel>(viewModel);
            return result;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           
           var  response = await DeleteAsync<bool>(id);
            return response;

        }

        public System.Net.Http.HttpClient cli = new HttpClient();
        public async Task<ProductViewModel> GetAsyncById(int id)
        {
            System.Net.Http.HttpResponseMessage response = null;
         
            var url = $"https://localhost:44380/Products/{id}";
            response = await cli.GetAsync(url);
            var res = await response.Content.ReadFromJsonAsync<ProductViewModel>();

            return res;
        }
    }
}
