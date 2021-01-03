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

namespace ParsMarkt.Pages.Products
{

    public partial class NewProducts
    {
        public NewProducts()
        {
            productViewModel = new ProductViewModel();
             Products = new List<ProductViewModel>();
        }
        ParsMarkt.Pages.Basket.BasketView basketView = new Basket.BasketView();
        [Inject]
        public IBasketServices BasketServices { get; set; }
        [Inject]
        public IMenuServices menuServices { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        //[Inject]
        //public IJSRuntime Js { get; set; }

        //*****************************************************************************

        //[Parameter]
        //public string ProductId { get; set; }

        //*****************************************************************************

        private List<ProductViewModel> Products;
       
        public List<BasketItem> BasketItems;

        [Parameter]
        public int ProductId { get; set; }

        public ProductViewModel productViewModel;

        //*****************************************************************************
        Helper.Basket ObjBasket = new Helper.Basket();
        protected override async Task OnInitializedAsync()
        {
            BasketItems = new List<BasketItem>();

            ////*****************************************************************************
            IList<MenuViewModel> menu = new List<MenuViewModel>();
            Products = (await BasketServices.GetAsync()).ToList();
        
            //*****************************************************************************

        }

        //*****************************************************************************
        public async Task AddToBasket(ProductViewModel productViewModel)
        {
            

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

            this.StateHasChanged();
        }

      public void  MoreDetails(ProductViewModel productViewModel)
        {
            ProductId = productViewModel.Id;
            Navigation.NavigateTo($"/ProductDetails/{ProductId}");
        }


    }
}







//var oldBasket = await LocalStorage.GetItemAsync<List<BasketItem>>("JsonBasketItem");
//if (oldBasket != null)
//{
//    BasketItem basket = new BasketItem();
//    var Count = oldBasket.Count(c => c.Product.Id == productViewModel.Id);
//    if (oldBasket.Any(ob => ob.Product.Id == productViewModel.Id))
//    {
//        //    basket.AddItem();
//        //    basket.Price=basket.GetItemsPrice();

//        //oldBasket.Add(new BasketViewModels
//        //{
//        //    Count = Count + 1,
//        //    Price = (Count + 1) * productViewModel.Price
//        //});
//    }
//    else
//    {
//        BasketItems.Add(new BasketItem
//        {
//            Product = productViewModel,
//            Count = Count + 1,
//            Price = productViewModel.Price * Count
//        });
//    }
//}

//string key = "BasketItem";
//var Basket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
//await LocalStorage.SetItemAsync(key, Basket);







//var c = 0;
//var Content = await LocalStorage.GetItemAsync<List<BasketItem>>("JsonBasketItem");
//var productcount = Content.Count(c => c.Product.Id == productViewModel.Id);

//if (Content.Any(c => c.Product.Id == productViewModel.Id))
//{
//    c = productcount + 1;
//    Content.Add(new BasketItem { Count = c, Price = productViewModel.Price * c });
//}
//Content.Add(new BasketItem
//{
//    Product = productViewModel,
//    Price = productViewModel.Price * (productcount + 1),
//    Count = productcount + 1

//}); ;

//BasketItems = Content;
/////await LocalStorage.SetItemAsync<List<BasketItem>>("JsonBasketItem", BasketItems);

//string key = "JsonBasketItem";
//var Basket = JsonSerializer.Serialize<List<BasketItem>>(BasketItems);
//await LocalStorage.SetItemAsync(key, Basket);
































//var OldBaskets = await LocalStorage.GetItemAsync("Baskets");
//if (Basket)
//{

//}

//if (_BasketList.Any(bs=>bs.ProductList.Id==productViewModel.Id))
//{


//}

//if (_BasketList.Any())
//{
//    var oldBasket = Js.GetInLocalStorage("basketItem").GetAwaiter().GetResult();
//    var baskets = JsonSerializer.Deserialize<List<BasketViewModels>>(oldBasket.ToString());
//    if (baskets == null)
//        return;
//    baskets.Add(new BasketViewModels { ProductList = productViewModel, Count = 1, Price = productViewModel.Price });
//    _BasketList = new List<BasketViewModels>();
//    baskets.ForEach(b => _BasketList.Add(b));
//    Js.RemoveInLocalStorage("basketItem");
//    Js.SetInLocalStorage("basketItem", JsonSerializer.Serialize<List<BasketViewModels>>(_BasketList));
//    return;
//}
//if (_BasketList.Any(bs => bs.ProductList.Id == productViewModel.Id))
//{
//    //var Count = _BasketList.Count+1;
//}

//_BasketList.Add(new BasketViewModels { ProductList = productViewModel, Count = 1, Price =
//    productViewModel.Price*_BasketList.Count });
//string key = "basketItem";
//var content = JsonSerializer.Serialize<List<BasketViewModels>>(_BasketList);
//Js.SetInLocalStorage(key, content);