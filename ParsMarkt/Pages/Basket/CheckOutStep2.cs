using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;
using Blazored.LocalStorage;
namespace ParsMarkt.Pages.Basket
{
    public partial class CheckOutStep2
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IPersonServices PersonService { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        public OrderViewModel Order;
        public List<BasketItem> BasketItems;
        public PersonViewModel person =new PersonViewModel();

        protected override async Task OnInitializedAsync()
        {
            Order = new OrderViewModel();
            BasketItems = new List<BasketItem>();
            var contentbasket = await LocalStorage.GetItemAsStringAsync("Basket");
            var deserializedBasket = JsonSerializer.Deserialize<List<BasketItem>>(contentbasket, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            deserializedBasket.ForEach(b => BasketItems.Add(b));
            //var people = await PersonService.GetAsync();

            person = new PersonViewModel {
                Id = 1002,
                Address = "wupp",
                City = "wupp",
                FirstName = "askar",
                LastName = "rostami",
                PostCode = 12345,
                Countries = "de",
                EmailAddress = "askar@gmail.com",
                PhoneNumber = 12345,

            };
           
            Order = new OrderViewModel
            {
                Person = person,
                BasketItems = BasketItems,
                CreateDate = DateTime.Now,
                IsFinaly = false,
                
            };
            var serializedOrder = JsonSerializer.Serialize<OrderViewModel>(Order);
            await LocalStorage.SetItemAsync("Order", serializedOrder);

            //Order = new OrderViewModel();
            var contentOrder = await LocalStorage.GetItemAsStringAsync("Order");
            var deserializedOrder = JsonSerializer.Deserialize<OrderViewModel>(contentOrder, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Order = deserializedOrder;


        }

        public async Task SubmitValidForm()
        {
            if (person==null)
            {
                //var res = await PersonService.PutPersonAsync(person,person.Id);   
                if (person == null) return;
            }
            Navigation.NavigateTo("/CheckOutStep3");
        }
    }
}
