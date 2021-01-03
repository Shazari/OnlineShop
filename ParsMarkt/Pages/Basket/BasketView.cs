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

namespace ParsMarkt.Pages.Basket
{
    public partial class BasketView
    {
        public BasketView()
        {


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

        protected override async Task OnInitializedAsync()
        {



            BasketItems = new List<BasketItem>();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, options);
            try
            {
                if (deserializedBasket==null)
                {
                    return;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message.ToString());
            }
            deserializedBasket.ForEach(b => BasketItems.Add(b));
        }

        //*****************************************************************************


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
            this.StateHasChanged();
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
                if (BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id).Count>0)
                {
                    BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id).Count--;
                }
                
            }

            var serializedBasket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
            await LocalStorage.SetItemAsync("Basket", serializedBasket);
            this.StateHasChanged();
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
            this.StateHasChanged();
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



















//var content = await Js.GetInLocalStorage("JsonBasketItem");
//if (!string.IsNullOrEmpty(content.ToString()))
//{
//    var baskets = JsonSerializer.Deserialize<List<BasketItem>>(content.ToString());
//    BasketList = new List<BasketItem>();

//    if (baskets != null)
//    {
//        baskets.ForEach(b => BasketList.Add(b));

//    }

//}

//////////////////////////////////////////////////////////////////////////////////

//BasketList = new List<BasketItem>();
//var content = await LocalStorage.GetItemAsync<List<BasketItem>>("JsonBasketItem");
//var Baskets = JsonSerializer.Deserialize<List<BasketItem>>(content.ToString());
//if (Baskets != null)
//{


//    BasketList = new List<BasketItem>();

//    Baskets.ForEach(b => BasketList.Add(b));

//    Count = BasketList.Count().ToString();
//}
