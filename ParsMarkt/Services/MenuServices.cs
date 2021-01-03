
using System.Net.Http;
using ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ParsMarkt
{
    public class MenuServices : BaseServices, IMenuServices
    {
        public MenuServices(HttpClient client) : base(client)
        {
        }

        protected override string GetApiUrl()
        {
            return "Menus";
        }

        public async Task<IList<MenuViewModel>> GetAsync()
        {

            var result = await GetAsync<IList<MenuViewModel>>();

            return result;
        }
        public async Task<MenuViewModel> GetByIdAsync(int id)
        {
            var res = await GetByIdAsync<MenuViewModel>(id);
                return res;
        }

        public async Task<MenuViewModel> PostAsync(MenuViewModel viewModel)
        {
            var result = await PostAsync<MenuViewModel, MenuViewModel>(viewModel);

            return result;
        }

        public async Task<MenuViewModel> PutAsync(MenuViewModel viewModel)
        {
            var res = await PutAsync<MenuViewModel, MenuViewModel>(viewModel);
            return res;
        }

        public async Task<MenuViewModel> DeleteAsync(int id)
        {
            var res = await DeleteAsync<MenuViewModel>(id);
            return res;
        }

       
    }
}
