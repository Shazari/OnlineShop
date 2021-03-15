using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ParsMarkt.Pages
{
    public partial class Index
    {
        public Index()
        {
           // BasketItems = new List<BasketItem>();
        }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            await JsRuntime.InvokeVoidAsync("LoadCustome");

        }

       

        public List<BasketItem> BasketItems;
        protected override async Task OnInitializedAsync()
        {
           
       
        }
    }
}
