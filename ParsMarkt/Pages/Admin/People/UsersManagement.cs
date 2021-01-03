using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace ParsMarkt.Pages.Admin.People
{
    public partial class UsersManagement
    {
        public UsersManagement()
        {
           
        }
        public List<PersonViewModel> Users;
        
        [Inject]
        public IPersonServices PersonService { get; set; }
        [Inject]
        public NavigationManager  NavigationService { get; set; }
        [Inject]
        protected System.Net.Http.HttpClient Http { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Users = new List<PersonViewModel>();
            //Users = await Http.GetFromJsonAsync<List<PersonViewModel>>("https://localhost:44380/people");
           Users=(await PersonService.GetAsync()).ToList();
           
           
        }
    }
}
