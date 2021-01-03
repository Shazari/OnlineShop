using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt.Helper
{
    public class Basket:ComponentBase
    {
        public Basket()
        {
            BasketItems = new List<BasketItem>();

        }
        [Inject]
        public IBasketServices BasketServices { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
       
        [Inject]
        public IJSRuntime Js { get; set; }

        //*****************************************************************************

        public List<BasketItem> BasketItems;

        //*****************************************************************************

        protected override async Task OnInitializedAsync ()
        {

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
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, options);

            if (BasketItems.Any(p => p.Product.Id == item.Product.Id))
            {
                BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id).Count--;
            }

            var serializedBasket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
            await LocalStorage.SetItemAsync("Basket", serializedBasket);
        }
        public async Task Remove(BasketItem item)
        {
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
            return (int)result;
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
