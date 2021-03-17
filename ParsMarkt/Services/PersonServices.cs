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
    public class PersonServices : BaseServices, IPersonServices
    {
        public PersonServices(HttpClient client) : base(client)
        {

        }
       
        public string Url = "https://localhost:44380/users";
        protected override string GetApiUrl()
        {
            return "Users";
        }
        public async Task<IList<PersonViewModel>> GetAsync()
        {

            var result = await GetAsync<IList<PersonViewModel>>();

            return result;
        }

        public async Task<PersonViewModel> PostAsync(PersonViewModel viewModel)
        {
           
            var result = await PostAsync<PersonViewModel, PersonViewModel>(viewModel);
            return result;
        }
        public async Task<PersonViewModel> PutPersonAsync<PersonViewModel>(PersonViewModel viewModel,int id)
        {
           // var result = await PutAsync<PersonViewModel, PersonViewModel>(viewModel);
            //var content = new StringContent(JsonSerializer.Serialize(viewModel), Encoding.UTF8, "application/json");
            var result = await Http.PutAsJsonAsync($"{Url}/{id}", viewModel);
            if (result.IsSuccessStatusCode)
            {
                try
                {
                    PersonViewModel res = await result.Content.ReadFromJsonAsync<PersonViewModel>();
                    return res;
                }
                catch (System.Text.Json.JsonException)
                {
                    System.Console.WriteLine("Invalid JSON.");
                }
            }


            return default;
        }
        public async Task<PersonViewModel> PutAsync(PersonViewModel viewModel)
        {

            var result = await PutAsync<PersonViewModel, PersonViewModel>(viewModel);

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await DeleteAsync<bool>(id);
            return res;
        }

        public async Task<PersonViewModel> GetByIdAsync(int id)
        {
            var result = await Http.GetAsync($"{Url}/{id}");
            //var result = await GetAsync<PersonViewModel>();
            var respons= await result.Content.ReadFromJsonAsync<PersonViewModel>();
            return respons;
        }

        public async Task<PersonViewModel> PostPersonAsync(PersonViewModel viewModel)
        {
            //var content = new StringContent(JsonSerializer.Serialize(viewModel), Encoding.UTF8, "application/json");
            // var result = await PostAsync<PersonViewModel, PersonViewModel>(viewModel);
            var result = await Http.PostAsJsonAsync(Url,viewModel);
            if (result.IsSuccessStatusCode)
            {
                return viewModel;
            }
            return default;

        }

       
    }
}
