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
    public partial class CheckOutStep1
    {
        public CheckOutStep1()
        {

        }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public IBasketServices BasketServices { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public IPersonServices PersonService { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        //*****************************************************************************

        public List<BasketItem> BasketItems;

        //*****************************************************************************


        protected override async Task OnInitializedAsync()
        {
            BasketItems = new List<BasketItem>();



            var content = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

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
                if (BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id).Count > 0)
                {
                    BasketItems.FirstOrDefault(p => p.Product.Id == item.Product.Id).Count--;
                }

            }

            var serializedBasket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
            await LocalStorage.SetItemAsync("Basket", serializedBasket);
        }

        private async Task Remove(BasketItem item)
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
        //az identity gerefte mishavad
        public int UserId = 1;
        public string NextstepInfo = "";
        public bool login = false;

        public OrderViewModel Order;

        public async Task CheckStep1()
        {
            //user login ast
            if (UserId == 1)
            {
                 NextstepInfo = "در مرحله بعدی شما آدرس ارسال را انتخاب خواهید کرد. &nbsp; &nbsp";
                login = true;
                var person = await PersonService.GetByIdAsync(UserId);
                Order = new OrderViewModel
                {
                    Person = person,
                    BasketItems = BasketItems,
                    CreateDate = DateTime.Now,
                    IsFinaly = false,
                };
                var serializedOrder = JsonSerializer.Serialize<OrderViewModel>(Order);
                await LocalStorage.SetItemAsync("Order", serializedOrder);
                Navigation.NavigateTo("/CheckOutStep2");
                this.StateHasChanged();
            }

            //user login nist
            if (UserId!=2)
            {

                NextstepInfo = "در مرحله بعد شما وارد مراحل نهایی کردن خرید میشوید و برای این کارنیاز به ورود به سایت یا ثبت نام در سایت یا فعال سازی حساب کاربری خود دارید";
            }
            
       
       
        

    }


}
}



























//var content = await LocalStorage.GetItemAsync<List<BasketItem>>("JsonBasketItem");
//if (content!=null)
//{
//    content.ForEach(b=>items.Add(b));
//}



//var content = await Js.GetInLocalStorage("basketItem");
//if (!string.IsNullOrEmpty(content.ToString()))
//{
//    var baskets = JsonSerializer.Deserialize<List<BasketItem>>(content.ToString());
//    items = new List<BasketItem>();

//    if (baskets != null)
//    {
//        baskets.ForEach(b => items.Add(b));

//    }

//}
//Count = items.Count;

//private List<BasketItem> items;
//private int Count;