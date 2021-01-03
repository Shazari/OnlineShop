using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Pages.Products
{
    public partial class MostPapular
    {
        [Inject]
        public IBasketServices BasketServices { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        

        private List<ProductViewModel> Products;

        public List<BasketItem> BasketItems;

        protected override async Task OnInitializedAsync()
        {
            Products = new List<ProductViewModel>();
            var result = await BasketServices.GetAsync();

            Products = result.ToList();

        }


       


    }
}
