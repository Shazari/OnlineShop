using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Pages.Admin.People
{
    public partial class DeleteUser
    {
        [Parameter] public int Id { get; set; }

        public IList<PersonViewModel> Users;

        public PersonViewModel User;

        [Inject]
        public IPersonServices PersonService { get; set; }
        
        [Inject]
        public NavigationManager NavigationService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            User = new PersonViewModel();
            Users = await PersonService.GetAsync();
            User = Users.FirstOrDefault(p => p.Id == Id);
           
        }
        public async Task Delele()
        {
            await PersonService.DeleteAsync(Id);
            NavigationService.NavigateTo("/UsersManagement");
        }
    }
}
