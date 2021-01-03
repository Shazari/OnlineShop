using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace ParsMarkt.Shared.Header
{
    public partial class NavbarInner
    {
        public NavbarInner()
        {
            //List = new List<MenuViewModel>();
        }
        [Inject]
        public IMenuServices menuServices { get; set; }
        [Inject]
        protected System.Net.Http.HttpClient Http { get; set; }
        protected override async Task OnInitializedAsync()
        {
           // var List = await Http.GetFromJsonAsync<List<MenuViewModel>>("https://localhost:44380/Menus");

            var res = await menuServices.GetAsync();
            List = res.ToList();
 
        }
        private List<MenuViewModel> List;

    }
}