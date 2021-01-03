using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;
using static System.Net.WebRequestMethods;

namespace ParsMarkt.Pages.Admin.People
{
    public partial class EditUser
    {
        public EditUser()
        {
           
        }
        [Parameter]
        public int Id { get; set; }
        
        public IList<PersonViewModel> Users;
        public PersonViewModel User;

        [Inject]
        public IRoleServices RoleService { get; set; }

        [Inject]
        public IPersonServices PersonService { get; set; }

        [Inject]
        public NavigationManager NavigationService { get; set; }

        [Inject]
        protected System.Net.Http.HttpClient Http { get; set; }
        string message = "";

        public IList<RoleViewModel> role;

        protected override async Task OnInitializedAsync()
        {
            User = new PersonViewModel();
            Users =await PersonService.GetAsync();
            User = Users.FirstOrDefault(p=>p.Id==Id);
            role = await RoleService.GetAsync();
            User.Id = Id;
            if (User==null)
            {
                message = "خطایی رخ داده است";
            }
        }
        public async Task EditUserAsync()
        {
            User.Id = Id;
          
            await PersonService.PutAsync(User);
            NavigationService.NavigateTo("/UsersManagement");

        }

    }
}
