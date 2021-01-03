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
    public class RoleServices : BaseServices, IRoleServices
    {
        public RoleServices(HttpClient client):base(client)
        {

        }
        protected override string GetApiUrl()
        {
            return "Roles";
        }
        public async Task<RoleViewModel> DeleteAsync(int id)
        {
            var res = await DeleteAsync<RoleViewModel>(id);
            return res;
            
          
        }

        public async Task<IList<RoleViewModel>> GetAsync()
        {
            var res = await GetAsync<List<RoleViewModel>>();
            return res;
        }

        public async Task<RoleViewModel> GetAsyncById(int id)
        {

            var respons = await GetByIdAsync<RoleViewModel>(id);
            

            return respons;
        }

       

        public async Task<RoleViewModel> PostAsync(RoleViewModel viewModel)
        {
            var result = await PostAsync<RoleViewModel, RoleViewModel>(viewModel);

            return result;
        }

        public async Task<RoleViewModel> PutAsync(RoleViewModel viewModel)
        {
            var res = await PutAsync<RoleViewModel, RoleViewModel>(viewModel);
            return res;
        }

       
    }
}
