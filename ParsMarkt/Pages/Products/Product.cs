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
    public partial class Product
    {
        public Product()
        {

        }

        [Inject]
        public IBasketServices BasketServices { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public NavigationManager Navigate { get; set; }
        [Parameter]
        public long ProductId { get; set; }

        public List<BasketItem> BasketItems;

        [Inject]
        public IProductServices ProductService { get; set; }

        private FilterProduct filterproduct { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BasketItems = new List<BasketItem>();
            filterproduct = new FilterProduct();
            try
            {
                filterproduct = await ProductService.GetFilterProduct();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

           
        }

        public async Task AddToBasket(ProductViewModel productViewModel)
        {

            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            deserializedBasket.ForEach(b => BasketItems.Add(b));

            if (BasketItems.Any(p => p.Product.Id == productViewModel.Id))
            {
                BasketItems.FirstOrDefault(p => p.Product.Id == productViewModel.Id).Count++;
            }
            else
            {
                BasketItems.Add(new BasketItem
                {
                    Product = productViewModel,

                    Count = 1
                });
            }

            var serializedBasket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
            await LocalStorage.SetItemAsync("Basket", serializedBasket);
            //Navigate.NavigateTo("/CheckOutStep1");

        }

    }
}
