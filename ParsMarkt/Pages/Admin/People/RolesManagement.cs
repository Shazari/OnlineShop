using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt.Pages.Admin.People
{
    public partial class RolesManagement
    {
        public RolesManagement()
        {
            Role =new RoleViewModel();
            Roles = new List<RoleViewModel>();
        }
        [Inject]
        public IRoleServices RoleService { get; set; }
        public IList<RoleViewModel> Roles;
        public RoleViewModel Role;
        protected override async Task OnInitializedAsync()
        {
            
            Roles =await RoleService.GetAsync();
        }

    }
}
