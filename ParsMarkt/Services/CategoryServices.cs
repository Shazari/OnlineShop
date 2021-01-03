using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
    public class CategoryServices:BaseServices,ICategoryServices
    {
        public CategoryServices(HttpClient client):base(client)
        {

        }
        protected override string GetApiUrl()
        {
            return "Categories";
        }

        public async Task<IList<CategoriesViewModel>> GetAsync()
        {
            var result = await GetAsync<IList<CategoriesViewModel>>();
            return result;
        }

        public async Task<CategoriesViewModel> PostAsync(CategoriesViewModel viewModel)
        {
           
            var result = await PostAsync<CategoriesViewModel, CategoriesViewModel>(viewModel);
            return result;
        }

        public async Task<CategoriesViewModel> PutAsync(CategoriesViewModel viewModel)
        {
            var result = await PutAsync<CategoriesViewModel, CategoriesViewModel>(viewModel);

            return result;
        }

        //protected override async Task<CategoriesViewModel> DeleteAsync<CategoriesViewModel>()
        //{
        //    var res = await  DeleteAsync();
        //    return res;
        //}

        public async Task<bool> DeleteAsy(int id)
        {
           
            var RequestUri = ($"https://localhost:44380/Categories/{id}");
           var  response = await Http.DeleteAsync(requestUri: RequestUri);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        Task<CategoriesViewModel> ICategoryServices.DeleteAsync(CategoriesViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutAsy(CategoriesViewModel viewModel)
        {
            var content = new StringContent(JsonSerializer.Serialize(viewModel), Encoding.UTF8, "application/json");
            var RequestUri = ($"https://localhost:44380/Categories");
            var response = await Http.PutAsync(requestUri: RequestUri,content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
