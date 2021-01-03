using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Pages.Admin.People
{
    public partial class AddNewUser
    {
        public IList<PersonViewModel> Users;
        public PersonViewModel User;

        [Inject]
        public IPersonServices PersonService { get; set; }

        [Inject]
        public IRoleServices RoleService { get; set; }

        [Inject]
        public NavigationManager NavigationService { get; set; }

        public IList<RoleViewModel> role;
        string message="";

        protected override async Task OnInitializedAsync()
        {
            role = new List<RoleViewModel>();
            User = new PersonViewModel();
            role = await RoleService.GetAsync();

        }

        private async Task AddUser()
        {
        
        var res=  await PersonService.PostAsync(User);
            if (res==null)
            {
                message = "res not send";
            }
            NavigationService.NavigateTo("/UsersManagement");
        }

    }
}
