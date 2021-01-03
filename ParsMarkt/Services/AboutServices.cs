using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;
    
namespace ParsMarkt
{
    public class AboutServices:BaseServices,IAboutServices
    {
        public AboutServices(HttpClient client):base(client)
        {

        }
        protected override string GetApiUrl()
        {
            return "Abouts";        }

        public async Task<IList<AboutUsViewModel>> GetAsync()
        {
            var res =await GetAsync<IList<AboutUsViewModel>>();
            return res;
        }
        public async Task<AboutUsViewModel> GetByIdAsync(int id) 
        {
            var res = await GetByIdAsync<AboutUsViewModel>(id);
            return res;
              
        }

        public async Task<AboutUsViewModel> PostAsync(AboutUsViewModel viewModel)
        {
            var res = await PostAsync<AboutUsViewModel, AboutUsViewModel>(viewModel);
            return res;
        }

        public async Task<AboutUsViewModel> PutAsync(AboutUsViewModel viewModel)
        {
            var res = await PutAsync<AboutUsViewModel, AboutUsViewModel>(viewModel);
            return res;
        }

        public async Task<AboutUsViewModel> DeleteAsync(int id)
        {
            var res = await DeleteAsync<AboutUsViewModel>(id);
            return res;
        }
    }
}
