using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Pages.Basket
{
    public partial class BasketCounter
    {
        [Inject]
        public IBasketServices BasketServices { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        //*****************************************************************************

        public List<BasketItem> BasketItems;

        [Parameter]
        public BasketItem BasketVC { get; set; } = new BasketItem();
        //*****************************************************************************
        protected override async Task OnInitializedAsync()
        {



            BasketItems = new List<BasketItem>();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, options);

            deserializedBasket.ForEach(b => BasketItems.Add(b));
        }
        public async Task Plus(BasketItem item)
        {
            item = BasketVC;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, options);

            if (BasketItems.Any(p => p.Product.Id == item.Product.Id))
            {
                BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id).Count++;
            }

            var serializedBasket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
            await LocalStorage.SetItemAsync("Basket", serializedBasket);
        }

        public async Task Minus(BasketItem item)
        {
            item = BasketVC;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, options);

            if (BasketItems.Any(p => p.Product.Id == item.Product.Id))
            {
                if (BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id).Count > 0)
                {
                    BasketItems.FirstOrDefault(p => p.Product.Id ==item.Product.Id).Count--;
                }

            }

            var serializedBasket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
            await LocalStorage.SetItemAsync("Basket", serializedBasket);
        }
        public async Task Remove(BasketItem item)
        {
            item = BasketVC;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, options);

            if (BasketItems.Any(p => p.Product.Id == item.Product.Id))
            {
                var ite = BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id);

                BasketItems.Remove(ite);

            }

            var serializedBasket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
            await LocalStorage.SetItemAsync("Basket", serializedBasket);
        }

        public int GetSubTotal(BasketItem item)
        {
      
            var result = item.Count * item.Product.Price;
            return result;
        }

        public int GetTotal()
        {
            int result = 0;
            foreach (var item in BasketItems)
            {
                result += GetSubTotal(item);

            }
            return result;
        }

        public int GetCount()
        {
            int result = BasketItems.Count;
            return result;
        }

    }
}
