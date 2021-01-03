using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ParsMarkt.Pages
{
    public partial class Footer
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            await JsRuntime.InvokeVoidAsync("LoadCustome");

        }


    }
}
