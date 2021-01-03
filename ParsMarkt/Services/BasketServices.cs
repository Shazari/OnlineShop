using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using ViewModels;
using Blazored.LocalStorage;
using System.Text.Json;

namespace ParsMarkt
{
    public class BasketServices : BaseServices, IBasketServices
    {
        ILocalStorageService localStorage;
        public BasketServices(HttpClient client) : base(client)
        { }
        protected override string GetApiUrl()
        {
            return "Baskets";
        }

        public async Task<IList<ProductViewModel>> GetAsync()
        {
            var result = await GetAsync<IList<ProductViewModel>>();
            //var serializedProduct = JsonSerializer.Serialize<IList<ProductViewModel>>(result);
            //await localStorage.SetItemAsync("Products", serializedProduct);

            return result;
        }

        public async Task<ProductViewModel> PostAsync(ProductViewModel viewModel)
        {
            var result = await PostAsync<ProductViewModel, ProductViewModel>(viewModel);
            return result;
        }
    }
}


